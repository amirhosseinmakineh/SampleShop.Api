using SampleShop.ApplicationService.Contract.Dtos.OrderDetailDto;

namespace SampleShop.ApplicationService.Contract.Dtos.OrderDto
{
    public record AddOrderDto:BaseDto<long>
    {
        public Guid UserId { get; set; }
        public long OrderId { get; set; }
        public string OrderName { get; set; } = string.Empty;
        public List<long> ProductIds { get; set; }
        public AddOrderDetailDto DetailDto { get; set; }
    }
}
