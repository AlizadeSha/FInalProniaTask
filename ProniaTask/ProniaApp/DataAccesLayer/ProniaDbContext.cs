using Microsoft.EntityFrameworkCore;
using ProniaApp.Models;

namespace ProniaApp.DataAccesLayer
{
    public class ProniaDbContext : DbContext
    {
        public ProniaDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Product> Products { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=DESKTOP-R20TAJ1\\SQLEXPRESS;Database=ProniaShahinTask;Trusted_Connection=true;TrustServerCertificate=True"); ;
            base.OnConfiguring(options);
        }
    }
}
