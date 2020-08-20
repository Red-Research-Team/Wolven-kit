﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WolvenKit.Common;
using WolvenKit.Common.Model;

namespace WolvenKit.W3Speech
{
    public class SpeechManager : IWitcherArchive
    {

        public SpeechManager()
        {
            Items = new Dictionary<string, List<IWitcherFile>>();
            Speeches = new Dictionary<string, W3Speech>();
            FileList = new List<IWitcherFile>();
            Extensions = new List<string>();
            AutocompleteSource = new AutoCompleteStringCollection();
        }

        public Dictionary<string, List<IWitcherFile>> Items { get; set; }
        public Dictionary<string, W3Speech> Speeches { get; set; }
        public WitcherTreeNode RootNode { get; set; }
        public List<IWitcherFile> FileList { get; set; }
        public EBundleType TypeName => EBundleType.Speech;
        public List<string> Extensions { get; set; }
        public AutoCompleteStringCollection AutocompleteSource { get; set; }

        /// <summary>
        ///     Load a single mod bundle
        /// </summary>
        /// <param name="filename">
        ///     file to process
        /// </param>
        public void LoadModBundle(string filename)
        {
            if (Speeches.ContainsKey(filename))
                return;

            var speech = Coder.Decode(new W3Speech(filename), new System.IO.BinaryReader(new FileStream(filename, FileMode.Open)));

            foreach (var item in speech.item_infos)
            {
                if (!Items.ContainsKey(GetModFolder(filename) + "\\" + item.Name))
                    Items.Add(GetModFolder(filename) + "\\" + item.Name, new List<IWitcherFile>());

                Items[GetModFolder(filename) + "\\" + item.Name].Add(item);
            }

            Speeches.Add(filename, speech);
        }

        /// <summary>
        ///     Load a single bundle
        /// </summary>
        /// <param name="filename"></param>
        public void LoadBundle(string filename)
        {
            try
            {
                if (Speeches.ContainsKey(filename))
                    return;

                var speech = Coder.Decode(new W3Speech(filename), new System.IO.BinaryReader(new FileStream(filename, FileMode.Open)));

                foreach (var item in speech.item_infos)
                {
                    if (!Items.ContainsKey(item.Name))
                        Items.Add(item.Name, new List<IWitcherFile>());

                    Items[item.Name].Add(item);
                }

                Speeches.Add(filename, speech);
            }
            catch (Exception e)
            {
                //TODO: Log                
            }
        }

