using System.Data.Entity;

namespace Blinds02.Models
{
    public class Blinds02Context : DbContext
    {
        public Blinds02Context() : base("name=Blinds02Context")
        {
        }

        public DbSet<Textile> Textiles { get; set; }

        public DbSet<BlindItem> BlindItems { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
