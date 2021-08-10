using Microsoft.EntityFrameworkCore;
using Recipe_Api.Data.DbInfrasructure;
using Recipe_Api.Dblnfrastructure;

namespace Recipe_Api.Data
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
        public void Commit()
        {
            SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeConfiguration());        
        }
    }
}
