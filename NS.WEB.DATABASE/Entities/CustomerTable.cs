using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NS.WEB.DATABASE.Entities
{
    public partial class CustomerTable
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CityName { get; set; }
        public string CustomerAddress { get; set; }
        public string ZipCode { get; set; }
        public string Password { get; set; }
        public bool? IsEmailConfirmed { get; set; }
        public DateTime CreatedOn { get; set; }
        public string State { get; set; }
        public string RoleType { get; set; }
        public string ImgUrl { get; set; }

        [NotMapped]
        public IFormFile UserPhoto { get; set; }
    }
}
