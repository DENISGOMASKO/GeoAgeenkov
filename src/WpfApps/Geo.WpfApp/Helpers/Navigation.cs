using Geo.WpfApp.Views.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;


namespace Geo.WpfApp.Helpers
{
    internal enum NavigateTo
    {
        Login, AddAccounts
    }
    internal static class Navigation
    {

        /*internal static bool Navigate(NavigateTo target, Window win) =>
            win.MainFrame.Navigate(GetPage(target));*/

        internal static bool Navigate(NavigateTo target, Page page) =>
            page.NavigationService!.Navigate(GetPage(target));
        internal static bool Navigate(NavigateTo target, Frame frame) =>
            frame.NavigationService!.Navigate(GetPage(target));

       /* internal static bool Navigate(NavigateTo target, DependencyObject? child)
        {
            var res = child;
            while (res is not null)
            {
                switch (res)
                {
                    case Page page:
                        return Navigate(target, page);
                    case DemoTestWin win:
                        return Navigate(target, win);
                    default:
                        res = (res as FrameworkElement)?.Parent;
                        break;
                }
            }
            return false;
        }*/

        private static Page GetPage(NavigateTo target) => target switch
        {
            NavigateTo.Login => new LoginPage(),
            _ => throw new NotImplementedException()
        };
    }
}
