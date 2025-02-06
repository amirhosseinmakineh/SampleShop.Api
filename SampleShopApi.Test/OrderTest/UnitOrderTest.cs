using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleShop.ApplicationService.Contract.Dtos.OrderDto;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.Models;

namespace SampleShopApi.Test.OrderTest
{
    public class UnitOrderTest
    {

        [Fact]
        public void Order_Should_Create_In_Correct_State()
        {
            //Arrange
            var mockOrderService = new Mock<IOrderService>();
            var order = new AddOrderDto()
            {
                CreateObjectDate = DateTime.Now.ToString(),
                IsDelete = false,
                OrderName = "Test",
                ProductIds = new List<long> { 3 },
                DetailDto = new SampleShop.ApplicationService.Contract.Dtos.OrderDetailDto.AddOrderDetailDto()
                {
                    CreateObjectDate = DateTime.Now.ToString(),
                    IsDelete = false,
                    TotalOrderSum = 0
                },
                UserId = Guid.NewGuid(),


            };
            //Act
            mockOrderService.Setup(x => x.AddOrder(It.IsAny<AddOrderDto>()));
            //Assert 
            mockOrderService.Verify(x => x.AddOrder(order));
        }
    }
}
