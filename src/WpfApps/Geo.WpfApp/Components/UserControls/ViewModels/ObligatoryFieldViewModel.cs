using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using Geo.WpfApp.Core;

namespace Geo.WpfApp.Components.UserControls.ViewModels
{
    internal class ObligatoryFieldViewModel : BaseViewModel
    {
        private string _content;
        public string Content
        {
            set { 
                _content = value; 
                OnPropertyChanged("BorderColor");
            }
        }
        public Brush BorderColor
        {
            get
            {
                return IsFill ? Brushes.Green : Brushes.Red;
            }
        }
        public bool IsFill
        {
            get
            {
                return !String.IsNullOrEmpty(_content);
            }
        }
    }
}
