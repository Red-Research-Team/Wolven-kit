﻿using System.Collections.Generic;
using System.IO;
using WolvenKit.CR2W.Editors;
using System.Diagnostics;
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Globalization;
using WolvenKit.Common.Model;
using System.Reflection;

namespace WolvenKit.CR2W.Types
{
    [DataContract(Namespace = "")]
    public class CSectorDataResource : CVariable
    {
        public CFloat box0;
        public CFloat box1;
        public CFloat box2;
        public CFloat box3;
        public CFloat box4;
        public CFloat box5;
        //public CUInt64 patchHash;
        public CString pathHash;

        public CSectorDataResource(CR2WFile cr2w)
            : base(cr2w)
        {
            box0 = new CFloat(cr2w) { Name = "box0", Type = "Float" };
            box1 = new CFloat(cr2w) { Name = "box1", Type = "Float" };
            box2 = new CFloat(cr2w) { Name = "box2", Type = "Float" };
            box3 = new CFloat(cr2w) { Name = "box3", Type = "Float" };
            box4 = new CFloat(cr2w) { Name = "box4", Type = "Float" };
            box5 = new CFloat(cr2w) { Name = "box5", Type = "Float" };
            pathHash = new CString(cr2w) { Name = "pathHash" };
        }

        public override CVariable Create(CR2WFile cr2w)
        {
            return new CSectorDataResource(cr2w);
        }

        public override void Read(BinaryReader file, uint size)
        {
            box0.Read(file, 4);
            box1.Read(file, 4);
            box2.Read(file, 4);
            box3.Read(file, 4);
            box4.Read(file, 4);
            box5.Read(file, 4);
            UInt64 hashint = file.ReadUInt64();

            // here for now until maincontroller is in Wkit.Common
            if (hashint == 0)
                pathHash.val = "";
            else
            {
                // check for vanilla hashed paths
                if (Cr2wResourceManager.Get().HashdumpDict.ContainsValue(hashint))
                    pathHash.val = Cr2wResourceManager.Get().HashdumpDict.First(_ => _.Value == hashint).Key;
                else
                {
                    // check for custom hashed paths
                    if (Cr2wResourceManager.Get().CHashdumpDict.ContainsValue(hashint))
                        pathHash.val = Cr2wResourceManager.Get().CHashdumpDict.First(_ => _.Value == hashint).Key;
                    else
                        pathHash.val = $"#{hashint}";
                }
            }
        }

        public override void Write(BinaryWriter file)
        {
            box0.Write(file);
            box1.Write(file);
            box2.Write(file);
            box3.Write(file);
            box4.Write(file);
            box5.Write(file);

            // here for now until maincontroller is in Wkit.Common
            ulong hashint = 0;
            // awkward test for unrecognized custom hashes
            if (string.IsNullOrEmpty(pathHash.val))
                hashint = 0;
            else if (pathHash.val[0] == '#')
            {
                hashint = ulong.Parse(pathHash.val.TrimStart('#'));
            }
            else
            {
                //check if in game depot hashes
                if (Cr2wResourceManager.Get().HashdumpDict.ContainsKey(pathHash.val))
                    hashint = Cr2wResourceManager.Get().HashdumpDict[pathHash.val];
                else
                {
                    //check if in local custom hashes
                    if (Cr2wResourceManager.Get().CHashdumpDict.ContainsKey(pathHash.val))
                        hashint = Cr2wResourceManager.Get().CHashdumpDict[pathHash.val];
                    //hash new path and add to collection
                    else
                        hashint = Cr2wResourceManager.Get().RegisterAndWriteCustomPath(pathHash.val);
                }

            }
            file.Write(hashint);
        }

        public override List<IEditableVariable> GetEditableVariables()
        {
            return new List<IEditableVariable>()
            {
                box0,
                box1,
                box2,
                box3,
                box4,
                box5,
                pathHash,
            };
        }

        public override string ToString()
        {
            return pathHash.ToString();
        }
    }
}