using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cooperz_assign01.Models
{
    public class CrudModel
    {
        [Key]
        public int PersonID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
    }
}