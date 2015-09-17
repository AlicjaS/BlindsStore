using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blinds02.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }

        [Display(Name = "Email address")]
        [EmailAddress()]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Numer telefonu jest niepoprawny.")]
        public string Mobile { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
