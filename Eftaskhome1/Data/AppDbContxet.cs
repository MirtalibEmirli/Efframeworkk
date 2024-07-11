using Eftaskhome1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eftaskhome1.Data;

    public class AppDbContxet:DbContext
    {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    }

    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }


}
