﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolvenKit.Common.Services
{
    public interface IWindowFactory
    {
        string ShowAddChunkFormModal(IEnumerable<string> availableTypes, ref string output);
    }
}
