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
    public class ArticleSubCategoryMap : IEntityTypeConfiguration<ArticleSubCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleSubCategory> builder)
        {
            builder.HasKey(x => x.ArticleSubCategoryID);
            builder.Property(x => x.ArticleSubCategoryID).ValueGeneratedOnAdd();
        }
    }
}
