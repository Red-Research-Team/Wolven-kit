﻿//using RED.CRC32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WolvenKit.CR2W.Editors;
using WolvenKit.CR2W.Types;
using System.Runtime.InteropServices;
//using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using WolvenKit.Utils;

[assembly: ContractNamespaceAttribute("",    ClrNamespace = "WolvenKit.CR2W")]

namespace WolvenKit.CR2W
{

    [DataContract(Namespace ="")]
    [StructLayout(LayoutKind.Explicit, Size = 24)]
    public struct CR2WExport
    {
        [DataMember]
        [FieldOffset(0)]
        public ushort className; //needs to be registered upon new creation!

        [DataMember]
        [FieldOffset(2)]
        public ushort objectFlags;  // can be 0

        [DataMember]
        [FieldOffset(4)]
        public uint parentID;   //needs to be registered upon new creation!

        [DataMember]
        [FieldOffset(8)]
        public uint dataSize;   // created upon data write

        [DataMember]
        [FieldOffset(12)]
        public uint dataOffset; //created upon data write

        [DataMember]
        [FieldOffset(16)]
        public uint template;   // can be 0

        [DataMember]
        [FieldOffset(20)]
        public uint crc32;  // created upon write
    }

    [DataContract(Namespace = "")]
    public class CR2WExportWrapper : IEditableVariable
    {

        #region  Constructors
        public CR2WExportWrapper(CR2WFile file)
        {
            this.cr2w = file;

            parentPtr = new CPtr(file)
            {
                Name = "Parent"
            };

            flags = new CUInt16(file)
            {
                Name = "Flags"
            };

            typeName = new CName(file)
            {
                Name = "Type"
            };

            Flags = 8192;
            _export.objectFlags = 8192;
        }
        public CR2WExportWrapper(CR2WFile file, CR2WExport export)
        {
            this.cr2w = file;
            _export = export;

            parentPtr = new CPtr(file)
            {
                Name = "Parent"
            };
            ParentChunkId = export.parentID;

            flags = new CUInt16(file)
            {
                Name = "Flags",
                val = export.objectFlags
            };

            typeName = new CName(file)
            {
                Name = "Type",
                val = export.className
            };

        }

        public CVariable CreateDefaultVariable()
        {
            return null;
        }
        #endregion

        #region Properties
        private CR2WExport _export ;
        [DataMember()]
        public CR2WExport Export {
            get => _export;
            set => _export = value;
        }

        [NonSerialized]
        public CR2WFile cr2w;
        public CVariable data;
        [NonSerialized]
        public CName typeName;
        [NonSerialized]
        public CBytes unknownBytes;
        /*public ushort typeId
        {
            get { return typeName.val; }
            set { typeName.val = value; }
        }*/
        private readonly CUInt16 flags;
        [DataMember]
        public ushort Flags
        {
            get { return flags.val; }
            set { flags.val = value; }
        }
        private readonly CPtr parentPtr;
        [DataMember]
        public uint ParentChunkId
        {
            get { return (uint) parentPtr.val; }
            set
            {
                parentPtr.val = (int) value;
                _export.parentID = value;
            }
        }

        public CR2WExportWrapper Parent
        {
            get
            {
                try
                {
                    return cr2w.chunks[(int)ParentChunkId - 1];
                }
                catch (Exception)
                {
                    return null;
                }
                
            }
        }

        public int ChunkIndex => cr2w.chunks.IndexOf(this);

        public string Preview
        {
            get
            {
                if (data is CVector)
                {
                    var firstString = ((CVector) data).GetVariableByType("String");
                    if (firstString != null)
                    {
                        return ((CString) firstString).val;
                    }

                    var firstName = ((CVector) data).GetVariableByType("CName");
                    if (firstName != null)
                    {
                        return ((CName) firstName).Value;
                    }
                }

                return "";
            }
        }

        [DataMember]
        public string Type
        {
            get {return typeName.Value; }
            set
            {
                typeName.Value = value;
                _export.className = (ushort)cr2w.GetStringIndex(typeName.Value);
            }
        }

