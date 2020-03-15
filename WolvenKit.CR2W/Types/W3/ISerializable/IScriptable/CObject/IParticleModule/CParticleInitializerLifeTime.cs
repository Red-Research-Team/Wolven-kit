﻿using System.Collections.Generic;
using System.IO;
using WolvenKit.CR2W.Editors;
using System.Diagnostics;
using System;
using System.Linq;
using System.Globalization;
using System.Runtime.Serialization;

namespace WolvenKit.CR2W.Types
{
    [DataContract(Namespace = "")]
    public class CParticleInitializerLifeTime : CVariable
    {
        public CBufferVLQ<CUInt16> alpha;

        public CParticleInitializerLifeTime(CR2WFile cr2w) : base(cr2w)
        {
            alpha = new CBufferVLQ<CUInt16>(cr2w, _ => new CUInt16(_)) { Name = "alpha" };
        }

        public override void Read(BinaryReader file, uint size)
        {
            alpha.Read(file, 2);
        }

        public override void Write(BinaryWriter file)
        {
            alpha.Write(file);
        }

        public override CVariable SetValue(object val)
        {
            return this;
        }

        public override CVariable Create(CR2WFile cr2w)
        {
            return new CParticleInitializerLifeTime(cr2w);
        }

        public override CVariable Copy(CR2WCopyAction context)
        {
            var var = (CParticleInitializerLifeTime)base.Copy(context);

            var.alpha = (CBufferVLQ<CUInt16>)alpha.Copy(context);

            return var;
        }

        public override List<IEditableVariable> GetEditableVariables()
        {
            return new List<IEditableVariable>()
            {
                alpha,
            };
        }

        public override string ToString()
        {
            return $"";
        }
    }
}