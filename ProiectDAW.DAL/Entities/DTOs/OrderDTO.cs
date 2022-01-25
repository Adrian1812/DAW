using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Entities.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Client Client { get; set; }

        public OrderDTO(Order order)
        {
            this.Id = order.Id;
            this.ClientId = order.ClientId;
            this.ProductId = order.ProductId;
            this.Product = order.Product;
            this.Client = order.Client;
        }
    }
}
