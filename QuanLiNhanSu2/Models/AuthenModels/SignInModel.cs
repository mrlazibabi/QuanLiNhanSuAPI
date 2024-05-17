using System.ComponentModel.DataAnnotations;

namespace QuanLiNhanSu2.Models.AuthenModels
{
    public class SignInModel
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
