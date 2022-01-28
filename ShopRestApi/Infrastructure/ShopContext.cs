using Microsoft.EntityFrameworkCore;
using ShopRestApi.Entities;
using ShopRestApi.Infrastructure.EntityMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRestApi.Infrastructure
{
    public class ShopContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var assembly = typeof(ProductMap).Assembly;
        //    modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
