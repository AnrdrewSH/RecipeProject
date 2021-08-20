using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientItemConfiguration());
            modelBuilder.ApplyConfiguration(new StepConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
        }
    }
}
