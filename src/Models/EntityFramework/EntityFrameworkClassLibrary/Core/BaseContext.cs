using EntityFrameworkClassLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkClassLibrary.Core
{
    public class BaseContext : DbContext
    {
        protected string _connectionString = null;

        protected BaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected BaseContext()
        {
            _connectionString = Info.connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
