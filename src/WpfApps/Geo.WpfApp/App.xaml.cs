using Egor92.MvvmNavigation;
using Egor92.MvvmNavigation.Abstractions;
using Geo.WpfApp.Constants;
using Geo.WpfApp.ViewModels.Pages;
using Geo.WpfApp.Views.Pages;
using Geo.WpfApp.Views.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Geo.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            var navigationManager = new NavigationManager(mainWindow);
            navigationManager.Register<LoginPage>(NavigationKeys.Login, () => new LoginPageViewModel(navigationManager));
            navigationManager.Register<AccountsPage>(NavigationKeys.Accounts, () => new AccountsPageViewModel(navigationManager));
            navigationManager.Register<AddAccountPage>(NavigationKeys.AddAccount, () => new AddAccountViewModel(navigationManager));
            /*navigationManager.Register<WelcomeView>(NavigationKeys.Welcome, () => new WelcomeViewModel(navigationManager));
            navigationManager.Register<ParameterSelectionView>(NavigationKeys.ParameterSelection, () => new ParameterSelectionViewModel(navigationManager));
            navigationManager.Register<ParameterDisplayView>(NavigationKeys.ParameterDisplay, () => new ParameterDisplayViewModel(navigationManager));
            */
            mainWindow.Show();
            navigationManager.Navigate(NavigationKeys.Login);
        }
    }
}
