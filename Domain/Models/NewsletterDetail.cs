using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class NewsletterDetail
    {
        public int NewsletterDetailID { get; set; }
        public int NewsletterID { get; set; }
        public int CategoryID { get; set; }
        public int ArticleID { get; set; }
    }
}
