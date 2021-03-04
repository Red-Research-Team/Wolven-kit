using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Tools;
using Octokit;
using WolvenKit.MVVM.ViewModels.Shell.HomePage.Pages;
using WolvenKit.MVVM.Views.Shell.HomePage.Pages;

namespace WolvenKit.Functionality.WKitGlobal.Helpers
{
    public static class GithubHelper
    {
        #region Fields

        private static GitHubClient GhubClient;

        #endregion Fields

        #region Methods

        public static Credentials GhubAuth(string u, string p)
        {
            var basicAuth = new Credentials(u, p); // NOTE: not real credentials
            return basicAuth;
        }

        public static async Task GhubLastReleaseAsync()
        {
            try
            {
                var general = await GhubClient.Repository.Get("WolvenKit", "Wolven-Kit").ConfigureAwait(false);
                var g_stars = general.StargazersCount;
                var g_forks = general.ForksCount;
#pragma warning disable 618
                var g_watchers = general.SubscribersCount;  // Ignore that error its the only way to get the watchers atm. (Shit documentation online tbh)
#pragma warning restore 618

                AboutPageView.GlobalAboutPage.WatchShield.SetCurrentValue(Shield.StatusProperty, g_watchers.ToString());
                AboutPageView.GlobalAboutPage.ForkShield.SetCurrentValue(Shield.StatusProperty, g_forks.ToString());
                AboutPageView.GlobalAboutPage.StarShield.SetCurrentValue(Shield.StatusProperty, g_stars.ToString());

                var releases = await GhubClient.Repository.Release.GetLatest("WolvenKit", "Wolven-Kit").ConfigureAwait(false);
                var latest = releases; // Just a temp fix so I don't spam GHub api during dev
                var data = new ObservableCollection<GithubTimeLine>();

                var item = new GithubTimeLine() { TitleLabel = latest.TagName, TitleInfo = latest.Name, TitleStyle = ResourceHelper.GetResource<Style>(ResourceToken.LabelViolet) };

                var unresolvedBody = latest.Body;
                var body = ResolveBody(unresolvedBody);

                foreach (var line in body)
                {
                    if (!line.Contains('#'))
                    {
                        string[] myStrings = { "more", "extra", "improved" };

                        if (myStrings.Any(line.ToLowerInvariant().Contains))
                        {
                            item.Members.Add(new ContentMember() { ContentTitle = "Addon", ContentInfo = line, ContentStyle = ResourceHelper.GetResource<Style>(ResourceToken.LabelInfo) });
                        }
                        else if (line.Contains("new", System.StringComparison.InvariantCultureIgnoreCase))
                        {
                            item.Members.Add(new ContentMember() { ContentTitle = "New", ContentInfo = line, ContentStyle = ResourceHelper.GetResource<Style>(ResourceToken.LabelSuccess) });
                        }
                        else if (line.Contains("breaking change", System.StringComparison.InvariantCultureIgnoreCase))
                        {
                            item.Members.Add(new ContentMember() { ContentTitle = "Breaking", ContentInfo = line, ContentStyle = ResourceHelper.GetResource<Style>(ResourceToken.LabelDanger) });
                        }
                        else if (line.Contains("overhaul", System.StringComparison.InvariantCultureIgnoreCase))
                        {
                            item.Members.Add(new ContentMember() { ContentTitle = "Overhaul", ContentInfo = line, ContentStyle = ResourceHelper.GetResource<Style>(ResourceToken.LabelWarning) });
                        }
                        else
                        {
                            item.Members.Add(new ContentMember() { ContentTitle = "Change", ContentInfo = line, ContentStyle = ResourceHelper.GetResource<Style>(ResourceToken.LabelPrimary) });
                        }
                    }
                }
                data.Add(item);
                AboutPageView.GlobalAboutPage.gitTime.SetCurrentValue(ItemsControl.ItemsSourceProperty, data);

                AboutPageViewModel.GithubCollection = data;
            }
            catch { }
        }

        public static async void InitializeGitHub()
        {
            GhubClient = new GitHubClient(new ProductHeaderValue("WolvenKit"))
            {
                Credentials = GhubAuth("wolvenbot", "botwolven1")
            };
            await GhubLastReleaseAsync();
        }

        private static string[] ResolveBody(string unresolvedbody)
        {
            var step1 = Regex.Replace(unresolvedbody, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
            var result = Regex.Split(step1, "\r\n|\r|\n");

            return result;
        }

        #endregion Methods
    }
}
