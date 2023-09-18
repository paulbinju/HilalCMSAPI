using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
        public int? RefNo { get; set; }
        public int PublicationID { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
 