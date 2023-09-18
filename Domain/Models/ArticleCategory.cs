using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ArticleCategory
    {
        public int ArticleCategoryID { get; set; }
        public int ArticleID { get; set; }
        public int CategoryID { get; set; }
    }
}
