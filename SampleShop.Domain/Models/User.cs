namespace SampleShop.Domain.Models
{
    public class User : BaseEntity<Guid>
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int MobileNumber { get; set; }
        public bool IsLock { get; set; }
        public long RoleId { get; set; }
        #region Relations
        public Role Role { get; set; }
        public ICollection<Order> Orders { get; set; }
        #endregion
    }
}
