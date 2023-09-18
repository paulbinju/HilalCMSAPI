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
    public class IssueMap : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.HasKey(x => x.IssueID);
            builder.Property(x => x.IssueID).ValueGeneratedOnAdd();
        }
    }
}
