using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace XamlBrewer.Uwp.TreeViewNavigation.Views
{
    public sealed partial class PoisonPage : Page
    {
        public PoisonPage()
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
