using SampleShop.ApplicationService.Contract.Dtos.ColorDtos;

namespace SampleShop.ApplicationService.Contract.IServices
{
    public interface IColorService
    {
        List<ColorDto> GetAll();
        void Add(ColorAddDto dto);
        void Update(ColorAddDto dto);
        void Delete(int id);
    }
}
