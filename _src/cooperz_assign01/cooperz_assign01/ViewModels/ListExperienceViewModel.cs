using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cooperz_assign01.ViewModels.ListExperienceViewModel
{
    public class Experience
    {
        public string Level { get; set; }
        public double Surcharge { get; set; }
    }
    public class ListExperienceViewModel
    {
        public static List<Experience> ExperienceLevel = new List<Experience>
        {
            new Experience() { Level = "Beginner (no surcharge)", Surcharge = 0 },
            new Experience() { Level = "Intermediate (10% surcharge)", Surcharge = 0.1 },
            new Experience() { Level = "Knuckle-dragger (20% surcharge)", Surcharge = 0.2},
            new Experience() { Level = "Out-of-control (30% surcharge)", Surcharge = 0.3}
        };
    }
}