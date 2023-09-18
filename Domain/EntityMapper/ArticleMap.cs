using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityMapper
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.ArticleID);
            builder.Property(x => x.ArticleID).ValueGeneratedOnAdd();
            builder.Property(x => x.IssueID).IsRequired(false);
            builder.Property(x => x.Dateline).IsRequired(false);
            builder.Property(x => x.Byline).IsRequired(false);
            builder.Property(x => x.Slug).IsRequired(false);
            builder.Property(x => x.ArticleBody).IsRequired(false);
            builder.Property(x => x.FeaturedImageURL).IsRequired(false);
            builder.Property(x => x.FeaturedImageCaption).IsRequired(false);
            builder.Property(x => x.Tags).IsRequired(false);
            builder.Property(x => x.CountryID).IsRequired(false);
            builder.Property(x => x.CategoryID).IsRequired(false);
            builder.Property(x => x.SubCategoryID).IsRequired(false);
            builder.Property(x => x.IssueID).IsRequired(false);
            builder.Property(x => x.RefNo).IsRequired(false);

            //  builder.HasOne(x => x.Author).WithMany(y => y.Articles).HasForeignKey(x => x.AuthorID).OnDelete(DeleteBehavior.ClientCascade);
            //builder.HasOne(x => x.Issue).WithMany(y => y.Articles).HasForeignKey(x => x.IssueID).OnDelete(DeleteBehavior.ClientCascade);


        }
    }
}
