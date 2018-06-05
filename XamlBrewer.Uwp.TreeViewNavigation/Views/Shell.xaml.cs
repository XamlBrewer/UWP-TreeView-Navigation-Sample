using Mvvm;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using XamlBrewer.Uwp.TreeViewNavigation.Views;

namespace XamlBrewer.Uwp.TreeViewNavigation
{
    public sealed partial class Shell : Page
    {
        public Shell()
        {
            // Blends the app into the title bar.
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            titleBar.ButtonForegroundColor = (Color)Application.Current.Resources["TitlebarButtonForegroundColor"];

            this.InitializeComponent();

            // Update the title bar when the back button (dis)appears or resizes.
            Window.Current.CoreWindow.SizeChanged += (s, e) => UpdateAppTitle();
            coreTitleBar.LayoutMetricsChanged += (s, e) => UpdateAppTitle();

            // Show the system back button.
            EnableBackButton();

            Window.Current.SetTitleBar(AppTitleBar);

            PopulateTreeView();
        }

        /// <summary>
        /// Updates the title bar when the back button (dis)appears or resizes.
        /// </summary>
        private void UpdateAppTitle()
        {
            var full = (ApplicationView.GetForCurrentView().IsFullScreenMode);
            var left = (full ? 0 : CoreApplication.GetCurrentView().TitleBar.SystemOverlayLeftInset);
            HamburgerButton.Margin = new Thickness(left, 0, 0, 0);
            AppTitle.Margin = new Thickness(left + HamburgerButton.Width + 12, 8, 0, 0);
        }

        /// <summary>
        /// Toggles the SplitView pane.
        /// </summary>
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            ShellSplitView.IsPaneOpen = !ShellSplitView.IsPaneOpen;
        }

        private void SettingsButton_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Navigate(typeof(SettingsPage));
        }

        private void AboutButton_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Navigate(typeof(AboutPage));
        }
    }
}
