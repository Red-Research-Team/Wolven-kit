﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using WolvenKit.CR2W.Editors;
using WolvenKit.CR2W.Reflection;

namespace WolvenKit.CR2W.Types
{
    [REDMeta(EREDMetaInfo.REDStruct)]
    public class CXml : CVariable
    {
        public CXml(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name)
        {
        }

        public XDocument Data { get; set; }

        private byte[] dbg_original_data;

        public override void Read(BinaryReader file, uint size)
        {
            var len = file.ReadInt32();
            var byteso = file.ReadBytes(len);


            using (var ms = new MemoryStream(byteso))
            {
                Data = new XDocument(XDocument.Load(ms));
            }

            dbg_original_data = byteso;

            var dbg_written_data1 = Encoding.ASCII.GetBytes(Data.ToString());
            var dbg_written_data2 = Encoding.Default.GetBytes(Data.ToString());
            var dbg_written_data3 = Encoding.UTF8.GetBytes(Data.ToString());
            var dbg_written_data4 = Encoding.Unicode.GetBytes(Data.ToString());
        }

        public override void Write(BinaryWriter file)
        {


            file.Write(Data.ToString().Length);
            file.Write(Encoding.ASCII.GetBytes(Data.ToString()));
        }

        public override CVariable SetValue(object val)
        {
            if (val is XDocument)
            {
                Data = (XDocument) val;
            }
            return this;
        }

        public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name)
        {
            return new CXml(cr2w, parent, name);
        }

        public override CVariable Copy(CR2WCopyAction context)
        {
            var var = (CXml) base.Copy(context);
            var.Data = new XDocument(Data);
            return var;
        }

        public override Control GetEditor()
        {
            var editor = new Panel();
            var exportbutton = new Button();
            exportbutton.Text = "Export";
            exportbutton.Click += (sender, args) =>
            {
                using (var sf = new SaveFileDialog()
                {
                    Filter = "XML Files | *.xml",
                    Title = "Select a place to save the xml file!"
                })
                {
                    if (sf.ShowDialog() == DialogResult.OK)
                    {
                        Data.Save(sf.FileName);
                    }
                }
            };
            editor.Controls.Add(exportbutton);
            var importbutton = new Button();
            exportbutton.Text = "Import";
            exportbutton.Click += (sender, args) =>
            {
                using (var of = new OpenFileDialog()
                {
                    Filter = "XML Files | *.xml",
                    Title = "Please select the file you would like to import!"
                })
                {
                    if (of.ShowDialog() == DialogResult.OK)
                    {
                        Data = new XDocument(File.ReadAllText(of.FileName));
                    }
                }
            };
            editor.Controls.Add(exportbutton);
            editor.PerformLayout();
            return editor;
        }

        public override string ToString()
        {
            return Data.ToString().Length + " chars";
        }

        public override void SerializeToXml(XmlWriter xw)
        {
            DataContractSerializer ser = new DataContractSerializer(this.GetType());
            using (var ms = new MemoryStream())
            {
                ser.WriteStartObject(xw, this);
                ser.WriteObjectContent(xw, this);
                xw.WriteStartElement("XMLData");
                Data.Save(xw);
                xw.WriteEndElement();
                ser.WriteEndObject(xw);
            }

        }
    }
}
