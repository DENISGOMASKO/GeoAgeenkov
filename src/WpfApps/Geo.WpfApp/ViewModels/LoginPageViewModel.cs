using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Geo.WpfApp.Core;

namespace Geo.WpfApp.ViewModels
{
    internal class LoginPageViewModel : BaseViewModel
    {


        private bool _isCaptchaFilled;
        public bool IsCaptchaFilled
        {
            get { return _isCaptchaFilled; }
            set
            {
                _isCaptchaFilled = value;
                //Trace.WriteLine(_isCaptchaFilled);
                OnPropertyChanged();
            }
        }

        public ICommand EntryCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Trace.WriteLine(IsCaptchaFilled);
                    IsCaptchaFilled = true;
                });
            }
        }
    }
}
