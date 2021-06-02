using System.IO;
using WolvenKit.Common;
using WolvenKit.Common.DDS;
using WolvenKit.Common.Services;

namespace CP77.CR2W
{
    /// <summary>
    /// Collection of common modding utilities.
    /// </summary>
    public partial class ModTools
    {
        #region Methods

        /// <summary>
        /// Exports (Uncooks) a REDEngine file into it's raw counterpart
        /// </summary>
        /// <param name="cr2wfile"></param>
        /// <param name="outpath"></param>
        public bool Export(FileInfo cr2wfile, EUncookExtension uncookext = EUncookExtension.dds, bool flip = false)
        {
            #region checks

            if (cr2wfile == null)
            {
                return false;
            }

            if (!cr2wfile.Exists)
            {
                return false;
            }

            if (cr2wfile.Directory is {Exists: false})
            {
                return false;
            }

            var ext = Path.GetExtension(cr2wfile.FullName)[1..];

            #endregion checks

            // read file
            using var fs = new FileStream(cr2wfile.FullName, FileMode.Open, FileAccess.Read);
            using var br = new BinaryReader(fs);

            return Uncook(fs, cr2wfile, ext, uncookext, flip);
        }

        #endregion Methods
    }
}
