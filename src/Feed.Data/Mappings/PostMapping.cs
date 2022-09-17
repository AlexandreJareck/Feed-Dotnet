using Feed.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feed.Data.Mappings;

public class PostMapping : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.PublishedAt)
            .IsRequired();        
    }
}
