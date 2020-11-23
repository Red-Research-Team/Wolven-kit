﻿using Catel.MVVM;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using WolvenKit.Common;
using WolvenKit.Common.Services;
//using Ninject;
//using Ninject.Activation;
//using Ninject.Syntax;

namespace WolvenKit.App.ViewModels
{
    /// <summary>
    /// Base abstract class for all viewmodels.
    /// </summary>
    public abstract class ViewModel : ViewModelBase
    {
        protected readonly IWindowFactory m_windowFactory;

        public ViewModel(IWindowFactory windowFactory)
        {
            m_windowFactory = windowFactory;
        }

        public ViewModel()
        {

        }

        public virtual void Initialize()
        {
            
        }
    }
}