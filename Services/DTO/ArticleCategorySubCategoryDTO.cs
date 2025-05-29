using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class ArticleCategorySubCategoryDTO
    {
        public int? ArticleCategorySubCategoryID { get; set; }
        public int ArticleID { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
    }
}
