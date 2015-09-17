using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinds02.Models
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }

        public int BlindItemID { get; set; }
        public BlindItem BlindItem { get; set; }

        public int Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }

        public void UpdatePrice(BlindItem blindItem)
        {
            this.Price = Math.Round(blindItem.Price * this.Quantity, 2);
        }
    }
}
