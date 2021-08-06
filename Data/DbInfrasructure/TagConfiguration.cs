using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe_Api.Data.Entities;


namespace Recipe_Api.Data.DbInfrasructure
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags")
                .HasKey(item => item.Id);
            builder.Property(item => item.Id)
                .HasColumnName("Id");
        }
    }
}
