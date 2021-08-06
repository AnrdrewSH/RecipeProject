using Microsoft.EntityFrameworkCore;
using Recipe_Api.Data.DbInfrasructure;
using Recipe_Api.Data.Entities;
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
            modelBuilder.ApplyConfiguration(new StepConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientItemConfiguration());
        }


        public DbSet<Step> Steps { get; set; }
        //public DbSet<Recipe> Recipe { get; set; }
        //public DbSet<Tag> Tag { get; set; }




    }
}
