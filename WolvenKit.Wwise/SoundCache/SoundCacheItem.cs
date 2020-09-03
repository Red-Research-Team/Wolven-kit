﻿using System.IO;
using System.IO.MemoryMappedFiles;
using WolvenKit.Common;
using WolvenKit.Common.Model;

namespace WolvenKit.Wwise.SoundCache
{
    public class SoundCacheItem : IWitcherFile
    {
        public IWitcherArchive Bundle { get; set; }
        /// <summary>
        /// Name of the bundled item in the archive.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Name of the cache file this file is in. (Needed for Extracting the file)
        /// </summary>
        public string ParentFile;


        public long NameOffset;
        public long PageOffset { get; set; }
        public long Size { get; set; }
        public uint ZSize { get; set; }

        public SoundCacheItem(IWitcherArchive Parent)
        {
            this.Bundle = Parent;
        }

        public string CompressionType => "None";

        public void Extract(Stream output)
        {
            using (var file = MemoryMappedFile.CreateFromFile(this.ParentFile, FileMode.Open))
            {
                using (var viewstream = file.CreateViewStream(PageOffset, Size, MemoryMappedFileAccess.Read))
                {
                    viewstream.CopyTo(output);
                }
            }
        }

        public string Extract(BundleFileExtractArgs e)
        {
            // create new directory and delete existing file
            Directory.CreateDirectory(Path.GetDirectoryName(e.FileName) ?? "");
            if (File.Exists(e.FileName))
                File.Delete(e.FileName);

            using (var output = new FileStream(e.FileName, FileMode.Create, FileAccess.Write))
            {
                Extract(output);
                output.Close();
            }

            return e.FileName;
        }
    }
}
