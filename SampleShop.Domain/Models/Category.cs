namespace SampleShop.Domain.Models
{
    public class Category:BaseEntity<long>
    {
        public Category()
        {
            Categories = new HashSet<Category>();
        }
        public string Title { get; set; } = string.Empty;
        public long? ParentId { get; set; }
        public string Description { get; set; } = string.Empty;
        #region Relations
        public Category? Parent { get; set; }
        public ICollection<Category> Categories { get; set; }
        #endregion
    }
}
