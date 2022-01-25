using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectDAW.DAL;
using ProiectDAW.DAL.Entities.DTOs;
using ProiectDAW.DAL.Entities;
using ProiectDAW.DAL.Repositories.ClientRepository;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _repository;


        public ClientsController(IClientRepository repository)
        {
            _repository = repository;
        }

        //read
        [HttpGet("GetClientByName/{name}")]
        public async Task<IActionResult> GetAllClients([FromRoute]string name)
        {
            var clients = await _repository.GetByName(name);

            return Ok(clients);
        }

        //create
        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientDTO dto)
        {
            Client newClient = new Client();

            newClient.Name = dto.Name;
            newClient.Age = dto.Age;
            newClient.Id = dto.Id;
            newClient.Orders = dto.Orders;

            _repository.Create(newClient);

            await _repository.SaveAsync();

            return Ok(new ClientDTO(newClient));
        }

        [HttpDelete("DeleteClient/{id}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            var client = await _repository.GetByIdAsync(id);
            _repository.Delete(client);
            await _repository.SaveAsync();

            return Ok(client);
        }

        [HttpPut("UpdateClient/{id}")]
        public async Task<IActionResult> UpdateClient([FromBody] Client updatedClient, [FromRoute] int id)
        {
            var client = await _repository.GetByIdAsync(id);
            _repository.Delete(client);
            _repository.Create(updatedClient);
            await _repository.SaveAsync();

            return Ok(updatedClient);
        }
    }
}
