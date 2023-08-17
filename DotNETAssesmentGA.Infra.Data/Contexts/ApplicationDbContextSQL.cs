using DotNETAssesmentGA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNETAssesmentGA.Infra.Data.Contexts
{
    public class ApplicationDbContextSQL : DbContext
    {
        public ApplicationDbContextSQL(DbContextOptions<ApplicationDbContextSQL> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContextSQL).Assembly);
        }
    }
}