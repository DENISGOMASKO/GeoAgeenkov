using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using EntityFrameworkClassLibrary.Contexts;
using Geo.WpfApp.Core;
using Microsoft.EntityFrameworkCore;

namespace Geo.WpfApp.ViewModels.Pages
{
    internal class LoginPageViewModel : BaseViewModel
    {

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private bool _isCaptchaFilled = false;
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

        private AccountContext accountContext;
        public LoginPageViewModel()
        {
            accountContext = new AccountContext();
            accountContext.Database.EnsureCreated();
        }

        private bool userIsAvailable(string login, string password)
        {
            accountContext.Load();
            return accountContext.account.Any(a => string.Equals(a.login, login) && string.Equals(a.password, password));
        }

        public ICommand EntryCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Trace.WriteLine(userIsAvailable(Login, Password) && IsCaptchaFilled);
                });
            }
        }
    }
}
