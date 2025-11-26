using System.ComponentModel.DataAnnotations.Schema;

namespace TivraShopMVC.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Uid { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; } // سعر المنتج وقت الشراء


    }
}
