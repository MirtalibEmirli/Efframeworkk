using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eftask2.Models;
using Microsoft.EntityFrameworkCore;
namespace Eftask2.Data
{
    public class LibraryDbcontext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(e => e.IdAuthor)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
            .HasMany(e => e.Books)
            .WithOne(a => a.Category)
            .HasForeignKey(a => a.IdCategory)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        }



    }
}
