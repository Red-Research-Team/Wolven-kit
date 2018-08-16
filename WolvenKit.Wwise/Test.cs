﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WolvenKit.Wwise
{
    class Test
    {
        [STAThread]
        public static void Main()
        {
            using (var of = new OpenFileDialog())
            {
                of.Filter = "Wwise files | *.wem;*.bnk";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    switch (Path.GetExtension(of.FileName))
                    {
                        case ".wem":
                        {
                            var wem = new Wwise.WEM.RiffFile(of.FileName);
                            break;
                        }
                        case ".bnk":
                        {
                            var bnk = new Wwise.BNK.BNK();
                            bnk.LoadBNK(new MemoryStream(File.ReadAllBytes(of.FileName)));
                            break;
                        }
                    }
                }
            }
        }
    }
}
