using System;
using System.IO;
using WolvenKit.Common;


namespace WolvenKit.MVVM.Model.ProjectManagement.Project
{
    public sealed class Cp77Project : EditorProject, ICloneable
    {

        public Cp77Project(string location) : base(location)
        {
        }

        private Cp77Project() : base("")
        {
        }

        public override GameType GameType => GameType.Cyberpunk2077;

        public override string PackedModDirectory
        {
            get
            {
                var dir = Path.Combine(ProjectDirectory, "packed", "archive", "pc", "mod", $"mod{Name}");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                return dir;
            }
        }

        public override string PackedRootDirectory
        {
            get
            {
                var dir = Path.Combine(ProjectDirectory, "packed");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                return dir;
            }
        }


        #region methods

        //public string GetDlcName() => $"dlc{Name}";

        public void CreateDefaultDirectories()
        {
            // create top-level directories
            _ = ModDirectory;
            _ = RawDirectory;
        }

        public object Clone()
        {
            var clone = new Cp77Project()
            {
                Name = Name,
                Author = Author,
                Email = Email,
                Version = Version,
                Location = Location
            };
            return clone;
        }

        public override string ToString() => Location;

        #endregion methods
    }
}
