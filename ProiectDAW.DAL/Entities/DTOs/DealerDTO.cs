using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Entities.DTOs
{
    public class DealerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public List<Product> Products { get; set; }

        public DealerDTO(Dealer dealer)
        {
            this.Id = dealer.Id;
            this.Name = dealer.Name;
            this.Address = dealer.Address;
            this.Products = new List<Product>();
        }
    }
}
