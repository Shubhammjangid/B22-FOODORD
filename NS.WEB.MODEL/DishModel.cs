using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NS.WEB.MODEL
{
    public class DishModel
    {
        public long DishId { get; set; }

        [Required(ErrorMessage = "Please write the dish name")]
        [Display(Name = "Dish Name")]
        public string DishName { get; set; }

        [Required(ErrorMessage = "Please choose the origin")]
        [Display(Name = "Type")]
        public string DishOrigin { get; set; }

        [Required(ErrorMessage = "Please add price ")]
        [Display(Name = "Price")]
        public string DishPrice { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(500, MinimumLength = 30)]
        public string DishDescription { get; set; }
        [Display(Name = "Category")]
        public string DishCategory { get; set; }
        public bool DishStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }

        [NotMapped]
        public IFormFile DishPhoto { get; set; }
        public string ImgUrl { get; set; }

        public enum Origin
        {
            Indian = 1,
            Chinese = 2,
            Italian = 3,
            Australian = 4,
            Thai = 5
        }


    }
}
