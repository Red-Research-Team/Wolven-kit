using Catel.IoC;
using HandyControl.Controls;
using WolvenKit.MVVM.Model.Wizards;
using WolvenKit.MVVM.ViewModels.Components.Wizards;

namespace WolvenKit.MVVM.Views.Components.Wizards.WizardPages.FirstSetupWizard
{
    public partial class CreateUserView
    {
        #region Fields

        private FirstSetupWizardModel _fswm;
        private FirstSetupWizardViewModel _fswvm;

        #endregion Fields

        #region Constructors

        public CreateUserView()
        {
            InitializeComponent();

            _fswvm = ServiceLocator.Default.ResolveType<FirstSetupWizardViewModel>();
            _fswm = ServiceLocator.Default.ResolveType<FirstSetupWizardModel>();
            validateAllFields();

            imgSelector.CommandBindings[0].Executed += imgSelector_Executed;
        }

        #endregion Constructors

        #region Methods

        private void Field_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) => validateAllFields();

        private void ImageSelector_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
        }

        private void imgSelector_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            var imgBrush = imgSelector.PreviewBrush as System.Windows.Media.ImageBrush;
            if (imgBrush != null)
            {
                _fswm.ProfileImageBrush = imgBrush;
                _fswm.ProfileImageBrushPath = imgSelector.Uri.AbsoluteUri;
            }
            else
            {
                _fswm.ProfileImageBrush = default(System.Windows.Media.ImageBrush);
                _fswm.ProfileImageBrushPath = "";
            }
        }

        private HandyControl.Data.OperationResult<bool> IsValidEmail(string str)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(str);
            return match.Success
                ? HandyControl.Data.OperationResult.Success()
                : HandyControl.Data.OperationResult.Failed();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_fswm.ProfileImageBrush != null)
            {
                imgSelector.SetValue(ImageSelector.UriPropertyKey, new System.Uri(_fswm.ProfileImageBrushPath, System.UriKind.RelativeOrAbsolute));
                imgSelector.SetValue(ImageSelector.PreviewBrushPropertyKey, _fswm.ProfileImageBrush);
                imgSelector.SetValue(ImageSelector.HasValuePropertyKey, true);
                imgSelector.SetCurrentValue(ImageSelector.ToolTipProperty, _fswm.ProfileImageBrushPath);
            }
            else
            {
                imgSelector.SetValue(ImageSelector.UriPropertyKey, default(System.Uri));
                imgSelector.SetValue(ImageSelector.PreviewBrushPropertyKey, default(System.Windows.Media.Brush));
                imgSelector.SetValue(ImageSelector.HasValuePropertyKey, false);
                imgSelector.SetCurrentValue(ImageSelector.ToolTipProperty, default);
            }
        }

        private void validateAllFields() => _fswvm.AllFieldIsValid = NameTb.VerifyData() && EmailTb.VerifyData() && DonateTb.VerifyData();

        #endregion Methods
    }
}
