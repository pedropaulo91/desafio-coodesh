using FitnessFoods.Domain.Entities;
using FitnessFoods.Infrastructure.Data.Repository.Interfaces;
using FitnessFoods.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessFoods.Service
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task InsertProducts(List<Product> products)
        {
            await _repository.InsertProducts(products);
        }

        public async Task<List<Product>> GetProducts(int? page)
        {
            return await _repository.GetProducts(page);
        }
        public async Task<Product> GetProduct(string code)
        {
            return await _repository.GetProduct(code);
        }

        
        public async Task<Product> UpdateProduct(string code, Product product)
        {
            var result = await GetProduct(code);

            if(result != null)
            {
                await _repository.UpdateProduct(code, product);
                return product;
            }

            return null;
        
        }

        // TODO: Refatorar para verificar se um produto existe 
        public async Task<int> DeleteProduct(string code)
        {

            var product = await GetProduct(code);

            if (product == null)
                return 0;

            return await _repository.DeleteProduct(product);

        }

    }
}
