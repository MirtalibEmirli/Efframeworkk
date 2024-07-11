using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eftaskk
{
    public class MarketDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
        }
        public DbSet<Category> Category { get; set; }
        public  DbSet<Product> Product { get; set; }
    }
}
