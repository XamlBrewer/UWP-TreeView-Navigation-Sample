using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace XamlBrewer.Uwp.TreeViewNavigation.Views
{
    public sealed partial class MassDestructionPage : Page
    {
        public MassDestructionPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                SubTitle.Text = e.Parameter.ToString();
            }

            base.OnNavigatedTo(e);
        }
    }
}
