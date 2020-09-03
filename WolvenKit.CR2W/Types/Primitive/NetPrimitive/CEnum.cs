﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;
using WolvenKit.CR2W.Reflection;

namespace WolvenKit.CR2W.Types
{
    public interface IEnumAccessor
    {
        List<string> Value { get; set; }
    }


    [DataContract(Namespace = "")]
    [REDMeta()]
    public class CEnum<T> : CVariable, IEnumAccessor where T : Enum
    {
        private T wrappedEnum;
        public T WrappedEnum { get => wrappedEnum; set => wrappedEnum = value; }

        [DataMember]
        public List<string> Value { get; set; } = new List<string>();

        public bool IsFlag => WrappedEnum.GetType().IsDefined(typeof(FlagsAttribute), false);

        public CEnum(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }



        public override string REDType => WrappedEnum.GetType().Name;

        private static void SetFlag<T>(ref T value, T flag) where T : Enum
        {
            ulong numericValue = Convert.ToUInt64(value);
            numericValue |= Convert.ToUInt64(flag);
            value = (T)Enum.ToObject(typeof(T), numericValue);
        }
        private static void ClearFlag<T>(ref T value, T flag) where T : Enum
        {
            ulong numericValue = Convert.ToUInt64(value);
            numericValue &= ~Convert.ToUInt64(flag);
            value = (T)Enum.ToObject(typeof(T), numericValue);
        }

        public override void Read(BinaryReader file, uint size)
        {
            List<string> strings = new List<string>();
            if (IsFlag)
            {
                while (true)
                {
                    var idx = file.ReadUInt16();
                    if (idx == 0)
                        break;

                    string s = cr2w.names[idx].Str;

                    strings.Add(s);
                }
            }
            else
            {
                var idx = file.ReadUInt16();

                string s = cr2w.names[idx].Str;

                strings.Add(s);
            }

            SetValue(strings);
        }

        /// <summary>
        /// Call after the stringtable was generated!
        /// </summary>
        /// <param name="file"></param>
        public override void Write(BinaryWriter file)
        {
            ushort val = 0;

            foreach (var item in Value)
            {
                var nw = cr2w.names.First(_ => _.Str == item);
                val = (ushort)cr2w.names.IndexOf(nw);

                file.Write(val);
            }
            if (IsFlag)
                file.Write((ushort)0x00);
        }

        public override CVariable Copy(CR2WCopyAction context)
        {
            var var = (CEnum<T>)base.Copy(context);
            var.Value = Value;
            var.WrappedEnum = WrappedEnum;
            return var;
        }

        public override Control GetEditor()
        {
            if (WrappedEnum.GetType().IsDefined(typeof(FlagsAttribute), false))
            {
                // add all values to 
                CheckedListBox clb = new CheckedListBox();
                clb.Items.AddRange(WrappedEnum.GetType().GetEnumNames());
                //clb.Height = clb.Items.Count * clb.ItemHeight;

                for (int i = 0; i < WrappedEnum.GetType().GetEnumNames().Count(); i++)
                {
                    string s = WrappedEnum.GetType().GetEnumNames()[i];
                    if (Value.Contains(s))
                        clb.SetItemChecked(i, true);
                }
                clb.SelectedValueChanged += HandleEnumPick;
                return clb;
            }
            else
            {
                ComboBox cb = new ComboBox();
                cb.Items.AddRange(WrappedEnum.GetType().GetEnumNames());

                cb.SelectedValue = WrappedEnum.ToString();
                cb.SelectedValueChanged += HandleEnumPick;
                return cb;
            }
        }

        private void HandleEnumPick(object sender, EventArgs e)
        {
            if (IsFlag)
            {
                List<string> enumstrings = new List<string>();
                foreach (var item in (sender as CheckedListBox).CheckedItems)
                {
                    if (item is string enumstring)
                    {
                        enumstrings.Add(enumstring);
                    }
                }
                SetValue(enumstrings);
            }
            else
            {
                if ((sender as ComboBox).SelectedItem is string enumstring)
                {
                    SetValue(new List<string>() { enumstring });
                }
            }
        }




        public override CVariable SetValue(object val)
        {
            if (val is List<string> l)
            {
                Value = l;

                if (IsFlag)
                {
                    foreach (var item in WrappedEnum.GetType().GetEnumNames())
                    {
                        //handle EnumValues with Spaces in them. facepalm.
                        string finalvalue = item.Replace(" ", string.Empty);
                        finalvalue = finalvalue.Replace("'", string.Empty);
                        finalvalue = finalvalue.Replace("/", string.Empty);
                        finalvalue = finalvalue.Replace(".", string.Empty);
                        T en = (T)Enum.Parse(WrappedEnum.GetType(), finalvalue);

                        // flag is set
                        if (Value.Contains(item))
                            SetFlag<T>(ref wrappedEnum, en);
                        // flag is not set
                        else
                            ClearFlag<T>(ref wrappedEnum, en);
                    }
                }
                else
                {
                    var s = Value.Last();

                    //handle EnumValues with Spaces in them. facepalm.
                    string finalvalue = s.Replace(" ", string.Empty);
                    finalvalue = finalvalue.Replace("'", string.Empty);
                    finalvalue = finalvalue.Replace("/", string.Empty);
                    finalvalue = finalvalue.Replace(".", string.Empty);

                    // set enum
                    T en = (T)Enum.Parse(WrappedEnum.GetType(), finalvalue);
                    WrappedEnum = en;
                }
            }

            return this;
        }

        public override string ToString() => string.Join(",", this.Value);
    }
}