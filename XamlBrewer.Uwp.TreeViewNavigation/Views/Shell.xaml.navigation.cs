using Mvvm;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using XamlBrewer.Uwp.TreeViewNavigation.Views;

namespace XamlBrewer.Uwp.TreeViewNavigation
{
    public sealed partial class Shell : Page
    {
        private ObservableCollection<NavigationMenuItem> MainMenu
        {
            get
            {
                return new ObservableCollection<NavigationMenuItem>
                {
                    new NavigationMenuItem
                    {
                        Text = "Edged Weapons",
                        NavigationDestination = typeof(BladesPage),
                        Children = new ObservableCollection<MenuItem>
                        {
                            new NavigationMenuItem
                            {
                                Text = "Arakh", NavigationDestination = typeof(BladesPage), NavigationParameter = "Arakh"
                            },
                            new NavigationMenuItem
                            {
                                Text = "Dragonglass", NavigationDestination = typeof(BladesPage), NavigationParameter = "Dragonglass"
                            },
                            new NavigationMenuItem
                            {
                                Text = "Ice blade", NavigationDestination = typeof(BladesPage), NavigationParameter = "Ice blade"
                            },
                            new NavigationMenuItem
                            {
                                Text = "Valyrian Steel",
                                NavigationDestination = typeof(BladesPage),
                                NavigationParameter = "Valyrian Steel",
                                Children = new ObservableCollection<MenuItem>
                                {
                                    new NavigationMenuItem
                                    {
                                        Text = "Heartsbane", NavigationDestination = typeof(BladesPage), NavigationParameter = "Heartsbane"
                                    },
                                    new NavigationMenuItem
                                    {
                                        Text = "Longclaw", NavigationDestination = typeof(BladesPage), NavigationParameter = "Longclaw"
                                    },
                                    new NavigationMenuItem
                                    {
                                        Text = "Oathkeeper", NavigationDestination = typeof(BladesPage), NavigationParameter = "Oathkeeper"
                                    },
                                    new NavigationMenuItem
                                    {
                                        Text = "Widow's Wail", NavigationDestination = typeof(BladesPage), NavigationParameter = "Widow's Wail"
                                    }
                                }
                            }
                        }
                    },
                    new NavigationMenuItem
                    {
                        Text = "Poison",
                        NavigationDestination = typeof(PoisonPage),
                        Children = new ObservableCollection<MenuItem>
                        {
                            new NavigationMenuItem
                            {
                                Text = "Tears of Lys", NavigationDestination = typeof(PoisonPage), NavigationParameter = "Tears of Lys"
                            },
                            new NavigationMenuItem
                            {
                                Text = "The Long Farewell", NavigationDestination = typeof(PoisonPage), NavigationParameter = "The Long Farewell"
                            },
                            new NavigationMenuItem
                            {
                                Text = "The Strangler", NavigationDestination = typeof(PoisonPage), NavigationParameter = "The Strangler"
                            },
                            new NavigationMenuItem
                            {
                                Text = "Wolfbane", NavigationDestination = typeof(PoisonPage), NavigationParameter = "Wolfbane"
                            }
                        }
                    },
                    new NavigationMenuItem
                    {
                        Text = "Weapons of Mass Destruction",
                        NavigationDestination = typeof(MassDestructionPage),
                        Children = new ObservableCollection<MenuItem>
                        {
                            new NavigationMenuItem
                            {
                                Text = "Dragons",
                                NavigationDestination = typeof(MassDestructionPage),
                                NavigationParameter = "Dragons",
                                Children = new ObservableCollection<MenuItem>
                                {
                                    new NavigationMenuItem
                                    {
                                        Text = "Balerion", NavigationDestination = typeof(MassDestructionPage), NavigationParameter = "Balerion"
                                    },
                                    new NavigationMenuItem
                                    {
                                        Text = "Drogon", NavigationDestination = typeof(MassDestructionPage), NavigationParameter = "Drogon"
                                    },
                                    new NavigationMenuItem
                                    {
                                        Text = "Rhaegal", NavigationDestination = typeof(MassDestructionPage), NavigationParameter = "Rhaegal"
                                    },
                                    new NavigationMenuItem
                                    {
                                        Text = "Viserion", NavigationDestination = typeof(MassDestructionPage), NavigationParameter = "Viserion"
                                    }
                                }
                            },
                            new NavigationMenuItem
                            {
                                Text = "WildFire", NavigationDestination = typeof(MassDestructionPage), NavigationParameter = "WildFire"
                            }
                        }
                    }
                };
            }
        }

        /// <summary>
        /// Navigates to the specified source page type.
        /// </summary>
        public bool Navigate(Type sourcePageType, object parameter = null)
        {
            return SplitViewFrame.Navigate(sourcePageType, parameter);
        }

        /// <summary>
        /// Shows the system back button.
        /// </summary>
        public void EnableBackButton()
        {
            var navManager = SystemNavigationManager.GetForCurrentView();
            navManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            navManager.BackRequested -= (s, e) => GoBack();
            navManager.BackRequested += (s, e) => GoBack();
        }

        /// <summary>
        /// Hides the system back button.
        /// </summary>
        public void DisableBackButton()
        {
            var navManager = SystemNavigationManager.GetForCurrentView();
            navManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            navManager.BackRequested -= (s, e) => GoBack();
        }

        /// <summary>
        /// Returns to the previous page.
        /// </summary>
        public void GoBack()
        {
            if (SplitViewFrame.CanGoBack)
            {
                SplitViewFrame.GoBack();
            }
        }

        /// <summary>
        /// Populates the TreeView from the Menu.
        /// </summary>
        private void PopulateTreeView()
        {
            // Populate the tree.
            foreach (var item in MainMenu)
            {
                NavigationTree.RootNodes.Add(item.AsTreeViewNode());
            }
        }

        /// <summary>
        /// Navigates to the corresponding treeview selection.
        /// </summary>
        private void TreeView_ItemInvoked(TreeView sender, TreeViewItemInvokedEventArgs args)
        {
            var node = args.InvokedItem as TreeViewNode;
            if (node != null)
            {
                var menuItem = node.Content as NavigationMenuItem;
                if (menuItem != null)
                {
                    var target = menuItem.NavigationDestination;
                    if (target != null)
                    {
                        Navigate(menuItem.NavigationDestination, menuItem.NavigationParameter);
                    }
                }
            }
        }
    }
}
