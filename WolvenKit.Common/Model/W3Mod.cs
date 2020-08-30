﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using WolvenKit.Common.Model;

namespace WolvenKit.Common
{
    public class W3Mod : ICloneable
    {
        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public string ProjectDirectory => Path.Combine(Path.GetDirectoryName(FileName), Name);

        #region Directories
        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public string FileDirectory
        {
            get
            {
                var dir = Path.Combine(ProjectDirectory, "files");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                return dir;
            }
        }

        #region Top-level Dirs
        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public string ModDirectory
        {
            get
            {
                var dir = Path.Combine(FileDirectory, "Mod");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                return dir;
            }
        }

        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public string DlcDirectory
        {
            get
            {
                var dir = Path.Combine(FileDirectory, "DLC");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                return dir;
            }
        }

        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public string RawDirectory
        {
            get
            {
                var dir = Path.Combine(FileDirectory, "Raw");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                return dir;
            }
        }

        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public string TextureDirectory
        {
            get
            {
                if (!Directory.Exists(Path.Combine(ModDirectory, "TextureCache")))
                    Directory.CreateDirectory(Path.Combine(ModDirectory, "TextureCache"));
                return Path.Combine(ModDirectory, "TextureCache");
            }
        }

        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public string RadishDirectory
        {
            get
            {
                var dir = Path.Combine(ProjectDirectory, "files", "Radish");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                return dir;
            }
        }
        #endregion

        #region Mod-level Dirs
        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public string ModUncookedDirectory
        {
            get
            {
                if (!Directory.Exists(Path.Combine(ModDirectory, EProjectFolders.Uncooked.ToString())))
                    Directory.CreateDirectory(Path.Combine(ModDirectory, EProjectFolders.Uncooked.ToString()));
                return Path.Combine(ModDirectory, EProjectFolders.Uncooked.ToString());
            }
        }
        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public string ModCookedDirectory
        {
            get
            {
                if (!Directory.Exists(Path.Combine(ModDirectory, EProjectFolders.Cooked.ToString())))
                    Directory.CreateDirectory(Path.Combine(ModDirectory, EProjectFolders.Cooked.ToString()));
                return Path.Combine(ModDirectory, EProjectFolders.Cooked.ToString());
            }
        }
        #endregion

        #region DLC-level Dirs
        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public string DlcUncookedDirectory
        {
            get
            {
                if (!Directory.Exists(Path.Combine(DlcDirectory, EProjectFolders.Uncooked.ToString())))
                    Directory.CreateDirectory(Path.Combine(DlcDirectory, EProjectFolders.Uncooked.ToString()));
                return Path.Combine(DlcDirectory, EProjectFolders.Uncooked.ToString());
            }
        }
        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public string DlcCookedDirectory
        {
            get
            {
                if (!Directory.Exists(Path.Combine(DlcDirectory, EProjectFolders.Cooked.ToString())))
                    Directory.CreateDirectory(Path.Combine(DlcDirectory, EProjectFolders.Cooked.ToString()));
                return Path.Combine(DlcDirectory, EProjectFolders.Cooked.ToString());
            }
        }
        #endregion

