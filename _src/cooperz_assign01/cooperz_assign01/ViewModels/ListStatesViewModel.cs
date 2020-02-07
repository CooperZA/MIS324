using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cooperz_assign01.ViewModels.ListStatesViewModel
{
    public class State
    {
        public string StateName { get; set; }
        public string StateAbbr { get; set; }
        public double TaxRate { get; set; }
    }

    //Create a List of states
    public static class ListStatesViewModel
    {
        //populate list using object initializer syntax
        public static List<State> StateList = new List<State> {
        new State () {StateName = "Alaska", StateAbbr = "AK", TaxRate = 0.0169  },
        new State () {StateName = "California", StateAbbr = "CA", TaxRate = 0.0841 },
        new State () {StateName = "Idaho", StateAbbr = "ID", TaxRate = 0.0602 },
        new State () {StateName = "Montana", StateAbbr = "MT", TaxRate = 0  },
        new State () {StateName = "Oregon", StateAbbr = "OR", TaxRate = 0 },
        new State () {StateName = "Washington", StateAbbr = "WA", TaxRate = 0.0887 }
        };
    }
}