using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TivraShopMVC.Models
{
    public class Product
    {
        [Key] 
        public int Id { get; set; }

       
        public string Name { get; set; }

        public string? Description { get; set; }


        public decimal Price { get; set; }  

        public int Stock { get; set; } = 0; 

   
        public string? ImageUrl { get; set; } 

        public DateTime DateCreated { get; set; } = DateTime.Now; 

   
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }

    }
}
