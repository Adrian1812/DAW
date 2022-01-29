using Microsoft.EntityFrameworkCore;
using ProiectDAW.DAL.Entities;
using ProiectDAW.DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Repositories.ProductRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public async Task<Product> GetByName(string name)
        {
            return await _context.Products.Where(a => a.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetAllProductsOrderByDealer()
        {
            return await _context
                .Products
                .Include(x => x.Dealer)
                .OrderBy(x => x.Dealer)
                .ToListAsync();
        }
    }
}
