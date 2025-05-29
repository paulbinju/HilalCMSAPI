using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class IssueDTO
    {
        public int IssueID { get; set; }
        public int RefNo { get; set; }
        public int PublicationID { get; set; }
        public string Publication { get; set; }
        public string IssueNo { get; set; }
        public string Volume { get; set; }
        public string IssueName { get; set; }
        public DateTime IssueDate { get; set; }
        public bool Published { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
