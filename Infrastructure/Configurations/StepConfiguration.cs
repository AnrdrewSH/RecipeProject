using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class StepConfiguration : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.ToTable("Steps")
                .HasKey(item => item.Id);
            builder.Property(item => item.Id)
                .HasColumnName("Id");
            builder.Property(x => x.StepDescription).IsRequired();
        }
    }
}
