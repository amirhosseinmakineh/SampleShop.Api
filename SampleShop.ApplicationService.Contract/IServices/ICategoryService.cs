using SampleShop.ApplicationService.Contract.Dtos.Category;

namespace SampleShop.ApplicationService.Contract.IServices
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAllCategoryForMenu();
        void AddCategory(AddCategoryDto dto);
    }
}
