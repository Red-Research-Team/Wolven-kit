﻿using System.CommandLine;
using System.CommandLine.Invocation;
using CP77Tools.Tasks;
using WolvenKit.Common.DDS;

namespace CP77Tools.Commands
{
    public class UncookCommand : Command
    {
        private new const string Name = "uncook";
        private new const string Description = "Target an archive to uncook files fom.";

        public UncookCommand() : base(Name, Description)
        {
            AddOption(new Option<string[]>(new[] {"--path", "-p"}, "Input path to .archive."));
            AddOption(new Option<string>(new[] {"--outpath", "-o"}, "Output directory to extract files to."));
            AddOption(new Option<string>(new[] {"--pattern", "-w"}, "Use optional search pattern (e.g. *.ink), if both regex and pattern is defined, pattern will be prioritized."));
            AddOption(new Option<string>(new[] {"--regex", "-r"}, "Use optional regex pattern."));
            AddOption(new Option<EUncookExtension>(new[] {"--uext"}, "Format to uncook to (tga, bmp, jpg, png, dds), TGA by default."));
            AddOption(new Option<bool>(new[] { "--flip", "-f" }, "Flip textures vertically (can help with legibility if there's text)."));
            AddOption(new Option<ulong>(new[] {"--hash"}, "Extract single file with a given hash."));

            Handler = CommandHandler.Create<string[], string,
                EUncookExtension, bool, ulong, string, string>(ConsoleFunctions.UncookTask);
        }
    }
}
