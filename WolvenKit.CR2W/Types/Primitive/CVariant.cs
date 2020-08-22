﻿using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using WolvenKit.CR2W.Editors;
using WolvenKit.CR2W.Reflection;

namespace WolvenKit.CR2W.Types
{
    /// <summary>
    /// A generic wrapper class for a single CVariable
    /// Format: [ushort typeID] [uint size] [byte[size] data]
    /// </summary>
    [REDMeta()]
    public class CVariant : CVariable
    {
        public CVariable Variant;

        public CVariant(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }

        public override void Read(BinaryReader file, uint size)
        {
            var typepos = file.BaseStream.Position;

            var typeId = file.ReadUInt16();
            var typename = cr2w.names[typeId].Str;

            var varsize = file.ReadUInt32() - 4;

            if (varsize > 0)
            {
                Variant = CR2WTypeManager.Create(typename, nameof(Variant), cr2w, this);
                Variant.Read(file, varsize);
            }
            else
            {
                // do nothing I guess?
            }
        }

        public override void Write(BinaryWriter file)
        {
            if (Variant == null)
            {
                file.Write((ushort)0);
                file.Write((uint)4);
            }
            else
            {
                file.Write(Variant.GettypeId());

                byte[] buffer = System.Array.Empty<byte>();
                using (var ms = new MemoryStream())
                using (var bw = new BinaryWriter(ms))
                {
                    Variant.Write(bw);
                    buffer = ms.ToArray();
                }
                file.Write(buffer.Length + 4);
                file.Write(buffer);
            }
        }

        public override CVariable SetValue(object val)
        {
            if (val is CVariable)
            {
                Variant = (CVariable) val;
            }

            return this;
        }

        public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name)
        {
            return new CVariant(cr2w, parent, name);
        }

        public override CVariable Copy(CR2WCopyAction context)
        {
            var var = (CVariant) base.Copy(context);
            var.Variant = var.Copy(context);
            return var;
        }

        public override List<IEditableVariable> GetEditableVariables()
        {
            var list = new List<IEditableVariable>();
            if (Variant != null)
            {
                list.Add(Variant);
            };
            return list;
        }

        public override Control GetEditor()
        {
            if (Variant != null)
                return Variant.GetEditor();
            return null;
        }

        public override string ToString()
        {
            if (Variant != null)
                return Variant.ToString();
            return "";
        }

        public override bool CanAddVariable(IEditableVariable newvar)
        {
            return newvar == null || newvar is CVariable;
        }

        public override void AddVariable(CVariable var)
        {
            this.Variant = var;
        }
    }
}