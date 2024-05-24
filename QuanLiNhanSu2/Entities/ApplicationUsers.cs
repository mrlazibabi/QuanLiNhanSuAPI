using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace QuanLiNhanSu2.Entities
{
    public class ApplicationUsers : IdentityUser
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        //[Required]
        //public string PasswordHash { get; set; } = string.Empty;
        [Required]
        public string? RefreshToken { get; set; } = string.Empty;
        public DateTime? TokenCreated { get; set; }
        public DateTime? TokenExpires { get; set; }


    }
}
