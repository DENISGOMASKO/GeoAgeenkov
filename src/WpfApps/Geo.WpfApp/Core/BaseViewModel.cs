using Egor92.MvvmNavigation.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Geo.WpfApp.Core
{ 
    internal class BaseViewModel : INotifyPropertyChanged
    {
        protected INavigationManager _navigationManager;


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
