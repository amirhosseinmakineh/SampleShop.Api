using System.ComponentModel.DataAnnotations.Schema;

namespace SampleShop.Domain.Models
{
    public class Comment : BaseEntity<long>
    {
        public string CommentName { get; set; } = string.Empty;
        public long ProductId { get; set; }
        #region Relations
        public Product Product { get; set; }
        #endregion
    }
}
