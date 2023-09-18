using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityMapper
{
    public class ArticleExtensionMap : IEntityTypeConfiguration<ArticleExtension>
    {
        public void Configure(EntityTypeBuilder<ArticleExtension> builder)
        {
            builder.HasKey(x => x.ArticleExtensionID);
            builder.Property<int>(x => x.ArticleExtensionID).ValueGeneratedOnAdd();
            builder.Property(x => x.MediaURL).IsRequired(false);
            builder.Property(x => x.TextContent).IsRequired(false);

            //   builder.HasOne(x => x.Article).WithMany(y => y.ArticleExtensions).HasForeignKey(x=>x.ArticleID).OnDelete(DeleteBehavior.NoAction);
            //  builder.HasOne(x => x.ArticleExtensionType).WithMany(y => y.ArticleExtensions).HasForeignKey(x => x.ArticleExtensionTypeID).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
