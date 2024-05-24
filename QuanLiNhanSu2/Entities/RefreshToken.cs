using System.ComponentModel.DataAnnotations;

namespace QuanLiNhanSu2.Entities
{
    public class RefreshToken
    {
        [Required]
        public string Token {  get; set; }
        public DateTime TokenCreated {  get; set; } = DateTime.Now;
        public DateTime TokenExpires { get; set; }
    }
}
