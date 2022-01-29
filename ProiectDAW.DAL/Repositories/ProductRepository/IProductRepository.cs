using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectDAW.DAL.Entities;
using ProiectDAW.DAL.Repositories.GenericRepository;

namespace ProiectDAW.DAL.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetByName(string name);
        Task<List<Product>> GetAllProductsOrderByDealer();
    }
}
