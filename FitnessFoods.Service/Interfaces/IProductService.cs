using FitnessFoods.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessFoods.Service.Interfaces
{
    public interface IProductService
    {
        Task InsertProducts(List<Product> products);
        Task<List<Product>> GetProducts(int? page);
        Task<Product> GetProduct(string code);
        Task<Product> UpdateProduct(string code, Product product);
        Task<int> DeleteProduct(string code);

    }
}
