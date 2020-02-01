using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cooperz_assign01.ViewModels.FontPickerViewModel
{
    public class Font
    {
        public string FontName { get; set; }
        public string FontID { get; set; }
    }


    //Create a List of states
    public static class FontPickerViewModel
    {
        //populate list using object initializer syntax
        public static List<Font> FontList = new List<Font> {
            new Font () {FontName = "Chunk Red", FontID = "ChunkRed"  },
            new Font () {FontName = "Deco Blue", FontID = "DecoBlue"  },
            new Font () {FontName = "Animals", FontID = "Animals"  },
            new Font () {FontName = "Elegant Red", FontID = "ElegantRed"  },
            new Font () {FontName = "Funky", FontID = "Funky"  },
            new Font () {FontName = "Tape Punch", FontID = "TapePunch"  }
        };

    }

}