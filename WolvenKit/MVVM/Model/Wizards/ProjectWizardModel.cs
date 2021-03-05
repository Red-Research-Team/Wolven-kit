using Catel.Data;

namespace WolvenKit.MVVM.Model.Wizards
{
    /// <summary>
    /// Keeps track of which game was selected by the user during setting up a project.
    /// </summary>
    public class ProjectWizardModel : ModelBase
    {
        #region fields

        private bool _cyberpunkGameChecked = true;
        private string _projectName = "";
        private string _projectPath = "";
        private bool _witcherGameChecked = false;

        #endregion fields

        #region properties

        public static string CyberpunkGameName { get; } = "Cyberpunk 2077";
        public static string WitcherGameName { get; } = "The Witcher 3";

        /// <summary>
        /// Gets/Sets the project's path.
        /// </summary>
        public bool CyberpunkChecked
        {
            get => _cyberpunkGameChecked;
            set
            {
                _cyberpunkGameChecked = value;
                RaisePropertyChanged(nameof(CyberpunkChecked));
            }
        }

        /// <summary>
		/// Gets/Sets the project name.
		/// </summary>
		public string ProjectName
        {
            get => _projectName;
            set             // This can also be set by the user via the view
            {
                _projectName = value;
                RaisePropertyChanged(nameof(ProjectName));
            }
        }

        /// <summary>
        /// Gets/Sets the project path.
        /// </summary>
        public string ProjectPath
        {
            get => _projectPath;
            set             // This can also be set by the user via the view
            {
                _projectPath = value;
                RaisePropertyChanged(nameof(ProjectPath));
            }
        }

        /// <summary>
        /// Gets/Sets the project's type.
        /// </summary>
        public string ProjectType => CyberpunkChecked ? CyberpunkGameName : (WitcherChecked ? WitcherGameName : "");

        /// <summary>
        /// Gets/Sets the project's type and path.
        /// </summary>
        public TypeAndPath ProjectTypeAndPath => new TypeAndPath(ProjectType, ProjectPath, ProjectName);

        /// <summary>
        /// Gets/Sets the project's name.
        /// </summary>
        public bool WitcherChecked
        {
            get => _witcherGameChecked;
            set
            {
                _witcherGameChecked = value;
                RaisePropertyChanged(nameof(WitcherChecked));
            }
        }

        #endregion properties

        #region Classes

        public class TypeAndPath
        {
            #region Fields

            public string Name;
            public string Path;
            public string Type;

            #endregion Fields

            #region Constructors

            public TypeAndPath(string type, string path, string name)
            {
                Type = type;
                Path = path;
                Name = name;
            }

            #endregion Constructors
        }

        #endregion Classes
    }
}
