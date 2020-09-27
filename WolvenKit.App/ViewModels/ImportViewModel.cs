﻿using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WolvenKit.App.Commands;
using WolvenKit.App.Model;
using WolvenKit.Common;
using WolvenKit.Common.Model;
using WolvenKit.Common.Services;
using WolvenKit.Common.Tools;
using WolvenKit.Common.Wcc;
using WolvenKit.CR2W;
using WolvenKit.CR2W.Types;
using WolvenKit.DDS;
using static WolvenKit.CR2W.Types.Enums;
using static WolvenKit.DDS.TexconvWrapper;

namespace WolvenKit.App.ViewModels
{
    public class ImportViewModel : ViewModel
    {
        

        public ImportViewModel()
        {
            Logger = MainController.Get().Logger;


            UseLocalResourcesCommand = new RelayCommand(UseLocalResources, CanUseLocalResources);
            OpenFolderCommand = new RelayCommand(OpenFolder, CanOpenFolder);
            TryGetTextureGroupsCommand = new RelayCommand(TryGetTextureGroups, CanTryGetTextureGroups);
            ImportCommand = new RelayCommand(Import, CanImport);

            Importableobjects = new BindingList<ImportableFile>();
            Importableobjects.ListChanged += new ListChangedEventHandler(Importableobjects_ListChanged);

            // on start use mod files
            UseLocalResourcesCommand.SafeExecute();
        }

        #region Fields
        private readonly List<string> importableexts = Enum.GetNames(typeof(EImportable)).Select(_ => $".{_}".ToLower()).ToList();
        private readonly LoggerService Logger;
        
        private DirectoryInfo importdepot;
        #endregion

        void Importableobjects_ListChanged(object sender, ListChangedEventArgs e) => OnPropertyChanged(nameof(Importableobjects));

        #region Properties
        #region SelectedItem
        private BindingList<ImportableFile> _importableobjects = null;
        public BindingList<ImportableFile> Importableobjects
        {
            get => _importableobjects;
            set
            {
                if (_importableobjects != value)
                {
                    _importableobjects = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        public bool UseWolvenKitImport { get; set; }

        #endregion

        #region Commands
        public ICommand UseLocalResourcesCommand { get; }
        public ICommand OpenFolderCommand { get; }
        public ICommand TryGetTextureGroupsCommand { get; }
        public ICommand ImportCommand { get; }
        #endregion

        #region Commands Implementation

        private bool CanUseLocalResources() => MainController.Get().ActiveMod != null;

        private void UseLocalResources()
        {
            var importablefiles = new List<string>();
            foreach (var file in MainController.Get().ActiveMod.Files)
            {
                var originalExt = Path.GetExtension(file);
                var lowerExt = originalExt.ToLower();
                if (importableexts.Contains(lowerExt))
                {
                    if (originalExt != lowerExt)
                    {
                        // rename file first because wcc can't handle uppercase file extensions
                        var oldpath = Path.Combine(MainController.Get().ActiveMod.FileDirectory, file);
                        var newpath = Path.ChangeExtension(oldpath, lowerExt);
                        File.Move(oldpath, newpath);
                    }

                    importablefiles.Add(Path.ChangeExtension(file, lowerExt));
                }

            }
            AddObjects(importablefiles, MainController.Get().ActiveMod.FileDirectory);

            TryGetTextureGroupsCommand.SafeExecute();
        }

        private bool CanOpenFolder() => MainController.Get().ActiveMod != null;

        private void OpenFolder()
        {
            
        }

        private bool CanTryGetTextureGroups() => Importableobjects != null;

        private void TryGetTextureGroups()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, MainController.XBMDumpPath);
            using (var fr = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var sr = new StreamReader(fr))
            using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<XBMDump>();
                var recordsl = csv.GetRecords<XBMDump>().ToList();

                foreach (var importable in Importableobjects)
                {
                    // check for non-texture files
                    if (importable.GetImportableType() != EImportable.bmp &&
                        //importable.GetImportableType() != EImportable.dds &&
                        importable.GetImportableType() != EImportable.jpg &&
                        importable.GetImportableType() != EImportable.png &&
                        importable.GetImportableType() != EImportable.tga
                        )
                        continue;

                    // try getting texture group from vanilla files
                    try
                    {
                        string xbmfullpath = Path.ChangeExtension(importable.GetRelativePath(), "xbm");
                        var xpath = xbmfullpath.Split(Path.DirectorySeparatorChar).Last();

                        var foundrecords = recordsl.FirstOrDefault(_ => _.RedName.Contains(xpath));
                        if (foundrecords != null)
                        {
                            string stxtgroup = foundrecords.TextureGroup;
                            ETextureGroup etxtgroup = (ETextureGroup)Enum.Parse(typeof(ETextureGroup), stxtgroup);
                            importable.TextureGroup = etxtgroup;

                            importable.SetState(ImportableFile.EObjectState.Ready);
                            importable.IsSelected = true;
                        }
                        else
                            importable.SetState(ImportableFile.EObjectState.NoTextureGroup);
                    }
                    catch (Exception)
                    {
                        importable.SetState(ImportableFile.EObjectState.Error);
                    }
                }
            }
        }

