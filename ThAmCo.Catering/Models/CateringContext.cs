using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.Models
{
    public class CateringContext : DbContext
    {
        public DbSet<FoodBooking> FoodBooking { get; set; }

        public DbSet<FoodItem> FoodItem { get; set; }

        public DbSet<MenuFoodItem> MenuFoodItem { get; set; }
        public DbSet<Menu> Menu { get; set; }

        private readonly IHostEnvironment _hostEnv;

        public CateringContext(DbContextOptions<CateringContext> options,
                       IHostEnvironment env) : base(options)
        {
            _hostEnv = env;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MenuFoodItem>()
                .HasKey(a => new { a.MenuId, a.FoodItemId });
        }
    }
}
