using FitnessFoods.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessFoods.Infrastructure.Data.Repository.Interfaces
{
    public interface IProductRepository
    {
        //Task GetApiDetails(); // TODO
        Task InsertProducts(List<Product> products);
        Task<List<Product>> GetProducts(int? page);
        Task<Product> GetProduct(string code);
        Task UpdateProduct(string code, Product product);
        Task<int> DeleteProduct(Product product);
    }
}
