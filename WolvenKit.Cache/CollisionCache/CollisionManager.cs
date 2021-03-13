using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WolvenKit.Common;

namespace WolvenKit.Cache
{
    public class CollisionManager : WitcherArchiveManager
    {
        #region Constructors

        public CollisionManager()
        {
            Items = new Dictionary<string, List<IGameFile>>();
            Archives = new Dictionary<string, CollisionCache>();
            FileList = new List<IGameFile>();
            Extensions = new List<string>();
            AutocompleteSource = new List<string>();
        }

        #endregion Constructors

        #region Properties

        public static string SerializationVersion => "1.0";
        public Dictionary<string, CollisionCache> Archives { get; set; }
        public override EArchiveType TypeName => EArchiveType.CollisionCache;

        #endregion Properties

        #region Methods

        /// <summary>
        ///     Load every non-mod bundle it can find in ..\\..\\content and ..\\..\\DLC, also calls RebuildRootNode()
        /// </summary>
        /// <param name="exedir">Path to executable directory</param>
        public override void LoadAll(string exedir)
        {
            var di = new DirectoryInfo(exedir);
            if (!di.Exists)
                return;
            var dlc = Path.Combine(di.Parent.Parent.FullName, "DLC");
            var content = Path.Combine(di.Parent.Parent.FullName, "content");

            var contentdirs = new List<string>(Directory.GetDirectories(content, "content*"));
            contentdirs.Sort(new AlphanumComparator<string>());
            foreach (var file in contentdirs.SelectMany(dir => Directory.GetFiles(dir, "*.cache", SearchOption.AllDirectories).Where(x => Cache.GetCacheTypeOfFile(x) == Cache.Cachetype.Collision)))
            {
                LoadArchive(file);
            }

            var patchdirs = new List<string>(Directory.GetDirectories(content, "patch*"));
            patchdirs.Sort(new AlphanumComparator<string>());
            foreach (var file in patchdirs
                .SelectMany(dir => Directory.GetFiles(dir, "*.cache", SearchOption.AllDirectories)
                    .Where(x => Cache.GetCacheTypeOfFile(x) == Cache.Cachetype.Collision)))
            {
                LoadArchive(file);
            }

            if (Directory.Exists(dlc))
            {
                var dlcdirs = new List<string>(Directory.GetDirectories(dlc));
                dlcdirs.Sort(new AlphanumComparator<string>());

                foreach (var file in dlcdirs
                    .Where(_ => VanillaDlClist.Contains(new DirectoryInfo(_).Name))
                    .SelectMany(dir => Directory.GetFiles(dir ?? "", "*.cache", SearchOption.AllDirectories)
                        .OrderBy(k => k)
                        .Where(x => Cache.GetCacheTypeOfFile(x) == Cache.Cachetype.Collision)))
                {
                    LoadArchive(file);
                }
            }
            RebuildRootNode();
        }

        /// <summary>
        ///     Load a single collision cache
        /// </summary>
        /// <param name="filename"></param>
        public override void LoadArchive(string filename, bool ispatch = false)
        {
            if (Archives.ContainsKey(filename))
                return;

            var bundle = new CollisionCache(filename);

            foreach (var item in bundle.Files)
            {
                if (!Items.ContainsKey(item.Name))
                    Items.Add(item.Name, new List<IGameFile>());

                Items[item.Name].Add(item);
            }

            Archives.Add(filename, bundle);
        }

        /// <summary>
        ///     Load a single mod collision cache
        /// </summary>
        /// <param name="filename"></param>
        public override void LoadModArchive(string filename)
        {
            if (Archives.ContainsKey(filename))
                return;

            var bundle = new CollisionCache(filename);

            foreach (var item in bundle.Files)
            {
                if (!Items.ContainsKey(GetModFolder(filename) + "\\" + item.Name))
                    Items.Add(GetModFolder(filename) + "\\" + item.Name, new List<IGameFile>());

                Items[GetModFolder(filename) + "\\" + item.Name].Add(item);
            }

            Archives.Add(filename, bundle);
        }

        /// <summary>
        /// Loads the .cache files from the /Mods/ folder
        /// Note this resets everything
        /// </summary>
        /// <param name="exedir"></param>
        public override void LoadModsArchives(string mods, string dlc)
        {
            if (!Directory.Exists(mods))
                Directory.CreateDirectory(mods);
            var modsdirs = new List<string>(Directory.GetDirectories(mods));
            modsdirs.Sort(new AlphanumComparator<string>());
            var modbundles = modsdirs.SelectMany(dir => Directory.GetFiles(dir, "*.cache", SearchOption.AllDirectories).Where(x => Cache.GetCacheTypeOfFile(x) == Cache.Cachetype.Collision)).ToList();
            foreach (var file in modbundles)
            {
                LoadModArchive(file);
            }

            if (Directory.Exists(dlc))
            {
                var dlcdirs = new List<string>(Directory.GetDirectories(dlc));
                dlcdirs.Sort(new AlphanumComparator<string>());

                var tmp = dlcdirs.Where(_ => !VanillaDlClist.Contains(new DirectoryInfo(_).Name)).ToList();
                foreach (var file in tmp
                    .SelectMany(dir => Directory.GetFiles(dir ?? "", "*.bundle", SearchOption.AllDirectories)
                        .OrderBy(k => k)
                        .Where(x => Cache.GetCacheTypeOfFile(x) == Cache.Cachetype.Collision)))
                {
                    LoadModArchive(file);
                }
            }
            RebuildRootNode();
        }

        #endregion Methods
    }
}