        /// <summary>
        ///     Load every non-mod bundle it can find in ..\\..\\content and ..\\..\\DLC, also calls RebuildRootNode()
        /// </summary>
        /// <param name="exedir">Path to executable directory</param>
        public void LoadAll(string exedir)
        {
            var content = Path.Combine(exedir, @"..\..\content\");

            var contentdirs = new List<string>(Directory.GetDirectories(content, "content*"));
            contentdirs.Sort(new AlphanumComparator<string>());
            foreach (var file in contentdirs.SelectMany(dir => Directory.GetFiles(dir, "*.w3speech", SearchOption.AllDirectories)))
            {
                LoadBundle(file);
            }

            var patchdirs = new List<string>(Directory.GetDirectories(content, "patch*"));
            patchdirs.Sort(new AlphanumComparator<string>());
            foreach (var file in patchdirs.SelectMany(dir => Directory.GetFiles(dir, "*.w3speech", SearchOption.AllDirectories)))
            {
                LoadBundle(file);
            }

            var dlc = Path.Combine(exedir, @"..\..\DLC\");
            if (Directory.Exists(dlc))
            {
                var dlcdirs = new List<string>(Directory.GetDirectories(dlc));
                dlcdirs.Sort(new AlphanumComparator<string>());
                foreach (var file in dlcdirs.Where(dir => new Regex("(DLC..)|(DLC.)|(BOB)|(ep.)|(bob)|(EP.)").IsMatch(Path.GetFileName(dir ?? ""))).SelectMany(dir => Directory.GetFiles(dir ?? "", "*.w3speech", SearchOption.AllDirectories).OrderBy(k => k)))
                {
                    LoadBundle(file);
                }
            }
            RebuildRootNode();
        }

        /// <summary>
        /// Loads the .bundle files from the /Mods/ folder
        /// Note this resets everything
        /// </summary>
        /// <param name="exedir"></param>
        public void LoadModsBundles(string exedir)
        {
            var mods = Path.Combine(exedir, @"..\..\Mods\");
            if (!Directory.Exists(mods))
                Directory.CreateDirectory(mods);
            var modsdirs = new List<string>(Directory.GetDirectories(mods));
            modsdirs.Sort(new AlphanumComparator<string>());
            var modbundles = modsdirs.SelectMany(dir => Directory.GetFiles(dir, "*.w3speech", SearchOption.AllDirectories)).ToList();
            foreach (var file in modbundles)
            {
                LoadModBundle(file);
            }

            var dlc = Path.Combine(exedir, @"..\..\DLC\");
            if (Directory.Exists(dlc))
            {
                var dlcdirs = new List<string>(Directory.GetDirectories(dlc));
                dlcdirs.Sort(new AlphanumComparator<string>());
                foreach (var file in dlcdirs.Where(dir => !new Regex("(DLC..)|(DLC.)|(BOB)|(bob)|(EP.)|(ep.)").IsMatch(Path.GetFileName(dir ?? ""))).SelectMany(dir => Directory.GetFiles(dir ?? "", "*.w3speech", SearchOption.AllDirectories).OrderBy(k => k)))
                {
                    LoadModBundle(file);
                }
            }
            RebuildRootNode();
        }

        public static string GetModFolder(string path)
        {
            if (path.Split('\\').Length > 3 && path.Split('\\').Contains("content"))
            {
                return path.Split('\\')[path.Split('\\').ToList().IndexOf(path.Split('\\').FirstOrDefault(x => x == "content")) - 1];
            }
            return path;
        }

        /// <summary>
        ///     Rebuilds the bundle tree structure also rebuilds NOTE: Filelist,autocomplete,extensions
        /// </summary>
        public void RebuildRootNode()
        {
            RootNode = new WitcherTreeNode(EBundleType.Speech);
            RootNode.Name = EBundleType.Speech.ToString();
            foreach (var item in Items)
            {
                var currentNode = RootNode;
                var parts = item.Key.Split('\\');

                for (var i = 0; i < parts.Length - 1; i++)
                {
                    if (!currentNode.Directories.ContainsKey(parts[i]))
                    {
                        var newNode = new WitcherTreeNode
                        {
                            Parent = currentNode,
                            Name = parts[i]
                        };
                        currentNode.Directories.Add(parts[i], newNode);
                        currentNode = newNode;
                    }
                    else
                    {
                        currentNode = currentNode.Directories[parts[i]];
                    }
                }

                currentNode.Files.Add(parts[parts.Length - 1], item.Value);
            }
            RebuildFileList();
            RebuildExtensions();
            RebuildAutoCompleteSource();
        }

        /// <summary>
        /// Calls GetFiles on the rootnode
        /// </summary>
        public void RebuildFileList()
        {
            FileList = GetFiles(RootNode);
        }

        /// <summary>
        /// Gets the avaliable extensions in the files
        /// </summary>
        public void RebuildExtensions()
        {
            foreach (var file in FileList.Where(file => !Extensions.Contains(file.Name.Split('.').Last())))
            {
                Extensions.Add(file.Name.Split('.').Last());
            }
            Extensions.Sort();
        }

        /// <summary>
        /// Gets the distinct filenames from the loaded bundles so they can be used for autocomplete
        /// </summary>
        public void RebuildAutoCompleteSource()
        {
            AutocompleteSource.AddRange(FileList.Select(x => GetFileName(x.Name)).Distinct().ToArray());
        }

        /// <summary>
        /// Deep search for files
        /// </summary>
        /// <param name="mainnode">The rootnode to get the files from</param>
        /// <returns></returns>
        public List<IWitcherFile> GetFiles(WitcherTreeNode mainnode)
        {
            var bundfiles = new List<IWitcherFile>();
            if (mainnode?.Files != null)
            {
                foreach (var wfile in mainnode.Files)
                {
                    bundfiles.AddRange(wfile.Value);
                }
                bundfiles.AddRange(mainnode.Directories.Values.SelectMany(GetFiles));
            }
            return bundfiles;
        }

        /// <summary>
        /// Since File.GetFileName() only works for real paths we need to have this
        /// </summary>
        /// <param name="s">Path/Name of the file</param>
        /// <returns></returns>
        public string GetFileName(string s)
        {
            return s.Contains('\\') ? s.Split('\\').Last() : s;
        }
    }
}
