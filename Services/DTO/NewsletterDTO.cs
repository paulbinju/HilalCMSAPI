using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class NewsletterDTO
    {
        public int NewsletterID { get; set; }
        public int PublicationID { get; set; }
        public string Publication { get; set; }
        public DateTime NewsletterName { get; set; }
        public bool Generated { get; set; }
    }
}
