using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Egor92.MvvmNavigation.Abstractions;
using EntityFrameworkClassLibrary.Contexts;
using Geo.WpfApp.Constants;
using Geo.WpfApp.Core;

using Microsoft.EntityFrameworkCore;

namespace Geo.WpfApp.ViewModels.Pages
{
    internal class LoginPageViewModel : BaseViewModel
    {
        #region Fields

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
                OnPropertyChanged();
            }
        }

        private readonly INavigationManager _navigationManager;

        private AccountContext accountContext = new AccountContext();

        #endregion

        #region Ctor

        public LoginPageViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            accountContext.Database.EnsureCreated();            
        }

        #endregion

        #region Enter

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
                    #if DEBUG
                    _navigationManager.Navigate(NavigationKeys.Account);
                    #else
                    if (userIsAvailable(Login, Password) && IsCaptchaFilled)
                    {
                        _navigationManager.Navigate(NavigationKeys.Accounts);
                    }
                    #endif
                });
            }
        }

        #endregion
    }
}
