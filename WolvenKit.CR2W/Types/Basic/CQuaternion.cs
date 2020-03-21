﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Editors;

namespace WolvenKit.CR2W.Types
{
    [DataContract(Namespace = "")]
    public class CQuaternion : CVariable
    {
        public string type = "CQuaternion";
        public CFloat x, y, z, w;

        public CQuaternion(CR2WFile cr2w = null)
            : base(cr2w)
        {
            x = new CFloat(null) { Name = "x", Type = "Float" };
            y = new CFloat(null) { Name = "y", Type = "Float" };
            z = new CFloat(null) { Name = "z", Type = "Float" };
            w = new CFloat(null) { Name = "w", Type = "Float" };
        }

        public override void Read(BinaryReader file, uint size)
        {
            x.Read(file, size);
            y.Read(file, size);
            z.Read(file, size);
            w.Read(file, size);
        }

        public override void Write(BinaryWriter file)
        {
            x.Write(file);
            y.Write(file);
            z.Write(file);
            w.Write(file);
        }

        public override CVariable SetValue(object val)
        {
            return this;
        }

        public override CVariable Create(CR2WFile cr2w)
        {
            return new CQuaternion(cr2w);
        }

        public override CVariable Copy(CR2WCopyAction context)
        {
            var var = (CQuaternion)base.Copy(context);
            var.type = type;
            var.x.val = x.val;
            var.y.val = y.val;
            var.z.val = z.val;
            var.w.val = w.val;
            return var;
        }

        public override List<IEditableVariable> GetEditableVariables()
        {
            var vars = new List<IEditableVariable>()
            {
                x,
                y,
                z,
                w
            };
            return vars;
        }

        public override string ToString()
        {
            return String.Format(CultureInfo.InvariantCulture, "V4[{0:0.00}, {1:0.00}, {2:0.00}, {3:0.00}]", x.val, y.val, z.val, w.val);
        }
    }
}