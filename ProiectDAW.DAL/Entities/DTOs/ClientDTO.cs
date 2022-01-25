using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Entities.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Order> Orders { get; set; }


        public ClientDTO(Client client)
        {
            this.Id = client.Id;
            this.Name = client.Name;
            this.Age = client.Age;
            this.Orders = new List<Order>();
        }

    }
}
