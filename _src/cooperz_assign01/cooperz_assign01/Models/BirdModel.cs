using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cooperz_assign01.Models
{
    public class BirdModel
    {
        [Key]
        public int BirdID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Image Name")]
        public string ImageName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}