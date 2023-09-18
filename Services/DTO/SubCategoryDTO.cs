using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class SubCategoryDTO
    {
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int PublicationID { get; set; }
        public string Publication { get; set; }
        public int ArticleTypeID { get; set; }
        public string ArticleType { get; set; }
    }
}