        public void SetExportType(ushort val)
        {
            _export.className = val;
        }
        public void SetParentChunk(uint val)
        {
            _export.parentID = val;
        }

        [DataMember]
        public string Name
        {
            get { return Type + " #" + (ChunkIndex + 1); }
            set { }
        }

        public CR2WFile CR2WOwner => cr2w;
        #endregion

        #region Methods
        public void SetOffset(uint offset) => _export.dataOffset = offset;
        public virtual Control GetEditor()
        {
            return null;
        }

        public virtual List<IEditableVariable> GetEditableVariables()
        {
            data.Name = Name;

            var vars = new List<IEditableVariable> {flags, parentPtr, typeName, data};
            if (unknownBytes != null)
            {
                vars.Add(unknownBytes);
            }
            return vars;
        }

        public virtual bool CanRemoveVariable(IEditableVariable child)
        {
            return false;
        }

        public virtual bool CanAddVariable(IEditableVariable newvar)
        {
            return false;
        }

        public virtual void AddVariable(CVariable var)
        {
        }

        public virtual void RemoveVariable(IEditableVariable child)
        {
        }

        public void ReadData(BinaryReader file)
        {
            file.BaseStream.Seek(_export.dataOffset, SeekOrigin.Begin);

            CreateDefaultData();

            data.Read(file, _export.dataSize);

            var bytesLeft = _export.dataSize - (file.BaseStream.Position - _export.dataOffset);

            unknownBytes = new CBytes(cr2w)
            {
                Name = "unknownBytes",
                Type = "byte[]"
            };

            if (bytesLeft > 0)
            {
                unknownBytes.Read(file, (uint) bytesLeft);
            }
            else if (bytesLeft < 0)
            {
                throw new InvalidParsingException("File read too far.");
            }
            else
            {
                unknownBytes.Bytes = new byte[0];
            }
        }

        public void WriteData(BinaryWriter file)
        {
            _export.dataOffset = (uint) file.BaseStream.Position;

            var posstart = file.BaseStream.Position;

            if (data != null)
            {
                data.Write(file);
            }

            // Unknown bytes not as variable because I always want it at the end.
            if (unknownBytes != null)
            {
                unknownBytes.Write(file);
            }

            var newsize = (uint) (file.BaseStream.Position - posstart);
            if (_export.dataSize != newsize)
            {
                _export.dataSize = newsize;
            }
        }

        public void CreateDefaultData()
        {
            data = CR2WTypeManager.Get().GetByName(Type, "", cr2w, false);
            if (data == null)
            {
                // default chunks to vector type
                data = new CVector(cr2w);
            }
            data.Name = Name;
        }

        public CR2WExportWrapper Copy(CR2WCopyAction context)
        {
            // this one was already copied
            if (context.chunkTranslation.ContainsKey(ChunkIndex))
                return null;


            var chunk = context.DestinationFile.CreateChunk(Type);

            context.chunks.Add(chunk);
            context.chunkTranslation.Add(ChunkIndex, chunk.ChunkIndex);

            chunk.Type = Type;
            chunk.Flags = Flags;
            chunk._export.template = _export.template;
            chunk._export.crc32 = _export.crc32;

            // requires updating from context.chunkTranslation once all chunks are copied.
            chunk.ParentChunkId = ParentChunkId;

            if (data != null)
            {
                chunk.data = (CVector) data.Copy(context);
            }
            if (unknownBytes != null)
            {
                chunk.unknownBytes = (CBytes) unknownBytes.Copy(context);
            }

            return chunk;
        }

        public void SerializeToXml(XmlWriter xw)
        {
            XmlSerializer.SerializeStartObject<CR2WExportWrapper>(xw, this);
            XmlSerializer.SerializeObjectContent<CR2WExportWrapper>(xw, this);
            data.SerializeToXml(xw);
            unknownBytes.SerializeToXml(xw);
            XmlSerializer.SerializeEndObject<CR2WExportWrapper>(xw);
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}