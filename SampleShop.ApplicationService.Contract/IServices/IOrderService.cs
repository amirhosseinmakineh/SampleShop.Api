using SampleShop.ApplicationService.Contract.Dtos.OrderDto;

namespace SampleShop.ApplicationService.Contract.IServices
{
    public interface IOrderService
    {
        void AddOrder(AddOrderDto dto);
    }
}
