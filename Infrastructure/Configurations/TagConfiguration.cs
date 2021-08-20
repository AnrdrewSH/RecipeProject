using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags")
                .HasKey(item => item.Id);
            builder.Property(item => item.Id)
                .HasColumnName("Id");
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
