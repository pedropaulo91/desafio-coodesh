using FitnessFoods.Domain.Entities;
using FitnessFoods.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FitnessFoods.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiKey]
    public class FitnessFoodsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IImportHistoryService _importHistoryService;
        

        public FitnessFoodsController(IProductService productService, IImportHistoryService importHistoryService)
        {
            _productService = productService;
            _importHistoryService = importHistoryService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> GetApiDetails()
        {
            try
            {
                var importHistory = await _importHistoryService.GetHistory();
                return Ok(new { lastCronUpdate = importHistory.Time.ToString() });
            }catch(Exception)
            {
                return BadRequest(new { message = "Erro ao consultar os detalhes da API" });
            }
        }


        [HttpGet]
        [Route("products/{code}")]
        public async Task<ActionResult<Product>> GetProduct(string code)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var prodcut = await _productService.GetProduct(code);

                if (prodcut != null)
                    return Ok(prodcut);
                else
                    return NotFound( new { message = "Produto não encontrado" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = $"Erro ao obter o produto: {code}" } );
            }

        }

        [HttpGet]
        [Route("products")]

        public async Task<ActionResult<List<Product>>> GetProducts([FromQuery(Name = "page")] int? page)
        {
            try
            {
                var products = await _productService.GetProducts(page);
                return Ok(products);

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Erro ao consultar os produtos" });
            }

        }


        [HttpPut]
        [Route("products/{code}")]
        public async Task<ActionResult<Product>> UpdateProduct(string code, [FromBody]Product product)
        {
            try
            {
                var result = await _productService.UpdateProduct(code, product);

                if (result != null)
                    return Ok(product);
                else
                    return BadRequest( new { message = "Erro ao atualizar o produto" });

            }catch (Exception)
            {
                return BadRequest(new { message = $"Erro ao atualizar o produto: {code}" });
            }

        }

        [HttpDelete]
        [Route("products/{code}")]
        public async Task<ActionResult> DeleteProduct(string code)
        {
            try
            {
                var product = await GetProduct(code);
                int result = 0;

                if(product != null)
                {
                    result = await _productService.DeleteProduct(code);

                    if (result > 0)
                        return Ok(new { message = "Produto excluído com sucesso" });
                    else
                        return BadRequest(new { message = $"Erro ao excluir o produto: {code}" });
                }

                return NotFound(new { message = "Produto não encontrado"});


            }catch(Exception)
            {
                return BadRequest(new { message = $"Erro ao excluir o produto: {code}" });
            }

        }


    }
}
