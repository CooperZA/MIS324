using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cooperz_assign01.Models
{
    public class BigWebFormModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; } //textbox

        [Required]
        public string Gender { get; set; } // radioButtonList

        [Required]
        [Display(Name = "State")]
        public string StateAbbr { get; set; } //dropdown list

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; } //textbox

        [Display(Name = "Seahawk Fan?")]
        public bool IsSeaHawkFan { get; set; } //checkbox

        public int PersonId { get; set; } //hidden
    }
}