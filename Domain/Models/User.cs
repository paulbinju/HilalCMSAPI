using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public Lookup Role { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
