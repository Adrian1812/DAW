using Microsoft.EntityFrameworkCore;
using ProiectDAW.DAL.Entities;
using ProiectDAW.DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Repositories.DealerRepository
{
    public class DealerRepository : GenericRepository<Dealer>, IDealerRepository
    {

        public DealerRepository(AppDbContext context) : base(context) { }
        public async Task<List<Dealer>> GetAllDealersWithAddress()
        {
            return await _context.Dealers.Include(a => a.Address).ToListAsync();
        }

        public async Task<Dealer> GetByName(string name)
        {
            return await _context.Dealers.Where(a => a.Name.Equals(name)).FirstOrDefaultAsync();
        }

    }
}
