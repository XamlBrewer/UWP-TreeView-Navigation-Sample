using Windows.UI.Xaml.Controls;

namespace Mvvm
{
    internal static class NavigationMenuItemExtensions
    {
        internal static TreeViewNode AsTreeViewNode(this NavigationMenuItem menuItem)
        {
            var result = new TreeViewNode
            {
                Content = menuItem
            };

            foreach (NavigationMenuItem subItem in menuItem.Children)
            {
                result.Children.Add(subItem.AsTreeViewNode());
            }

            return result;
        }
    }
}
