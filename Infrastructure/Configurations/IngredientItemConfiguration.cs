using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class IngredientItemConfiguration : IEntityTypeConfiguration<IngredientItem>
    {
        public void Configure(EntityTypeBuilder<IngredientItem> builder)
        {
            builder.ToTable("IngredientItems")
                .HasKey(item => item.Id);
            builder.Property(item => item.Id)
                .HasColumnName("Id");
            builder.Property(x => x.IngredientItemName).IsRequired();
            builder.Property(x => x.Products).IsRequired();
        }
    }
}
