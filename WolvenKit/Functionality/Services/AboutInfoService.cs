using Orchestra.Models;
using Orchestra.Services;
using System;

namespace WolvenKit.Functionality.Services
{
    internal class AboutInfoService : IAboutInfoService
    {
        public AboutInfo GetAboutInfo()
        {
            var aboutInfo = new AboutInfo(new Uri("pack://application:,,,/Resources/Media/Images/Application/CompanyLogo.png", UriKind.RelativeOrAbsolute),
                uriInfo: new UriInfo("https://github.com/WolvenKit/Wolven-kit", "Github Page"));

            return aboutInfo;
        }
    }
}
