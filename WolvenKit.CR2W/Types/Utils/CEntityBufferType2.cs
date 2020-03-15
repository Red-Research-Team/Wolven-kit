﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WolvenKit.CR2W.Editors;

namespace WolvenKit.CR2W.Types.Utils
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract(Namespace = "")]
    public class CEntityBufferType2 : CVariable
    {
        public CName componentName;
        public CUInt32 sizeofdata;
        public CBufferUInt32<CVariableWrapper> variables;


        public CEntityBufferType2(CR2WFile cr2w) : base(cr2w)
        {
            componentName = new CName(cr2w)
            {
                Name = "Name",
            };
            sizeofdata = new CUInt32(cr2w)
            {
                Name = "Size",
            };
            variables = new CBufferUInt32<CVariableWrapper>(cr2w, _ => new CVariableWrapper(_));

        }

        public override CVariable Create(CR2WFile cr2w)
        {
            return new CEntityBufferType2(cr2w);
        }

        public override void Read(BinaryReader file, uint size)
        {
            sizeofdata.Read(file, 4);
            componentName.Read(file, 2);
            variables.Read(file, size);
        }

        public override void Write(BinaryWriter file)
        {

            sizeofdata.val =  4; // 4 for the uint32 varsize
            byte[] buffer;

            // use a temporary stream to write the variables and get the overall length of the component
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                componentName.Write(bw);
                variables.Write(file);

                sizeofdata.val += (UInt32)ms.Length;
                buffer = ms.ToArray();
            }

            sizeofdata.Write(file);
            file.Write(buffer);
        }

        public override string ToString()
        {
            return componentName.Value;
        }

        public override CVariable Copy(CR2WCopyAction context)
        {
            var var = (CEntityBufferType2)base.Copy(context);

            var.componentName = (CName)componentName.Copy(context);
            var.sizeofdata = (CUInt32)sizeofdata.Copy(context);
            var.variables = (CBufferUInt32<CVariableWrapper>)variables.Copy(context);

            return var;
        }

        public override List<IEditableVariable> GetEditableVariables()
        {
            var editableVars = new List<IEditableVariable>()
            {
                componentName,
                sizeofdata,
                variables
            };

            return editableVars;
        }

    }
}
