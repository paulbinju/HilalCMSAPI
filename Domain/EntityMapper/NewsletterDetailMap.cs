using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityMapper
{
    public class NewsletterDetailMap : IEntityTypeConfiguration<NewsletterDetail>
    {
        public void Configure(EntityTypeBuilder<NewsletterDetail> builder)
        {
            builder.HasKey(x => x.NewsletterDetailID);
            builder.Property(x => x.NewsletterDetailID).ValueGeneratedOnAdd();
        }
    }
}
