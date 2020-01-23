using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cooperz_assign01.Models
{
    public class PersonFormModel
    {
        [Required(ErrorMessage = "Please enter a name.")] public string Fname { get; set; } 
        public int Age { get; set; }
        public bool IsSeahawkFan { get; set; }
    }
}