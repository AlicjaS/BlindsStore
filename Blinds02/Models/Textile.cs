using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blinds02.Models
{
    public class Textile
    {
        public int TextileID { get; set; }
        public string TextileName { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double TextilePrice { get; set; }
    }
}