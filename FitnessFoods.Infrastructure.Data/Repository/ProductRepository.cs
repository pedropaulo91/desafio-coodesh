using FitnessFoods.Domain.Entities;
using FitnessFoods.Domain.Enums;
using FitnessFoods.Infrastructure.Data.Context;
using FitnessFoods.Infrastructure.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace FitnessFoods.Infrastructure.Data.Repository
{
    public class ProductRepository: IProductRepository
    {

        private readonly SqlServerContext _context;

        public ProductRepository(SqlServerContext context)
        {
            _context = context;
        }

        public async Task InsertProducts(List<Product> products)
        {
            await _context.Products.AddRangeAsync(products);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProducts(int? page)
        {
            const int itemsPerPage = 30;
            int pageNumber = page ?? 1;

            var pagedList = await _context.Products.AsNoTracking().ToPagedListAsync(pageNumber, itemsPerPage);

            return await pagedList.ToListAsync(); 
        }

        public async Task<Product> GetProduct(string code)
        {
            return await _context.Products.AsNoTracking().Where(p => p.Code.Equals(code)).FirstOrDefaultAsync();
        }

        public async Task UpdateProduct(string code, Product product)
        {
            _context.Entry<Product>(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteProduct(Product product)
        {
            product.Status = Status.Trash;
            _context.Entry<Product>(product).State = EntityState.Modified;

            return await _context.SaveChangesAsync();
        }

    }
}
