using QuanLiNhanSu.Entities;

namespace QuanLiNhanSu.Models
{
    public class UserModel
    {
        public string Id { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string DepId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int RoleId { get; set; }

        //public virtual Department? Dep { get; set; }
        //public virtual Role Role { get; set; } = null!;
    }
}
