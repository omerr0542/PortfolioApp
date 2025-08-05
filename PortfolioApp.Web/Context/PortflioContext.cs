using Microsoft.EntityFrameworkCore;
using PortfolioApp.Web.Entities;

namespace PortfolioApp.Web.Context
{
    public class PortflioContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Faruk;Database=PortfolioAppDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<About> Abouts { get; set; } 
        public DbSet<Banner> Banners { get; set; } 
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Education> Educations { get; set; } 
        public DbSet<Experience> Experiences { get; set; } 
        public DbSet<Project> Projects { get; set; } 

    }
}
