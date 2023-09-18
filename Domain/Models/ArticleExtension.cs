using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ArticleExtension
    {
        public int ArticleExtensionID { get; set; }
        public string MediaURL { get; set; }
        public string TextContent { get; set; }
        public int ExtensionOrder { get; set; }
        public int ArticleID { get; set; }
        public int ArticleExtensionTypeID { get; set; }
        public virtual Article Article { get; set; }
        //    public virtual Lookup ArticleExtensionType { get; set; }
    }
}
