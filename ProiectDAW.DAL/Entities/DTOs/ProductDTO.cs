using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Entities.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }
        public List<Order> Orders { get; set; }

        public ProductDTO(Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Price = product.Price;
            this.DealerId = product.DealerId;
            this.Dealer = product.Dealer;
            this.Orders = new List<Order>();
        }
    }
}
