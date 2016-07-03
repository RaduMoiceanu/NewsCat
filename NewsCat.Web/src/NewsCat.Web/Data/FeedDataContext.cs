using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NewsCat.Web.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsCat.Web.Data
{
    public class FeedDataContext : ApplicationDbContext
    {
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Tag> Tags { get; set; }


        public FeedDataContext(DbContextOptions<FeedDataContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Document>()
                   .HasIndex(d => new { d.FeedId });
        }
    }
}
