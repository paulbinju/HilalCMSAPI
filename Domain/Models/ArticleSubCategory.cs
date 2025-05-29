using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ArticleSubCategory
    {
        public int ArticleSubCategoryID { get; set; }
        public int ArticleID { get; set; }
        public int SubCategoryID { get; set; }
    }
}