        private bool CanImport() => Importableobjects != null;

        private async void Import()
        {
            var filesToImport = Importableobjects.Where(_ => _.IsSelected).ToList();
            var ActiveMod = MainController.Get().ActiveMod;

            foreach (var file in filesToImport)
            {
                if (file.GetState() != ImportableFile.EObjectState.Ready)
                    continue;

                var fullpath = Path.Combine(importdepot.FullName, file.GetRelativePath());
                if (!File.Exists(fullpath))
                    return;

                string importext = $".{file.ImportType:G}";
                if (UseWolvenKitImport && importext == ".xbm")
                {
                    // experimental: import with wkit
                    var cr2w = CreateCr2wXbmFromImagePath(file);
                    if (cr2w != null)
                    {
                        var exNewpath = $"{GetNewPath(file)}";
                        // create directory
                        EnsureFolderExists(exNewpath);
                        using (var fs = new FileStream(exNewpath, FileMode.Create, FileAccess.ReadWrite))
                        using (var writer = new BinaryWriter(fs))
                        {
                            cr2w.Write(writer);
                            MainController.LogString($"Succesfully imported file {fullpath}.", Logtype.Success);
                        }
                    }
                    else
                        MainController.LogString($"Could not import file {fullpath}.", Logtype.Error);
                }
                else
                {
                    // import with wcc_lite
                    try
                    {
                        await StartImport(file);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
               

                

                // https://stackoverflow.com/a/3695190
                void EnsureFolderExists(string path)
                {
                    string directoryName = Path.GetDirectoryName(path);
                    // If path is a file name only, directory name will be an empty string
                    if (!string.IsNullOrWhiteSpace(directoryName))
                    {
                        // Create all directories on the path that don't already exist
                        Directory.CreateDirectory(directoryName);
                    }
                }
            }

            async Task StartImport(ImportableFile file)
            {
                var relPath = file.GetRelativePath();
                var newpath = GetNewPath(file);
                var filepath = Path.Combine(importdepot.FullName, relPath);

                var import = new Wcc_lite.import()
                {
                    File = filepath,
                    Out = newpath,
                    Depot = MainController.Get().Configuration.DepotPath,
                    texturegroup = file.TextureGroup
                };
                await Task.Run(() => MainController.Get().WccHelper.RunCommand(import));
            }

            string GetNewPath(ImportableFile file)
            {
                var relPath = file.GetRelativePath();
                string importext = $".{file.ImportType:G}";
                string rawext = $".{file.GetImportableType():G}";

                // make new path
                // first, trim Raw from the path
                if (relPath.Substring(0, 3) == "Raw")
                    relPath = relPath.Substring(4);
                // then, trim Mod or dlc from the path
                bool isDLC = false;
                if (relPath.Substring(0, 3) == "Mod")
                {
                    relPath = relPath.Substring(4);
                }
                if (relPath.Substring(0, 3) == "DLC")
                {
                    isDLC = true;
                    relPath = relPath.Substring(4);
                }

                // new path with new extension
                relPath = Path.ChangeExtension(relPath, importext);
                var newpath = isDLC ? Path.Combine(ActiveMod.DlcUncookedDirectory, relPath) : Path.Combine(ActiveMod.ModUncookedDirectory, relPath);

                return newpath;
            }
        }
        #endregion

        private CR2WFile CreateCr2wXbmFromImagePath(ImportableFile file)
        {
            var fullpath = Path.Combine(importdepot.FullName, file.GetRelativePath());

            // experimental: create uncooked xbm
            var compression = ImageUtility.GetTextureCompressionFromTextureGroup(file.TextureGroup);
            var tg = file.TextureGroup.ToString();

            // create mipmaps with texconv?
            // create a temporary dds
            var tempdir = MainController.WorkDir;
            var textureformat = ImageUtility.GetEFormatFromCompression(compression);
            var ddsfile = TexconvWrapper.Convert(tempdir, fullpath, EUncookExtension.dds, textureformat);

            if (!File.Exists(ddsfile)) throw new NotImplementedException();
            var metadata = DDSUtils.ReadHeader(ddsfile);
            var width = metadata.Width;
            var height = metadata.Height;

            // create cr2wfile
            var cr2w = new CR2WFile();
            var xbm = new CBitmapTexture(cr2w, null, "CBitmapTexture");
            xbm.Width = new CUInt32(cr2w, xbm, "width") { val = width, IsSerialized = true };
            xbm.Height = new CUInt32(cr2w, xbm, "height") { val = height, IsSerialized = true };
            xbm.Compression = new CEnum<ETextureCompression>(cr2w, xbm, "compression")
                { WrappedEnum = compression, IsSerialized = true };
            xbm.TextureGroup = new CName(cr2w, xbm, "textureGroup") { Value = tg, IsSerialized = true };
            xbm.unk = new CUInt32(cr2w, xbm, "unk") { val = 0, IsSerialized = true };
            xbm.unk1 = new CUInt16(cr2w, xbm, "unk1") { val = 512, IsSerialized = true }; //TODO: find out what that is
            xbm.unk2 = new CUInt16(cr2w, xbm, "unk2") { val = 768, IsSerialized = true }; //TODO: find out what that is

            // read the mips
            // check if not a power of 2
            if (height % 2 != 0)
            {
                MainController.LogString("Height is not a power of 2. Please resize your image.", Logtype.Error);
                return null;
            }

            // funkiest way to calculate log2, the length of the bit array is also the number of mipmaps
            // height = 1024 = 2^10 = 11 mipmaps
            string b = System.Convert.ToString(Math.Max(height, width), 2);
            int mipcount = b.Length;

            xbm.Mipdata = new CCompressedBuffer<SMipData>(cr2w, xbm, "Mipdata") { IsSerialized = true };
            using (var fs = new FileStream(ddsfile, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fs))
            {
                // skip dds header
                fs.Seek(128, SeekOrigin.Begin);

                var mipsizeH = height;
                var mipsizeW = width;
                // read data here
                for (int i = 0; i < mipcount; i++)
                {
                    
                    var buffer = reader.ReadBytes((int)GetMipMapSize(mipsizeW, mipsizeH, textureformat));

                    var mipdata = new SMipData(cr2w, xbm.Mipdata, $"{i}") { IsSerialized = true };
                    mipdata.Height = new CUInt32(cr2w, mipdata, $"Height") { IsSerialized = true, val = mipsizeH};
                    mipdata.Width = new CUInt32(cr2w, mipdata, $"Width") { IsSerialized = true, val = mipsizeW };
                    mipdata.Blocksize = new CUInt32(cr2w, mipdata, $"Blocksize") { IsSerialized = true, val = GetBlockSize(mipsizeW, textureformat) };
                    mipdata.Mip = new CByteArray(cr2w, mipdata, $"Mip") { IsSerialized = true, Bytes = buffer };

                    xbm.Mipdata.AddVariable(mipdata);

                    mipsizeH = Math.Max(4, mipsizeH / 2);
                    mipsizeW = Math.Max(4, mipsizeW / 2);
                }

            }

            // residentmips


            cr2w.FromCResource(xbm);

            return cr2w;

            uint GetMipMapSize(uint _width, uint _height, EFormat _textureformat)
            {
                switch (_textureformat)
                {
                    case EFormat.BC1_UNORM:
                    case EFormat.BC4_UNORM:
                        return Math.Max(1, (_height / 4)) * Math.Max(1, (_width / 4)) * 8;
                    case EFormat.BC2_UNORM:
                    case EFormat.BC3_UNORM:
                    case EFormat.BC5_UNORM:
                        return Math.Max(1, (_height / 4)) * Math.Max(1, (_width / 4)) * 16;
                    //case EFormat.R32G32B32A32_FLOAT:
                    //case EFormat.R16G16B16A16_FLOAT:
                    //case EFormat.BC6H_UF16:
                    case EFormat.R8G8B8A8_UNORM:
                    case EFormat.BC7_UNORM:
                    default:
                        throw new ArgumentOutOfRangeException(nameof(_textureformat), _textureformat, null);
                }
            }

            uint GetBlockSize(uint _width, EFormat _textureformat)
            {
                switch (_textureformat)
                {
                    case EFormat.BC1_UNORM:
                    case EFormat.BC4_UNORM:
                        return Math.Max(1, (_width / 4)) * 8;
                    case EFormat.BC2_UNORM:
                    case EFormat.BC3_UNORM:
                    case EFormat.BC5_UNORM:
                        return Math.Max(1, (_width / 4)) * 16;
                    //case EFormat.R32G32B32A32_FLOAT:
                    //case EFormat.R16G16B16A16_FLOAT:
                    //case EFormat.BC6H_UF16:
                    case EFormat.R8G8B8A8_UNORM:
                    case EFormat.BC7_UNORM:
                    default:
                        throw new MissingFormatException($"Missing Format: {_textureformat}");
                }
            }
        }

        #region Methods
        public void AddObjects(List<string> importablefiles, string dirpath)
        {
            Importableobjects.Clear();
            importdepot = new DirectoryInfo(dirpath);
            //List<ImportableFile> filestoAdd = new List<ImportableFile>();
            foreach (var f in importablefiles)
            {
                string ext = Path.GetExtension(f);
                EImportable type = (EImportable)Enum.Parse(typeof(EImportable), ext.TrimStart('.').ToLower());

                var importableobj = new ImportableFile(
                    f,
                    type,
                    REDTypes.RawExtensionToEnum(ext)
                    );

                // non-texture imports are ready by default (no texture group must be set)
                if (importableobj.GetImportableType() == EImportable.apb ||
                    importableobj.GetImportableType() == EImportable.fbx ||
                    importableobj.GetImportableType() == EImportable.nxs
                    )
                {
                    importableobj.SetState(ImportableFile.EObjectState.Ready);
                    importableobj.IsSelected = true;
                }

                if (!Importableobjects.Contains(importableobj))
                    Importableobjects.Add(importableobj);
                else
                {

                }
            }
        }
        #endregion

    }
}
