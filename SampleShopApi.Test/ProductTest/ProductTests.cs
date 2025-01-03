//using Microsoft.Extensions.DependencyInjection;
//using Moq;
//using SampleShop.ApplicationService.Contract.Dtos;
//using SampleShop.ApplicationService.Contract.IServices;
//using SampleShop.ApplicationService.Services;
//using SampleShop.Domain.IRepositories;
//using SampleShop.Domain.Models;
//using SampleShop.InfraStracture.Context;
//using SampleShop.InfraStracture.Repositories;
//using NSubstitute;
//namespace SampleShopApi.Test.ProductTest
//{
//    public class ProductTests
//    {
//        private readonly Mock<IProductRepository> mockProductRepository;
//        private readonly Mock<ICategoryRepository> mockCategoryRepository;
//        private readonly IProductService productService;
//        public ProductTests()
//        {
//            mockProductRepository = new Mock<IProductRepository>();
//            mockCategoryRepository = new Mock<ICategoryRepository>();
//            productService = new ProductService(mockProductRepository.Object,mockCategoryRepository.Object);
//        }

//        [Fact]
//        public void CreateValidProduct_ReturnCreatedProduct()
//        {
//            //Arenge
//            var product = new ProductAddDto()
//            {
//                CategoryId = 3,
//                CategoryTitle = "dewkwe",
//                CreateObjectDate = DateTime.Now.ToString(),
//                ImageName = "wfww",
//                IsDelete = false,
//                Price = 15000,
//                Title = "wfewkfewfew"
//            };
//            mockProductRepository.Setup(r => r.Add(It.IsAny<Product>()));
//            //Act
//             //var x = productService.Add(product);
//            //Assert
//            //Assert.NotNull(x);
//            //Assert.Equal(3,x.CategoryId);
//            //Assert.Equal("wfewkfewfew",x.Title);
//            //mockProductRepository.Verify(r=> r.Add(It.IsAny<Product>()),Times.Once);
//        }

//        [Fact]
//        public void Product_Should_Create_New_Correct()
//        {

//            var product = new ProductAddDto()
//            {
//                CategoryId = 3,
//                CategoryTitle = "dewkwe",
//                CreateObjectDate = DateTime.Now.ToString(),
//                ImageName = "wfww",
//                IsDelete = false,
//                Price = 15000,
//                Title = "wfewkfewfew"
//            };
//            //Act
//            productService.Add(product);
//            //Assert

//        }
//    }
//}
