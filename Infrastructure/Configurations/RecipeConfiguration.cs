using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("Recipes")
                .HasKey(item => item.RecipeId);
            builder.Property(item => item.RecipeId)
                .HasColumnName("Id");
            builder.Property(item => item.RecipeName).IsRequired();
            builder.Property(item => item.RecipeDescription).IsRequired();
            builder.Property(item => item.PersonNumber).IsRequired();
            builder.Property(item => item.CookingTime).IsRequired();
        }
    }
}
