using EntityFrameworkClassLibrary.Core;
using EntityFrameworkClassLibrary.Relationships;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkClassLibrary.Contexts
{
    public class AccountContext : BaseContext
    {
        public DbSet<Post> post { get; set; }
        public DbSet<Account> account { get; set; }

        public void Load()
        {
            post.Load();
            account.Load();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().Ignore(a => a.places_as_expert).Ignore(a => a.places_as_oper).Ignore(a => a.finalData_as_analytic);
            modelBuilder.Entity<Account>()
                .HasOne(a => a.post)
                .WithMany(p => p.accounts)
                .HasForeignKey(a => a._id_post);                                     
        }
    }
}
