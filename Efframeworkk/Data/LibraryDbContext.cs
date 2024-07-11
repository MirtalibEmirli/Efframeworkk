//Microsoft.EntityFrameworkCore.SqlServer bunu yukle
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Efframeworkk.Data;

public  class LibraryDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
    }
   public DbSet<Author> Authors { get; set; }
}
