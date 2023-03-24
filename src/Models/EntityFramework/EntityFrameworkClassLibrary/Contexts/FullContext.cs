using EntityFrameworkClassLibrary.Core;
using EntityFrameworkClassLibrary.Relationships;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkClassLibrary.Contexts
{
    public class FullContext : BaseContext
    {
        public DbSet<Project> project { get; set; }
        public DbSet<Post> post { get; set; }
        public DbSet<Account> account { get; set; }
        public DbSet<Place> place { get; set; }
        public DbSet<Profile> profile { get; set; }
        public DbSet<FinalData> finalData { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOne(a => a.post)
                .WithMany(p => p.accounts)
                .HasForeignKey(a => a._id_post);

            modelBuilder.Entity<Place>()
                .HasOne(p => p.project)
                .WithMany(pr => pr.places)
                .HasForeignKey(p => p._id_project);

             modelBuilder.Entity<Place>()
                .HasOne(p => p.oper)
                .WithMany(o => o.places_as_oper)
                .HasForeignKey(p => p._id_operator);

              modelBuilder.Entity<Place>()
                .HasOne(p => p.expert)
                .WithMany(o => o.places_as_expert)
                .HasForeignKey(p => p._id_expert);
                
            modelBuilder.Entity<Profile>()
                .HasOne(p => p.place)
                .WithMany(pl => pl.profiles)
                .HasForeignKey(p => p._id_place);
                
            modelBuilder.Entity<FinalData>()
                .HasOne(fd => fd.project)
                .WithMany(p => p.finalData)
                .HasForeignKey(fd => fd._id_project);
                
            modelBuilder.Entity<FinalData>()
                .HasOne(fd => fd.analytic)
                .WithMany(a => a.finalData_as_analytic)
                .HasForeignKey(fd => fd._id_analytic);                                        
        }
    }
}
