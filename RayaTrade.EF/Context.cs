using Microsoft.EntityFrameworkCore;
using RayaTrade.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayaTrade.EF
{
    public class Context:DbContext
    {
        public Context()
        {
            
        }
        public Context(DbContextOptions<Context> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(e=>e.Name).IsUnique();
        }
        public DbSet<Product> products { get; set; }
    }
}
