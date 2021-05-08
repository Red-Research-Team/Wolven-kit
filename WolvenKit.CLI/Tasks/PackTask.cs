using System.IO;
using System.Threading.Tasks;
using CP77.CR2W;
using WolvenKit.Common;
using WolvenKit.Common.Services;

namespace CP77Tools.Tasks
{
    public partial class ConsoleFunctions
    {
        #region Methods

        /// <summary>
        /// Packs a folder or list of folders to .archive files.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="outpath"></param>
        public void PackTask(string[] path, string outpath)
        {
            if (path == null || path.Length < 1)
            {
                _loggerService.LogString("Please fill in an input path.", Logtype.Error);
                return;
            }

            Parallel.ForEach(path, file =>
            {
                PackTaskInner(file, outpath);
            });
        }

        private void PackTaskInner(string path, string outpath, int cp = 0)
        {
            #region checks

            if (string.IsNullOrEmpty(path))
            {
                _loggerService.LogString("Please fill in an input path.", Logtype.Error);
                return;
            }

            var inputDirInfo = new DirectoryInfo(path);
            if (!Directory.Exists(path) || !inputDirInfo.Exists)
            {
                _loggerService.LogString("Input path does not exist.", Logtype.Error);
                return;
            }

            var basedir = inputDirInfo;
            if (basedir?.Parent == null)
            {
                return;
            }

            DirectoryInfo outDir;
            if (string.IsNullOrEmpty(outpath))
            {
                outDir = basedir.Parent;
            }
            else
            {
                outDir = new DirectoryInfo(outpath);
                if (!outDir.Exists)
                {
                    outDir = Directory.CreateDirectory(outpath);
                }
            }

            #endregion checks

            var ar = _modTools.Pack(basedir, outDir);
            if (ar != null)
            {
                _loggerService.LogString($"Finished packing {ar.ArchiveAbsolutePath}.", Logtype.Success);
            }
            else
            {
                _loggerService.LogString($"Packing failed.", Logtype.Error);
            }

            return;
        }

        #endregion Methods
    }
}
