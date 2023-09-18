using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Newsletter
    {
        public int NewsletterID { get; set; }
        public int PublicationID { get; set; }
        public DateTime NewsletterName { get; set; }
        public bool Generated { get; set; }
    }
}
