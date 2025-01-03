namespace SampleShop.ApplicationService.Contract.Dtos.Slider
{
    public record SliderDto:BaseDto<long>
    {
        public string ImageName { get; set; } = string.Empty;
    }
}
