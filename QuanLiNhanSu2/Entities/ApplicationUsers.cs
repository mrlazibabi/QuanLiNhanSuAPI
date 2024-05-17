using Microsoft.AspNetCore.Identity;

namespace QuanLiNhanSu2.Entities
{
    public class ApplicationUsers : IdentityUser
    {
        public string? FullName { get; set; }

    }
}
