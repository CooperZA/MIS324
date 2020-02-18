using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cooperz_assign01.Models
{
    public class ColorModel
    {
        [Key]
        public string ColorID { get; set; }
        [Required]
        public string ColorName { get; set; }
    }
}