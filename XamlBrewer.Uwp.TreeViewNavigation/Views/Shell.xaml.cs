using Mvvm;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

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

            // AppTitleBar.Height = coreTitleBar.Height;
            Window.Current.SetTitleBar(AppTitleBar);

            foreach (var item in MainMenu)
            {
                NavigationTree.RootNodes.Add(item.AsTreeViewNode());
            }
        }

        private ObservableCollection<NavigationMenuItem> MainMenu
        {
            get
            {
                return new ObservableCollection<NavigationMenuItem>
                {
                    new NavigationMenuItem
                    {
                        Text = "Edged Weapons",
                        Children = new
                        ObservableCollection<MenuItem>
                        {
                            new NavigationMenuItem
                            {
                                Text = "Arakh"
                            },
                            new NavigationMenuItem
                            {
                                Text = "Dragonglass"
                            },
                            new NavigationMenuItem
                            {
                                Text = "Ice blade"
                            },
                            new NavigationMenuItem
                            {
                                Text = "Valyrian Steel",
                                Children = new ObservableCollection<MenuItem>
                                {
                                    new NavigationMenuItem
                                    {
                                        Text = "Heartsbane"
                                    },
                                    new NavigationMenuItem
                                    {
                                        Text = "Longclaw"
                                    },
                                    new NavigationMenuItem
                                    {
                                        Text = "Oathkeeper"
                                    },
                                    new NavigationMenuItem
                                    {
                                        Text = "Widow's Wail"
                                    }
                                }
                            }
                        }
                    },
                    new NavigationMenuItem
                    {
                        Text = "Poison",
                        Children = new ObservableCollection<MenuItem>
                        {
                            new NavigationMenuItem
                            {
                                Text = "Tears of Lys"
                            },
                            new NavigationMenuItem
                            {
                                Text = "The Long Farewell"
                            },
                            new NavigationMenuItem
                            {
                                Text = "The Strangler"
                            },
                            new NavigationMenuItem
                            {
                                Text = "Wolfbane"
                            }
                        }
                    },
                    new NavigationMenuItem
                    {
                        Text = "Weapons of Mass Destruction",
                        Children = new ObservableCollection<MenuItem>
                        {
                            new NavigationMenuItem
                            {
                                Text = "Dragons",
                                Children = new ObservableCollection<MenuItem>
                                {
                                    new NavigationMenuItem
                                    {
                                        Text = "Balerion"
                                    },
                                    new NavigationMenuItem
                                    {
                                        Text = "Drogon"
                                    },
                                    new NavigationMenuItem
                                    {
                                        Text = "Rhaegal"
                                    },
                                    new NavigationMenuItem
                                    {
                                        Text = "Viserion"
                                    }
                                }
                            },
                            new NavigationMenuItem
                            {
                                Text = "WildFire"
                            }
                        }
                    }
                };
            }
        }

        private void SplitViewFrame_OnNavigated(object sender, NavigationEventArgs e)
        {

        }

        /// <summary>
        /// Toggles the SplitView pane.
        /// </summary>
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            ShellSplitView.IsPaneOpen = !ShellSplitView.IsPaneOpen;
        }

        private void TreeView_ItemInvoked(TreeView sender, TreeViewItemInvokedEventArgs args)
        {

        }
    }
}
