using FakeItEasy;
using FitnessFoods.Application.Controllers;
using FitnessFoods.Domain.Entities;
using FitnessFoods.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessFoods.Tests.Controllers
{
    [TestClass]
    public class FitnessFoodsControllerTests
    {

        [TestMethod]
        public async Task GetApiDetails_Should_Return_Last_CRON_Update()
        {
            // Arrange
            var importHistory = A.Fake<ImportHistory>();
            var productService = A.Fake<IProductService>();
            var importHistoryService = A.Fake<IImportHistoryService>();
            A.CallTo(() => importHistoryService.GetHistory()).Returns(Task.FromResult(importHistory));
            var controller = new FitnessFoodsController(productService, importHistoryService);

            // Act 
            var actionResult = await controller.GetApiDetails();

            // Assert
            var result = actionResult as OkObjectResult;
            Assert.AreEqual(actionResult, result);
        }


        [TestMethod]
        public async Task GetProduct_Should_Return_A_Product_Of_A_Code()
        {
            // Arrange
            string code = "4000405001356";
            var fakeProduct = A.Fake<Product>();
            var productService = A.Fake<IProductService>();
            var importHistoryService = A.Fake<IImportHistoryService>();
            A.CallTo(() => productService.GetProduct(code)).Returns(Task.FromResult(fakeProduct));
            var controller = new FitnessFoodsController(productService, importHistoryService);

            // Act 
            var actionResult = await controller.GetProduct(code);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var returnProduct = result.Value as Product;

            Assert.AreEqual(fakeProduct, returnProduct);
        }



        [TestMethod]
        public async Task GetProducts_Should_Return_All_Products_Of_A_Page()
        {
            // Arrange 
            int page = 1;
            int count = 30;
            var fakeProducts = A.CollectionOfDummy<Product>(count).ToList();
            var producService = A.Fake<IProductService>();
            A.CallTo(() => producService.GetProducts(page)).Returns(Task.FromResult(fakeProducts));

            var importHistoryService = A.Fake<IImportHistoryService>();
            var controller = new FitnessFoodsController(producService, importHistoryService);

            // Act
            var actionResult = await controller.GetProducts(page);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var returnProducts = result.Value as List<Product>;

            Assert.AreEqual(count, returnProducts.Count);
        }



        [TestMethod]
        public async Task UpdateProduct_Should_Return_The_Updated_Product()
        {
            // Arrange
            string code = "4000405001356";
            var fakeProduct = A.Fake<Product>();
            var productService = A.Fake<IProductService>();
            A.CallTo(() => productService.UpdateProduct(code, fakeProduct)).Returns(Task.FromResult(fakeProduct));
            var importHistoryService = A.Fake<IImportHistoryService>();
            var controller = new FitnessFoodsController(productService, importHistoryService);

            // Act
            var actionResult = await controller.UpdateProduct(code, fakeProduct);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var returnProduct = result.Value as Product;

            Assert.AreEqual(fakeProduct, returnProduct);
        }

        [TestMethod]
        public async Task DeleteProduct_Should_Return_A_Success_Message()
        {
            // Arrange
            string code = "4000405001356";
            var fakeProduct = A.Fake<Product>();
            int deleteResult = 1;
            var productService = A.Fake<IProductService>();
            A.CallTo(() => productService.DeleteProduct(code)).Returns(Task.FromResult(deleteResult));
            var importHistoryService = A.Fake<IImportHistoryService>();
            var controller = new FitnessFoodsController(productService, importHistoryService);

            // Act
            var actionResult = await controller.DeleteProduct(code);

            // Assert
            var result = actionResult as OkObjectResult;
            Assert.AreEqual(actionResult, result);

        }

    }
}
