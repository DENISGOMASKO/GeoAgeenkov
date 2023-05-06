#define HOME1
using System;
using System.Collections.Generic;
using System.Text;


namespace EntityFrameworkClassLibrary
{
    public static class Info
    {
        public static string connectionString
        {
            get { 
                string _connectionString = null;
                #if HOME
                _connectionString = @"Data Source = DENISPC; Initial Catalog = GomaskoDP_Geo; Integrated Security = True";
                #else
                _connectionString = @"Data Source = DBSRV\ag2022; Initial Catalog = GomaskoDP_Geo; Integrated Security = True";
                #endif
                return _connectionString;
            }
        }

        public static string connectionStringEdit
        {
            get
            {
                string _connectionString = null;
#if HOME
                _connectionString = @"Data Source = DENISPC; Initial Catalog = GomaskoDP_Edit; Integrated Security = True";
#else
                _connectionString = @"Data Source = DBSRV\ag2022; Initial Catalog = GomaskoDP_editing; Integrated Security = True";
#endif
                return _connectionString;
            }
        }

    }
}

