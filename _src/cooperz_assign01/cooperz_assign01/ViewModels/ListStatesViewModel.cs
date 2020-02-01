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
    }

    //Create a List of states
    public static class ListStatesViewModel
    {
        //populate list using object initializer syntax
        public static List<State> StateList = new List<State> {
        new State () {StateName = "Alaska", StateAbbr = "AK"  },
        new State () {StateName = "California", StateAbbr = "CA"  },
        new State () {StateName = "Idaho", StateAbbr = "ID"  },
        new State () {StateName = "Montana", StateAbbr = "MT"  },
        new State () {StateName = "Oregon", StateAbbr = "OR"  },
        new State () {StateName = "Washington", StateAbbr = "WA"  }
        };
    }
}