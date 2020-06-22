﻿using System.Collections.Generic;
using System.IO;
using WolvenKit.CR2W.Editors;
using System.Diagnostics;
using System;
using System.Linq;
using System.Globalization;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;

namespace WolvenKit.CR2W.Types
{
    [REDMeta(EREDMetaInfo.REDStruct)]
    public class SSkeletonRigData : CVariable
    {
        [RED] public SVector4D Position { get; set; }
        [RED] public SVector4D Rotation { get; set; }
        [RED] public SVector4D Scale { get; set; }

        public SSkeletonRigData(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name)
        {

        }



        public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name)
        {
            return new SSkeletonRigData(cr2w, parent, name);
        }


        public override string ToString()
        {
            return $"[{Position.ToString()}, {Rotation.ToString()}, {Scale.ToString()}]";
        }
    }
}