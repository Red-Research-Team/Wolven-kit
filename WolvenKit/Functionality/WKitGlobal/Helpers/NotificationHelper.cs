using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.IoC;
using Orchestra.Services;
using WolvenKit.Functionality.Services;

namespace WolvenKit.Functionality.WKitGlobal.Helpers
{
    public static class NotificationHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static IGrowlNotificationService Growl => ServiceLocator.Default.ResolveType<IGrowlNotificationService>();
        public static void InitializeNotificationHelper()
        {
            Growl.NotificationCategory = ENotificationCategory.App;
        }

    }
}
