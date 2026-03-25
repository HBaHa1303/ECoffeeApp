namespace ECoffee.Application.Models
{
    public class User : BaseDomain
    {
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string FullName { get; set; } = null!;

        //public ICollection<UserRoleEntity> UserRoles { get; set; } = new List<UserRole>();
        //public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