        #region Cooked and Packed Directories
        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public string CookedModDirectory
        {
            get
            {
                var dir = Path.Combine(ProjectDirectory, "cooked", "Mods", $"mod{Name}", "content");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                return dir;
            }
        }
        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public string PackedModDirectory
        {
            get
            {
                var dir = Path.Combine(ProjectDirectory, "packed", "Mods", $"mod{Name}", "content");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                return dir;
            }
        }
        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public string CookedDlcDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(GetDLCName()))
                {
                    return null;
                }
                var dir = Path.Combine(ProjectDirectory, "cooked", "DLC", GetDLCName(), "content");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                return dir;
            }
        }
        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public string PackedDlcDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(GetDLCName()))
                {
                    return null;
                }
                var dir = Path.Combine(ProjectDirectory, "packed", "DLC", GetDLCName(), "content");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                return dir;
            }
        }
        #endregion
        #endregion

        #region Files
        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public List<string> Files
        {
            get
            {
                if (!Directory.Exists(FileDirectory))
                {
                    Directory.CreateDirectory(FileDirectory);
                }
                return Directory.EnumerateFiles(FileDirectory, "*", SearchOption.AllDirectories).Select(file => file.Substring(FileDirectory.Length + 1)).ToList();
            }
        }

        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public List<string> ModFiles
        {
            get
            {
                if (!Directory.Exists(ModDirectory))
                {
                    Directory.CreateDirectory(ModDirectory);
                }
                return Directory.EnumerateFiles(ModDirectory, "*", SearchOption.AllDirectories).Select(file => file.Substring(ModDirectory.Length + 1)).ToList();
            }
        }

        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public List<string> DLCFiles
        {
            get
            {
                if (!Directory.Exists(DlcDirectory))
                {
                    Directory.CreateDirectory(DlcDirectory);
                }
                return Directory.EnumerateFiles(DlcDirectory, "*", SearchOption.AllDirectories).Select(file => file.Substring(DlcDirectory.Length + 1)).ToList();
            }
        }

        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public List<string> RawFiles
        {
            get
            {
                if (!Directory.Exists(RawDirectory))
                {
                    Directory.CreateDirectory(RawDirectory);
                }
                return Directory.EnumerateFiles(RawDirectory, "*", SearchOption.AllDirectories).Select(file => file.Substring(RawDirectory.Length + 1)).ToList();
            }
        }

        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public List<string> RadishFiles
        {
            get
            {
                if (!Directory.Exists(RadishDirectory))
                {
                    Directory.CreateDirectory(RadishDirectory);
                }
                return Directory.EnumerateFiles(RadishDirectory, "*", SearchOption.AllDirectories).Select(file => file.Substring(RadishDirectory.Length + 1)).ToList();
            }
        }
        #endregion


        [Browsable(false)] 
        public List<string> LastOpenedFiles;


        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public string FileName { get; set; }

        [Category("About")]
        [Description("The name of your mod.")]
        public string Name { get; set; }
        [Category("About")]
        [Description("The version of your mod. It's a string so 0.1-ALPHA and such is possible.")]
        public string Version { get; set; } = "0.62";

        public object Clone()
        {
            var clone = new W3Mod();
            clone.Name = Name;
            clone.FileName = FileName;
            //clone.Version = Version;
            clone.LastOpenedFiles = LastOpenedFiles;
            return clone;
        }

        public void CreateDefaultDirectories()
        {
            

            // create top-level directories
            _ = ModDirectory;
            _ = DlcDirectory;
            _ = RawDirectory;
            _ = RadishDirectory;

            // create mod-level directories
            //_ = ModTextureCacheDirectory;
            _ = ModUncookedDirectory;
            _ = ModCookedDirectory;

            // create dlc-level directories
            //_ = DlcTextureCacheDirectory;
            _ = DlcUncookedDirectory;
            _ = DlcCookedDirectory;
        }


        /// <summary>
        /// Returns the first folder name in the ActiveMod/dlc directory
        /// Does not support multiple DLC
        /// </summary>
        /// <returns></returns>
        public string GetDLCName()
        {
            string dlcname = "";
            try
            {
                if (Directory.Exists(Path.Combine(DlcCookedDirectory, "dlc")))
                {
                    if (Directory.GetDirectories(Path.Combine(DlcCookedDirectory, "dlc")).Any())
                        return (new DirectoryInfo(Directory.GetDirectories(Path.Combine(DlcCookedDirectory, "dlc")).First())).Name;

                }
                else if (Directory.Exists(Path.Combine(DlcUncookedDirectory, "dlc")))
                {
                    if (Directory.GetDirectories(Path.Combine(DlcUncookedDirectory, "dlc")).Any())
                        return (new DirectoryInfo(Directory.GetDirectories(Path.Combine(DlcUncookedDirectory, "dlc")).First())).Name;
                }
            }
            catch (Exception)
            {
            }
            return dlcname;
        }

        /// <summary>
        /// Returns the first raltive folder path in the ActiveMod/dlc directory
        /// Does not support multiple DLC
        /// </summary>
        /// <returns></returns>
        public string GetDLCRelativePath()
        {
            string relpath = "";
            try
            {
                if (Directory.Exists(Path.Combine(DlcCookedDirectory, "dlc")))
                {
                    if (Directory.GetDirectories(Path.Combine(DlcCookedDirectory, "dlc")).Any())
                    {
                        relpath = (new DirectoryInfo(Directory.GetDirectories(Path.Combine(DlcCookedDirectory, "dlc")).First())).FullName;
                        return relpath.Substring(DlcCookedDirectory.Length + 1);
                    }

                }
                else if (Directory.Exists(Path.Combine(DlcUncookedDirectory, "dlc")))
                {
                    if (Directory.GetDirectories(Path.Combine(DlcUncookedDirectory, "dlc")).Any())
                    {
                        relpath = (new DirectoryInfo(Directory.GetDirectories(Path.Combine(DlcUncookedDirectory, "dlc")).First())).FullName;
                        return relpath.Substring(DlcUncookedDirectory.Length + 1);
                    }

                }
            }
            catch (Exception)
            {
            }
            return relpath;
        }

    }
}