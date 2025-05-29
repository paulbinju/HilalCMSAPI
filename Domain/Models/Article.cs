using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Article
    {
        public int ArticleID { get; set; }
        public string? Dateline { get; set; }
        public string? Byline { get; set; }
        public string? Slug { get; set; }
        public string Title { get; set; }
        public string? ArticleBody { get; set; }
        public string? FeaturedImageURL { get; set; }
        public string? FeaturedImageCaption { get; set; }
        public string? Tags { get; set; }
        public int? CountryID { get; set; }
        public int ArticleTypeID { get; set; }
        public int PublicationID { get; set; }
        public int AuthorID { get; set; }
        public int? IssueID { get; set; }
        public int? RefNo { get; set; }
        public bool ShowInTA { get; set; }
        public bool ShowInMAG { get; set; }
        public string? PREmails { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Published { get; set; }
        public DateTime? PublishedDate { get; set; }
        public ICollection<ArticleExtension>? ArticleExtensions { get; set; }

    }

}
