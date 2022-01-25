using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Entities.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }

        public AddressDTO(Address address)
        {
            this.Id = address.Id;
            this.City = address.City;
            this.Street = address.Street;
            this.Country = address.Country;
            this.DealerId = address.DealerId;
            this.Dealer = address.Dealer;
        }
    }


}
