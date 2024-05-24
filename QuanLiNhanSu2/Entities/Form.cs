using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiNhanSu2.Entities
{
    [Table("Form")]
    public class Form
    {
        [Key]
        public int FormId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public virtual User? Users { get; set; }
        public string UserId { get; set; }
        public DateTime Created {  get; set; } = DateTime.Now;
        [Required]
        public string FormName { get; set; }
        public byte[] FormData { get; set; }
    }
}
