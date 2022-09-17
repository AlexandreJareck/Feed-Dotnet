using Feed.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feed.Data.Mappings;

public class AuthorMapping : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.AvatarUrl)
            .IsRequired()
            .HasMaxLength(255);

        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(p => p.Role)
            .HasMaxLength(255);
    }
}
