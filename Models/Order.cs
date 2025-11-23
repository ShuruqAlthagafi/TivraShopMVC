using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TivraShopMVC.Models
{
    public class Order
    {
        public int Id { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public double TotalAmount { get; set; }

        [Required]
        public string Status { get; set; } = "Pending"; // Pending / Paid / Shipped / Cancelled

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
