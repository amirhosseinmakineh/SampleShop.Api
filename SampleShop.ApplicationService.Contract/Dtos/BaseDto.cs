using SampleShop.ApplicationService.Contract.GlobalEnums;

namespace SampleShop.ApplicationService.Contract.Dtos
{
    public record BaseDto<Tkey> where Tkey : struct
    {
        public Tkey Id { get; set; }
        public bool IsDelete { get; set; }
        public string CreateObjectDate { get; set; } = string.Empty;
    }
}
