using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangingViewOnClick
{
    class SubSubViewVM : BaseViewModel
    {
        private string _text = "Ich bin die SubSubView";

        public SubSubViewVM() { }

        public string Text
        {
            get => _text;
            set
            {
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }
    }
}
