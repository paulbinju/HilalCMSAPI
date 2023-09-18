using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityMapper
{
    public class NewsletterMap : IEntityTypeConfiguration<Newsletter>
    {
        public void Configure(EntityTypeBuilder<Newsletter> builder)
        {
            builder.HasKey(x => x.NewsletterID);
            builder.Property(x => x.NewsletterID).ValueGeneratedOnAdd();
            builder.Property(x => x.Generated).HasAnnotation("Default", false);
        }
    }
}
