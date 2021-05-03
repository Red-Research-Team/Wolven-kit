using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP77.CR2W;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ProtoBuf;
using ProtoBuf.Meta;
using WolvenKit.CLI.MSTests;
using WolvenKit.Common;
using WolvenKit.RED4.CR2W.Archive;

namespace CP77.MSTests
{
    [TestClass]
    public class ArchiveTests : GameUnitTest
    {
        public enum Serialization
        {
            Json,
            NewtonsoftJson,
            Protobuf,
            Zeroformatting
        }

        [ClassInitialize]
        public static void SetupClass(TestContext context) => Setup(context);

        #region Methods

        [TestMethod]
        public void Test_Unbundle()
        {
            var resultDir = Path.Combine(Environment.CurrentDirectory, s_testResultsDirectory);
            Directory.CreateDirectory(resultDir);

            var totalCount = s_bm.Items.Count();
            var results = new ConcurrentBag<ArchiveTestResult>();

            Parallel.ForEach(s_bm.Archives, file =>
            {
                var archivename = file.Key;
                var archive = file.Value as Archive;
                Parallel.ForEach(archive.Files, keyvalue =>
                {
                    var (hash, _) = keyvalue;
                    var ms = new MemoryStream();
                    try
                    {
                        ModTools.ExtractSingleToStream(archive, hash, ms);
                        results.Add(new ArchiveTestResult()
                        {
                            ArchiveName = archivename,
                            Hash = hash.ToString(),
                            Success = true
                        });
                    }
                    catch (Exception e)
                    {
                        results.Add(new ArchiveTestResult()
                        {
                            ArchiveName = archivename,
                            Hash = hash.ToString(),
                            Success = false,
                            ExceptionType = e.GetType(),
                            Message = $"{e.Message}"
                        });
                    }
                });
            });

            // Check success
            var successCount = results.Count(r => r.Success);
            var sb = new StringBuilder();
            sb.AppendLine(
                $"Successfully unbundled: {successCount} / {totalCount} ({(int)(successCount / (double)totalCount * 100)}%)");
            var success = results.All(r => r.Success);
            if (success)
            {
                return;
            }

            var msg = $"Successful Writes: {successCount} / {totalCount}. ";
            Assert.Fail(msg);
        }

        [TestMethod]
        public void Test_Uncook()
        {
            
        }

        [TestMethod]
        //[DataRow(Serialization.NewtonsoftJson)]
        //[DataRow(Serialization.Zeroformatting)]
        [DataRow(Serialization.Protobuf)]
        public void Test_Serialization(Serialization method)
        {
            var resultDir = Path.Combine(Environment.CurrentDirectory, s_testResultsDirectory);
            switch (method)
            {
                
                case Serialization.NewtonsoftJson:
                {
                    var chachePath = Path.Combine(resultDir, "archive_cache.json");
                    //using var fs = new FileStream(chachePath, FileMode.Create);
                    File.WriteAllText(chachePath, JsonConvert.SerializeObject(s_bm, Formatting.None, new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                        TypeNameHandling = TypeNameHandling.Auto
                    }));
                    break;
                }
                case Serialization.Zeroformatting:
                {
                    //var chachePath = Path.Combine(resultDir, "archive_cache.zero");
                    //using var fs = new FileStream(chachePath, FileMode.Create);
                    //ZeroFormatterSerializer.Serialize(fs, s_bm);
                    break;
                }
                case Serialization.Json:
                    break;
                case Serialization.Protobuf:
                {
                    var chachePath = Path.Combine(resultDir, "archive_cache.bin");
                    using var file = File.Create(chachePath);
                    Serializer.Serialize(file, s_bm);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(method), method, null);
            }
        }
        
        [TestMethod]
        //[DataRow(Serialization.NewtonsoftJson)]
        //[DataRow(Serialization.Zeroformatting)]
        [DataRow(Serialization.Protobuf)]
        public void Test_Deserialization(Serialization method)
        {
            var resultDir = Path.Combine(Environment.CurrentDirectory, s_testResultsDirectory);
            switch (method)
            {

                case Serialization.NewtonsoftJson:
                {
                    var chachePath = Path.Combine(resultDir, "archive_cache.json");
                    using var file = File.OpenText(chachePath);
                    var serializer = new JsonSerializer
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                        TypeNameHandling = TypeNameHandling.Auto
                    };
                    var x = (ArchiveManager)serializer.Deserialize(file, typeof(ArchiveManager));
                    break;
                }
                case Serialization.Zeroformatting:
                {
                    //var chachePath = Path.Combine(resultDir, "archive_cache.zero");
                    //using var fs = new FileStream(chachePath, FileMode.Open);
                    //var x = ZeroFormatterSerializer.Deserialize<ArchiveManager>(fs);
                    break;
                }
                case Serialization.Json:
                    break;
                case Serialization.Protobuf:
                {
                    var chachePath = Path.Combine(resultDir, "archive_cache.bin");
                    using var file = File.OpenRead(chachePath);
                    var x = Serializer.Deserialize<ArchiveManager>(file);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(method), method, null);
            }
        }

        #endregion Methods
    }
}
