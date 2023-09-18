using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class NewsletterDetailDTO
    {
        public int NewsletterID { get; set; }
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public int ArticleID { get; set; }
        public string ArticleTitle { get; set; }

    }
}
