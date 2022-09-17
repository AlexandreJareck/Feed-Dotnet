using Feed.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feed.Data.Context
{
    public class FeedDbContext : DbContext
    {
        public FeedDbContext(DbContextOptions<FeedDbContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Content> Contents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            {
                property.SetMaxLength(250);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
