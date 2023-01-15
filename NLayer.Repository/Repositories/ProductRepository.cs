using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRespository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            //Eager Loading =>Datalari cekerken Category bilgisi de gelir.
            //Lazy Loading =>Category bilgisini daha sonra ihtiyac oldugunda cekersek lazy loading olur.
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
