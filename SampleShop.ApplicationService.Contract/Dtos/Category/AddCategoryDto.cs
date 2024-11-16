namespace SampleShop.ApplicationService.Contract.Dtos.Category
{
    public class AddCategoryDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ParentID { get; set; }
        public DateTime CreateObjectDat { get; set; } = DateTime.Now;
        public DateTime CreateObjectTime { get; set; } = DateTime.Now;
    }
}
