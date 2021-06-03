using System;
using System.IO;
using System.Linq;
using WolvenKit.RED4.CR2W.Types;
using WolvenKit.Common;
using WolvenKit.Common.DDS;
using WolvenKit.Common.Model.Arguments;
using WolvenKit.RED4.CR2W;

namespace CP77.CR2W
{
    /// <summary>
    /// Collection of common modding utilities.
    /// </summary>
    public partial class ModTools
    {
        /// <summary>
        /// Imports a raw File to a RedEngine file (e.g. .dds to .xbm, .fbx to .mesh)
        /// </summary>
        /// <param name="rawFile"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public CR2WFile Import(FileInfo rawFile, ImportArgs args)
        {
            #region checks
            if (rawFile == null)
            {
                return null;
            }

            if (!rawFile.Exists)
            {
                return null;
            }

            if (rawFile.Directory is {Exists: false})
            {
                return null;
            }

            if (!Enum.GetNames(typeof(ERawFileFormat)).Contains(rawFile.Extension[1..]))
            {
                return null;
            }

            if (!Enum.TryParse(rawFile.Extension, out ERawFileFormat rawFileFormat))
            {
                return null;
            }
            
            #endregion

            switch (rawFileFormat)
            {
                case ERawFileFormat.tga:
                case ERawFileFormat.dds:
                    return ImportXbm(rawFile);
                case ERawFileFormat.fbx:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException($"Import fbx");
            }
        }

        private CR2WFile ImportXbm(FileInfo rawFile, string textureGroup = null)
        {
            var rawExt = rawFile.Extension;
            // TODO: do this in a working directory?
            var ddsPath = Path.ChangeExtension(rawFile.FullName, "dds");
            // convert to dds if not already
            if (rawExt != "dds")
            {
                try
                {
                    if (ddsPath.Length > 255)
                    {
                        _loggerService.Error($"{ddsPath} - Path length exceeds 255 chars. Please move the archive to a directory with a shorter path.");
                        return null;
                    }
                    TexconvWrapper.Convert(rawFile.Directory.FullName, $"{ddsPath}", EUncookExtension.dds);
                }
                catch (Exception)
                {
                    //TODO: proper exception handling
                    return null;
                }

                if (!File.Exists(ddsPath))
                {
                    return null;
                }
            }

            // read dds metadata
            var metadata = DDSUtils.ReadHeader(ddsPath);
            var width = metadata.Width;
            var height = metadata.Height;







            // create cr2wfile
            var cr2w = new CR2WFile();
            // create xbm chunk
            var xbm = new CBitmapTexture(cr2w, null, "CBitmapTexture");
            xbm.Width = new CUInt32(cr2w, xbm, "width") { Value = width, IsSerialized = true };
            xbm.Height = new CUInt32(cr2w, xbm, "height") { Value = height, IsSerialized = true };
            xbm.CookingPlatform = new CEnum<Enums.ECookingPlatform>(cr2w, xbm, "cookingPlatform"){ Value = Enums.ECookingPlatform.PLATFORM_PC, IsSerialized = true };
            xbm.Setup = new STextureGroupSetup(cr2w, xbm, "setup")
            {
                IsSerialized = true
            };
            SetTextureGroupSetup();



            // populate with dds metadata



            // kraken ddsfile
            // remove dds header

            // compress file

            // append to cr2wfile

            // update cr2w headers

            throw new NotImplementedException();


            #region local functions

            void SetTextureGroupSetup()
            {
                // first check the user-texture group
                if (!string.IsNullOrEmpty(textureGroup))
                {
                    if (Enum.TryParse(textureGroup, out Enums.GpuWrapApieTextureGroup eTextureGroup))
                    {
                        var (compression, rawformat, flags) = CommonFunctions.GetRedFormatsFromTextureGroup(eTextureGroup);
                        xbm.Setup.Group = new CEnum<Enums.GpuWrapApieTextureGroup>(cr2w, xbm, "group")
                        {
                            IsSerialized = true,
                            Value = eTextureGroup
                        };
                        if (flags is CommonFunctions.ETexGroupFlags.Both or CommonFunctions.ETexGroupFlags.CompressionOnly)
                        {
                            xbm.Setup.Compression = new CEnum<Enums.ETextureCompression>(cr2w, xbm, "setup")
                            {
                                IsSerialized = true,
                                Value = compression
                            };
                        }

                        if (flags is CommonFunctions.ETexGroupFlags.Both or CommonFunctions.ETexGroupFlags.RawFormatOnly)
                        {
                            xbm.Setup.RawFormat = new CEnum<Enums.ETextureRawFormat>(cr2w, xbm, "rawFormat")
                            {
                                IsSerialized = true,
                                Value = rawformat
                            };
                        }

                        return;
                    }
                }

                // if that didn't work, interpret the filename suffix
                if (string.IsNullOrEmpty(textureGroup) && rawFile.Name.Contains('_'))
                {
                    // try interpret suffix
                    switch (rawFile.Name.Split('_').Last())
                    {
                        case "d":
                        case "d01":

                            break;
                        case "e":

                            break;
                        case "r":
                        case "r01":

                            break;
                        default:
                            break;
                    }
                }

                // if that also didn't work, just use default or skip
                //TODO
            }

            #endregion

        }
    }
}
