using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using WolvenKit.Functionality.WKitGlobal.Helpers;

namespace WolvenKit.Functionality.Services
{
    public interface ISettingsDto
    {
        #region Properties

        bool CheckForUpdates { get; set; }

        string TextLanguage { get; set; }

        string ThemeAccentString { get; set; }

        EAnimals CatFactAnimal { get; set; }

        string[] ManagerVersions { get; set; }

        string DepotPath { get; set; }

        // red 4

        string CP77ExecutablePath { get; set; }

        // red 3

        string W3ExecutablePath { get; set; }

        string WccLitePath { get; set; }

        #endregion Properties

    }

    public interface ISettingsManager : ISettingsDto
    {
        // This is here because Catel can't expose inherited Properties ¯\_(ツ)_/¯
        // and we use this in the first set up viewmodels
        bool ShowGuidedTour { get; set; }

        public ImageBrush ProfileImageBrush { get; set; }

        string MaterialRepositoryPath { get; set; }


        #region Methods

        string GetW3GameContentDir();
        string GetW3GameDlcDir();
        string GetW3GameModDir();
        string GetW3GameRootDir();


        string GetRED4GameRootDir();
        string GetRED4GameModDir();

        string GetOodleDll();
        string GetRED4OodleDll();

        #region Properties

        public static string GetWolvenkitAppData()
        {
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "REDModding",
                "WolvenKit");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        public static string GetManagerCacheDir()
        {
            var dir = Path.Combine(GetWolvenkitAppData(), "Config");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        public static string GetWorkDir()
        {
            var dir = Path.Combine(GetWolvenkitAppData(), "tmp_workdir");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        public static string GetXBMDumpPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "__xbmdump_3768555366.csv");
        }

        public static string GetTemp_AudioPath()
        {
            var dir = Path.Combine(GetWolvenkitAppData(), "Temp_Audio");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        public static string GetTemp_OBJPath()
        {
            var dir = Path.Combine(GetWolvenkitAppData(), "Temp_OBJ");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        public static string GetTemp_MeshPath()
        {
            var dir = Path.Combine(GetWolvenkitAppData(), "Temp_Mesh");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        public static string GetTemp_Audio_importPath()
        {
            var dir = Path.Combine(GetWolvenkitAppData(), "Temp_Audio_import");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        public static string GetWebViewDataPath()
        {
            var dir = Path.Combine(GetWolvenkitAppData(), "WebViewData");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        public ImageBrush ProfileImageBrush { get; set; }

        string MaterialRepositoryPath { get; set; }


        string GetW3GameContentDir();

        string GetW3GameDlcDir();

        string GetW3GameModDir();

        string GetW3GameRootDir();

        string GetRED4GameRootDir();

        string GetRED4GameModDir();

        #region Properties

        public static string GetWolvenkitAppData()
        {
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "REDModding",
                "WolvenKit");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        public static string GetManagerCacheDir()
        {
            var dir = Path.Combine(GetWolvenkitAppData(), "Config");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        public static string GetWorkDir()
        {
            var dir = Path.Combine(GetWolvenkitAppData(), "tmp_workdir");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        public static string GetXBMDumpPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "__xbmdump_3768555366.csv");
        }

        public static string GetTemp_AudioPath()
        {
            var dir = Path.Combine(GetWolvenkitAppData(), "Temp_Audio");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        public static string GetTemp_OBJPath()
        {
            var dir = Path.Combine(GetWolvenkitAppData(), "Temp_OBJ");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        public static string GetTemp_MeshPath()
        {
            var dir = Path.Combine(GetWolvenkitAppData(), "Temp_Mesh");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        public static string GetTemp_Audio_importPath()
        {
            var dir = Path.Combine(GetWolvenkitAppData(), "Temp_Audio_import");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        public static string GetTemp_Video_PreviewPath()
        {
            var dir = Path.Combine(GetWolvenkitAppData(), "Temp_Video_Preview");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        public static string GetWebViewDataPath()
        {
            var dir = Path.Combine(GetWolvenkitAppData(), "WebViewData");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        #endregion Properties

        void Save();

        #endregion Methods

        Color GetThemeAccent();
        void SetThemeAccent(Color color);

        string GetVersionNumber();
        List<string> IsHealthy();

    }
}
