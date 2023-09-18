using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class ArticleExtensionDTO
    {
        public int ArticleExtensionID { get; set; }
        public string? MediaURL { get; set; }
        public IFormFile? imageURL { get; set; }
        public string? TextContent { get; set; }
        public int ExtensionOrder { get; set; }
        public int ArticleID { get; set; }
        public int ArticleExtensionTypeID { get; set; }
    }
}
