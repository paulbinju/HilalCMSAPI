using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class EventDTO
    {
        public int EventID { get; set; }
        public string EventTitle { get; set; }
        public string? EventDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CountryID { get; set; }
        public string? City { get; set; }
        public string? Venue { get; set; }
        public string? EventImage { get; set; }
        public IFormFile? EventImageFile { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public int? UserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Active { get; set; }
    }
}
