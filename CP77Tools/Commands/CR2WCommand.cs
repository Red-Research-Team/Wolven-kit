﻿using System.CommandLine;
using System.CommandLine.Invocation;

namespace CP77Tools.Commands
{
    public class CR2WCommand : Command
    {
        private new const string Name = "cr2w";
        private new const string Description = "Target a specific CR2W (extracted) and dump file info.";

        public CR2WCommand() : base(Name, Description)
        {
            AddOption(new Option<string[]>(new[] {"--path", "-p"}, "Input path to a CR2W file."));
            AddOption(new Option<string>(new []{"--outpath", "-o"}, "Output path."));
            AddOption(new Option<bool>(new[] {"--chunks", "-c"}, "Dump all class information."));
            AddOption(new Option<string>(new[] { "--pattern", "-w" }, "Use optional search pattern (e.g. *.ink), if both regex and pattern is defined, pattern will be prioritized"));
            AddOption(new Option<string>(new[] { "--regex", "-r" }, "Use optional regex pattern."));

            Handler = CommandHandler.Create<string[], string, bool, string, string>(Tasks.ConsoleFunctions.Cr2wTask);
        }
    }
}
