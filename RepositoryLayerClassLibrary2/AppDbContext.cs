using DomainlayerClassLibrary1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayerClassLibrary2
{
    public class AppDbContext : DbContext
    {
       

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> tblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Server=(localdb)\\localDB;Database=NewDBS; Trusted_Connection=true;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }


}

