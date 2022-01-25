using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
