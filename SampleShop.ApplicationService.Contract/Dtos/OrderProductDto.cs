namespace SampleShop.ApplicationService.Contract.Dtos
{
    public record OrderProductDto:BaseDto<long>
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
