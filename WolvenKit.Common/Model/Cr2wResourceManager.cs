﻿using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WolvenKit.Common.FNV1A;
using WolvenKit.Common.Model;

namespace WolvenKit.Common.Model
{
    public class Cr2wResourceManager
    {
        private static Cr2wResourceManager resourceManager;
        public Dictionary<string, ulong> HashdumpDict { get; set; }
        public Dictionary<string, ulong> CHashdumpDict { get; set; }

        public const string pathashespath = "ManagerCache\\pathhashes.csv";
        public const string custompathashespath = "ManagerCache\\custompathhashes.csv";


        public static Cr2wResourceManager Get()
        {
            if (resourceManager == null)
            {
                resourceManager = new Cr2wResourceManager();
            }
            return resourceManager;
        }

        public Cr2wResourceManager()
        {
            HashdumpDict = new Dictionary<string, ulong>();
            CHashdumpDict = new Dictionary<string, ulong>();

            if (File.Exists(pathashespath))
            {
                using (StreamReader reader = File.OpenText(pathashespath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    HashdumpDict = csv.GetRecords<HashDump>().ToDictionary(_ => _.Path, _ => _.HashInt);
                }
            }

            if (File.Exists(custompathashespath))
            {
                using (StreamReader reader = File.OpenText(custompathashespath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    CHashdumpDict = csv.GetRecords<HashDump>().ToDictionary(_ => _.Path, _ => _.HashInt);
                }
            }
        }

        public void RegisterAndWriteVanillaPaths(List<string> paths)
        {
            foreach (var path in paths)
            {
                RegisterVanillaPath(path);
            }
            Write();
        }
        public ulong RegisterVanillaPath(string path)
        {
            var hashint = FNV1A64HashAlgorithm.HashString(path);
            if (!HashdumpDict.ContainsKey(path))
                HashdumpDict.Add(path, hashint);
            return hashint;
        }

        public ulong RegisterAndWriteCustomPath(string path)
        {
            var hash = RegisterCustomPath(path);
            Write();
            return hash;
        }
        public void RegisterAndWriteCustomPaths(List<string> paths)
        {
            foreach (var path in paths)
            {
                RegisterCustomPath(path);
            }
            Write();
        }
        public ulong RegisterCustomPath(string path)
        {
            var hashint = FNV1A64HashAlgorithm.HashString(path);
            if (!CHashdumpDict.ContainsKey(path) && !HashdumpDict.ContainsKey(path))
                CHashdumpDict.Add(path, hashint);
            return hashint;
        }

        public void Write()
        {
            using (var writer = new StreamWriter(custompathashespath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(CHashdumpDict.Select(_ => new HashDump { Path = _.Key, HashInt = _.Value }));
            }
        }
        public void WriteVanilla()
        {
            using (var writer = new StreamWriter(pathashespath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(HashdumpDict.Select(_ => new HashDump { Path = _.Key, HashInt = _.Value }));
            }
        }

    }
}
