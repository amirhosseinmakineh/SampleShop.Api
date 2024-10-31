namespace SampleShop.ApplicationService.Contract.Dtos
{
    public record BaseDto<Tkey> where Tkey : struct
    {
        public Tkey Id { get; set; }
        public bool IsDelete { get; set; }
    }
}
