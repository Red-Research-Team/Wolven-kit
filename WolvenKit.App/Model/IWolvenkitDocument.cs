﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolvenKit.App.ViewModels;

namespace WolvenKit.Common.Model
{
    public interface IWolvenkitDocument
    {

        string FileName { get; }
        //object SaveTarget { get; set; }


        //void SaveFile();
        void Close();

        bool GetIsDisposed();

        DocumentViewModel GetViewModel();
    }
}
