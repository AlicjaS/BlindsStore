using System.ComponentModel.DataAnnotations;

namespace Blinds02.Models
{
    public class Textile
    {
        public int TextileID { get; set; }

        [Required]
        public string TextileName { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00 zł}")]
        public double TextilePrice { get; set; }
    }
}