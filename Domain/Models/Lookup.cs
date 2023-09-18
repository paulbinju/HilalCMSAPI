using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Lookup
    {
        public int LookupID { get; set; }
        public string GroupName { get; set; }
        public string Title { get; set; }
        public int OrderNo { get; set; }
        public bool Active { get; set; }
        public ICollection<User> Users { get; set; }
    //    public ICollection<ArticleExtension> ArticleExtensions { get; set; }
   //     public ICollection<Category> Categories { get; set; }

        public ICollection<Article> Articles { get; set; }

    }
}
