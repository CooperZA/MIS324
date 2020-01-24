using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cooperz_assign01.Models
{
    public class CalculatorModel
    {
        [Required] public int ValueA { get; set; }
        [Required] public int ValueB { get; set; } 
    }
}