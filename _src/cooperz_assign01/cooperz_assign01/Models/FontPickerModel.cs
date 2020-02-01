using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cooperz_assign01.Models
{
    public class FontPickerModel
    {
        // message var
        [Required(ErrorMessage = "Message is Required")]
        public string Message { get; set; }

        // FontID var
        [Required]
        public string FontID { get; set; }

        // constructor sets initial message
        public FontPickerModel()
        {
            FontID = "ChunkRed";
            Message = "The quick brown foxjumps over the lazy dog";
        }
    }
}