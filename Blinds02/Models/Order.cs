using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinds02.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public int? CustomerID { get; set; }
        public Customer Customer { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DeliveryDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? OrderValue { get; set; }

        public void UpdateOrderValue()
        {
            this.OrderValue = 0;
            foreach (var item in OrderItems)
            {
                this.OrderValue += item.Price;
            }
            this.OrderValue = Math.Round(this.OrderValue.Value, 2);
        }
    }
}
