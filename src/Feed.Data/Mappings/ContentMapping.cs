using Feed.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feed.Data.Mappings;

public class ContentMapping : IEntityTypeConfiguration<Content>
{
    public void Configure(EntityTypeBuilder<Content> builder) 
    {
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Type)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(p => p.Comment)
            .IsRequired()
            .HasMaxLength(1000);
    }
}
