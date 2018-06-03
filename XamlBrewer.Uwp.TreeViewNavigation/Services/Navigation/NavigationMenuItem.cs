using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvvm
{
    internal class NavigationMenuItem : MenuItem
    {
        private Type _navigationDestination;
        private object _navigationParameter;

        public Type NavigationDestination
        {
            get { return _navigationDestination; }
            set { SetProperty(ref _navigationDestination, value); }
        }

        public object NavigationParameter
        {
            get { return _navigationParameter; }
            set { SetProperty(ref _navigationParameter, value); }
        }
    }
}
