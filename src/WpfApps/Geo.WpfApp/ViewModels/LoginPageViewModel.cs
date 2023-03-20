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
        private string _captchaText;
        public string CaptchaText { 
            get { return _captchaText; } 
            set { 
                _captchaText = value;
                Trace.WriteLine(_captchaText);
                OnPropertyChanged();
            } 
        }

        private bool _captchaFilled;
        public bool CaptchaFilled
        {
            get { return _captchaFilled; }
            set
            {
                _captchaFilled = value;
                Trace.WriteLine(_captchaFilled);
                OnPropertyChanged();
            }
        }

        public ICommand EntryCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Trace.WriteLine(CaptchaFilled);
                });
            }
        }
    }
}
