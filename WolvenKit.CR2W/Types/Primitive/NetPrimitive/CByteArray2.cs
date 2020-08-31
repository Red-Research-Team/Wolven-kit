﻿using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml;
using WolvenKit.CR2W.Editors;
using WolvenKit.CR2W.Reflection;

namespace WolvenKit.CR2W.Types
{
    [REDMeta()]
    public class CByteArray2 : CVariable, IByteSource
    {
        public CByteArray2(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name)
        {
        }

        public byte[] Bytes { get; set; }

        public override void Read(BinaryReader file, uint size)
        {
            var arraysize = file.ReadUInt32();
            Bytes = file.ReadBytes((int) arraysize - 4);
        }

        public override void Write(BinaryWriter file)
        {
            file.Write((uint) Bytes.Length + 4);
            file.Write(Bytes);
        }

        public override CVariable SetValue(object val)
        {
            if (val is byte[])
            {
                Bytes = (byte[]) val;
            }
            else if (val is CByteArray2 cvar)
            {
                this.Bytes = cvar.Bytes;
            }

            return this;
        }

        public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name)
        {
            return new CByteArray2(cr2w, parent, name);
        }

        public override CVariable Copy(CR2WCopyAction context)
        {
            var var = (CByteArray2) base.Copy(context);
            var newbytes = new byte[Bytes.Length];
            Bytes.CopyTo(newbytes, 0);
            var.Bytes = newbytes;
            return var;
        }

        public override Control GetEditor()
        {
            var editor = new ByteArrayEditor();
            editor.Variable = this;
            return editor;
        }

        public override string ToString()
        {
            return Bytes.Length + " bytes";
        }
        public override void SerializeToXml(XmlWriter xw)
        {
            DataContractSerializer ser = new DataContractSerializer(this.GetType());
            using (var ms = new MemoryStream())
            {
                ser.WriteStartObject(xw, this);
                ser.WriteObjectContent(xw, this);
                xw.WriteElementString("Length", Bytes.Length.ToString());
                if (Bytes.Length > 0)
                {
                    xw.WriteElementString("Bytes", HexStr(Bytes));
                }
                ser.WriteEndObject(xw);
            }
        }

    }
}