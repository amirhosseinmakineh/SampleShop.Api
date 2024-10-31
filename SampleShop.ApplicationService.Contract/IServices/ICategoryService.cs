using SampleShop.ApplicationService.Contract.Dtos.Category;

namespace SampleShop.ApplicationService.Contract.IServices
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAllCategory();
    }
}
