using Egor92.MvvmNavigation.Abstractions;
using Geo.WpfApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkClassLibrary;
using Microsoft.Data.SqlClient;
using System.Windows.Input;
using System.Diagnostics;

namespace Geo.WpfApp.ViewModels.Pages
{
    class EditPageViewModel : BaseViewModel
    {
        private string connectionString;

        public EditPageViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            connectionString = Info.connectionStringEdit;


        }

        private void CreateCommand(string queryString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
        }


        public ICommand Int2FloatCommand
        {
            get
            {
                return new ActionCommand(()=>
                {
                    CreateCommand("ALTER TABLE movement ALTER COLUMN length float; ");
                });
            }
        }

        public ICommand Float2IntCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    CreateCommand("ALTER TABLE movement ALTER COLUMN length int; ");
                });
            }
        }

        public ICommand NewColumnCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    CreateCommand("ALTER TABLE movement ADD Address NVARCHAR(50) NULL; ");
                });
            }
        }

        public ICommand DropColumnCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    CreateCommand("ALTER TABLE movement DROP COLUMN Address; ");
                });
            }
        }

        public ICommand Size10to20Command
        {
            get
            {
                return new ActionCommand(() =>
                {
                    CreateCommand("ALTER TABLE movement ALTER COLUMN title nvarchar(20); ");
                });
            }
        }

        public ICommand Size20to10Command
        {
            get
            {
                return new ActionCommand(() =>
                {
                    CreateCommand("ALTER TABLE movement ALTER COLUMN title nvarchar(10); ");
                });
            }
        }

    }
}
