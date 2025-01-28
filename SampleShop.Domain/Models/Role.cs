namespace SampleShop.Domain.Models
{
    public class Role : BaseEntity<long>
    {
        public string RoleName { get; set; } = string.Empty;
        public int UserId { get; set; }
        #region Relations
        public ICollection<User>  Users { get; set; }
        #endregion
    }
}
