using System;
using System.ComponentModel.DataAnnotations;

namespace Blinds02.Models
{
    public class BlindItem
    {
        public int BlindItemID { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }

        public string Name { get; set; }

        [RangeAttribute(0.3, 1.7)]
        public double Width { get; set; }

        [RangeAttribute(0.7, 2.2)]
        public double Height { get; set; }

        public int TextileID { get; set; }
        public virtual Textile Textile { get; set; }

        public void UpdateItem(Textile textile)
        {
            this.Name = String.Format("Blind_{0}_W{1:0.000}H{2:0.000}", textile.TextileName, this.Width, this.Height);
            this.Price = 58 + this.Height * 10.8 + this.Width * 38 + this.Height * this.Width * textile.TextilePrice;
            this.Price = Math.Round(this.Price, 2);
        }
    }
}