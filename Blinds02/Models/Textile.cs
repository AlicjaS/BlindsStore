using System.ComponentModel.DataAnnotations;

namespace Blinds02.Models
{
    public class Textile
    {
        public int TextileID { get; set; }

        [Required]
        public string TextileName { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double TextilePrice { get; set; }
    }
}