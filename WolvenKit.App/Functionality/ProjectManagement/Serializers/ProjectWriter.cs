using System.Threading.Tasks;
using Catel;
using Catel.Threading;
using Orc.FileSystem;
using Orc.ProjectManagement;
using WolvenKit.MVVM.Model.ProjectManagement.Project;

namespace WolvenKit.MVVM.Model.ProjectManagement.Serializers
{
    public class ProjectWriter : ProjectWriterBase<EditorProject>
    {
        #region Fields

        private readonly IFileService _fileService;

        #endregion Fields

        #region Constructors

        public ProjectWriter(IFileService fileService)
        {
            Argument.IsNotNull(() => fileService);

            _fileService = fileService;
        }

        #endregion Constructors

        #region Methods

        protected override Task<bool> WriteToLocationAsync(EditorProject project, string location)
        {
            project.Save(location);
            return TaskHelper<bool>.FromResult(true);
        }

        #endregion Methods
    }
}
