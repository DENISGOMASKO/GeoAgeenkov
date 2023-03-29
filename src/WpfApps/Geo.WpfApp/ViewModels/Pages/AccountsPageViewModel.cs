using Egor92.MvvmNavigation.Abstractions;
using EntityFrameworkClassLibrary.Contexts;
using EntityFrameworkClassLibrary.Relationships;
using Geo.WpfApp.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace Geo.WpfApp.ViewModels.Pages
{
    internal class AccountsPageViewModel : BaseViewModel
    {

        #region Fields

        private readonly INavigationManager _navigationManager;
        private AccountContext accountContext = new AccountContext();

        private ObservableCollection<Account> _accounts;
        public ObservableCollection<Account> Accounts { 
            get 
            {
                return _accounts;
            }
            set
            {
                _accounts = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Post> _posts;
        public ObservableCollection<Post> Posts
        {
            get
            {
                return _posts;
            }
            set
            {
                _posts = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Ctor

        public AccountsPageViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            accountContext.Database.EnsureCreated();
            LoadData();
        }

        #endregion

        #region LoadAccounts

        private void LoadData()
        {
            accountContext.Load();
            Accounts = accountContext.account.Local.ToObservableCollection();
            Posts = accountContext.post.Local.ToObservableCollection();
            Trace.WriteLine(Posts.Count);
            Trace.WriteLine(Posts);
        }

        public ICommand LoadCommand
        {
            get
            {
                return new ActionCommand(LoadData);
            }
        }

        #endregion

        #region SaveData
        private void SaveData()
        {
            accountContext.SaveChanges();
        }
        
        public ICommand SaveCommand
        {
            get 
            { 
                return new ActionCommand(SaveData);  
            }
        }

        #endregion

    }
}
