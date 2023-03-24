#define HOME
using System;
using System.Collections.Generic;
using System.Text;


namespace EtityFrameworkClassLibrary
{
    public static class Info
    {
        public static string connectionString()
        {
            string _connectionString = null;
            #if HOME
                _connectionString = @"Data Source = DENISPC; Initial Catalog = GomaskoDP_Geo; Integrated Security = True";
            #else
                _connectionString = @"Data Source = DBSRV\ag2022; Initial Catalog = GomaskoDP_Geo; Integrated Security = True";
            #endif
            return _connectionString;
        }
    }
}

