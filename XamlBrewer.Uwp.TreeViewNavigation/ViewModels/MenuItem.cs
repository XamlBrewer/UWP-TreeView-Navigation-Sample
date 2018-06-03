using System.Collections.ObjectModel;

namespace Mvvm
{
    internal class MenuItem : BindableBase
    {
        private string _glyph;
        private string _text;
        private ObservableCollection<MenuItem> _children = new ObservableCollection<MenuItem>();

        public string Glyph
        {
            get { return _glyph; }
            set { SetProperty(ref _glyph, value); }
        }

        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public ObservableCollection<MenuItem> Children
        {
            get { return _children; }
            set { SetProperty(ref _children, value); }
        }

        public override string ToString()
        {
            return _text;
        }
    }
}
