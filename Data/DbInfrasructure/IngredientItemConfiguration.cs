using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe_Api.Data.Entities;

namespace Recipe_Api.Data.DbInfrasructure
{
    public class IngredientItemConfiguration : IEntityTypeConfiguration<IngredientItem>
    {
        public void Configure(EntityTypeBuilder<IngredientItem> builder)
        {
            builder.ToTable("IngredientItems")
                .HasKey(item => item.Id);
            builder.Property(item => item.Id)
                .HasColumnName("Id");
        }
    }
}
