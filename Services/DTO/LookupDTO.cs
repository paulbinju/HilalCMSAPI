using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class LookupDTO
    {
        public string GroupName { get; set; }
        public string Title { get; set; }
        public int OrderNo { get; set; }
        public bool Active { get; set; }
    }
}
