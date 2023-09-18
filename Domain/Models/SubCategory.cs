using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SubCategory
    {
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryID { get; set; }
        public int PublicationID { get; set; }
        public int ArticleTypeID { get; set; }

    }
}
