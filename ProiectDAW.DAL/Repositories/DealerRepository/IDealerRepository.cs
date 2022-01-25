using ProiectDAW.DAL.Entities;
using ProiectDAW.DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Repositories.DealerRepository
{
    public interface IDealerRepository : IGenericRepository<Dealer>
    {
        Task<Dealer> GetByName(string name);
        Task<List<Dealer>> GetAllDealersWithAddress();
    }
}
