namespace SampleShop.ApplicationService.Contract.Dtos.OrderDetailDto
{
    public record AddOrderDetailDto:BaseDto<long>
    {
        public long OrderId { get; set; }
        public decimal TotalOrderSum { get; set; }
    }
}
