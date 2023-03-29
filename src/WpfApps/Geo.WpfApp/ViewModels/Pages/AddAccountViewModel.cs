using Egor92.MvvmNavigation.Abstractions;
using EntityFrameworkClassLibrary.Contexts;
using EntityFrameworkClassLibrary.Relationships;
using Geo.WpfApp.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Geo.WpfApp.ViewModels.Pages
{
    internal class AddAccountViewModel: BaseViewModel
    {
        #region Fields
        private readonly INavigationManager _navigationManager;
        private AccountContext accountContext = new AccountContext();

        private string _fullName;
        public string FullName 
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged();
            }
        }

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

        private Post _sPost;
        public Post SPost
        {
            get { return _sPost; }
            set
            {
                _sPost = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Ctor
        public AddAccountViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            accountContext.Database.EnsureCreated();
            accountContext.Load();
            Posts = accountContext.post.Local.ToObservableCollection();
        }
        #endregion

        #region Add

        public ICommand AddCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    var temp = new Account();
                    temp.full_name = FullName;
                    temp.login = Login;
                    temp.password = Password;
                    temp._id_post = SPost.id_post;
                    accountContext.account.Add(temp);
                    accountContext.SaveChanges();
                    FullName = "";
                    Login = "";
                    Password = "";
                    SPost = null;
                });
            }
        }
            
        #endregion
    }
}
