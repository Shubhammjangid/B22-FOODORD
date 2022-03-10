using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NS.WEB.MODEL
{
    public class UserModel
    {
        public long CustomerId { get; set; }

        [Required]
        [Display(Name ="Full Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage ="Enter your Email")]
        [EmailAddress]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage ="Phone number is required")]
        [DataType(DataType.PhoneNumber)]
        public string CustomerPhone { get; set; }

        [Required(ErrorMessage ="Enter CityName to register")]
        public string CityName { get; set; }

        [Required(ErrorMessage ="Address is required to register")]
        public string CustomerAddress { get; set; }

        [Required(ErrorMessage ="Zipcode is equired")]
        public string ZipCode { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Enter your password")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Enter same password as above")]
        [Required(ErrorMessage ="Enter password again to confirm")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public bool? IsEmailConfirmed { get; set; }
        public DateTime CreatedOn { get; set; }

        [Required(ErrorMessage ="Required state")]
        public string State { get; set; }
        public string RoleType { get; set; }
        public string ImgUrl { get; set; }


        [NotMapped]
        public IFormFile UserPhoto { get; set; }
    }
}
