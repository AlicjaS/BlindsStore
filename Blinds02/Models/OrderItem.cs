using System;
using System.ComponentModel.DataAnnotations;

namespace Blinds02.Models
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }

        public int OrderID { get; set; }
        public virtual Order Order { get; set; }

        public int BlindItemID { get; set; }
        public virtual BlindItem BlindItem { get; set; }

        public int Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00 zł}")]
        public double Price { get; set; }

        public void UpdatePrice(BlindItem blindItem)
        {
            this.Price = Math.Round(blindItem.Price * this.Quantity, 2);
        }
    }
}
