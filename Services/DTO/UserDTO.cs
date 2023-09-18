using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? EmailID { get; set; }
        public string? Password { get; set; }
        public int RoleID { get; set; }
        public string? Title { get; set; }
    }
}
