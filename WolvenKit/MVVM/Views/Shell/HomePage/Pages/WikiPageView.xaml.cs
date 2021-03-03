
using System.Windows;
using WolvenKit.Functionality.WKitGlobal.Helpers;

namespace WolvenKit.Views.HomePage.Pages
{
    public partial class WikiPageView
    {
        public WikiPageView()
        {
            InitializeComponent(); 

        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsVisible )
            {
                DiscordHelper.SetDiscordRPCStatus("Wiki");
            }

        }
    }
}
