using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NS.WEB.DATABASE.Entities
{
    public partial class DishTable
    {
        public long DishId { get; set; }
        public string DishName { get; set; }
        public string DishOrigin { get; set; }
        public string DishPrice { get; set; }
        public string DishDescription { get; set; }
        public string DishCategory { get; set; }
        public bool DishStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ImgUrl { get; set; }


        [NotMapped]
        public IFormFile DishPhoto { get; set; }

    
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
