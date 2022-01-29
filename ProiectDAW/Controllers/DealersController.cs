using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectDAW.DAL;
using ProiectDAW.DAL.Entities.DTOs;
using ProiectDAW.DAL.Entities;
using ProiectDAW.DAL.Repositories.DealerRepository;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealersController : ControllerBase
    {
        private readonly IDealerRepository _repository;


        public DealersController(IDealerRepository repository)
        {
            _repository = repository;
        }

        //read
        [HttpGet]
        public async Task<IActionResult> GetAllDealers()
        {
            var dealers = await _repository.GetAllDealersWithAddress();

            var dealersToReturn = new List<DealerDTO>();

            foreach (var dealer in dealers)
            {
                dealersToReturn.Add(new DealerDTO(dealer));
            }

            return Ok(dealersToReturn);
        }


        //create
        [HttpPost]
        public async Task<IActionResult> CreateDealer(DealerDTO dto)
        {
            Dealer newDealer = new Dealer();

            newDealer.Name = dto.Name;
            newDealer.Address = dto.Address;
            newDealer.Id = dto.Id;
            newDealer.Products = dto.Products;

            _repository.Create(newDealer);

            await _repository.SaveAsync();

            return Ok(new DealerDTO(newDealer));
        }

        [HttpDelete("DeleteDealer/{id}")]
        public async Task<IActionResult> DeleteDealer([FromRoute] int id)
        {
            var dealer = await _repository.GetByIdAsync(id);
            _repository.Delete(dealer);
            await _repository.SaveAsync();

            return Ok(dealer);
        }

        [HttpPut("UpdateDealer/{id}")]
        public async Task<IActionResult> UpdateClient([FromBody] Dealer updatedDealer, [FromRoute] int id)
        {
            var dealer = await _repository.GetByIdAsync(id);
            _repository.Delete(dealer);
            _repository.Create(updatedDealer);
            await _repository.SaveAsync();

            return Ok(updatedDealer);
        }
    }
}
