using System.ComponentModel.DataAnnotations;

namespace TivraShopMVC.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; } = "User"; 

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public ICollection<Order>? Orders { get; set; }
      
    }
}
