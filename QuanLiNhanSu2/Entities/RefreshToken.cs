using System.ComponentModel.DataAnnotations;

namespace QuanLiNhanSu2.Entities
{
    public class RefreshToken
    {
        [Required]
        public string Token {  get; set; }
        public DateTime Created {  get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}
