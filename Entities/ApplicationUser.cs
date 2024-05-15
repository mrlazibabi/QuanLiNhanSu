using Microsoft.AspNetCore.Identity;

namespace QuanLiNhanSu.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = null;
    }
}
