using SampleShop.ApplicationService.Contract.Dtos.Slider;

namespace SampleShop.ApplicationService.Contract.IServices
{
    public interface ISliderService
    {
        ICollection<SliderDto> GetSliders();
    }
}
