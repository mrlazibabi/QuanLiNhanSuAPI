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
        [ForeignKey("Id")]
        public virtual ApplicationUsers? ApplicationUsers { get; set; }
        public string Id { get; set; }
        public DateTime Created {  get; set; } = DateTime.Now;
        [Required]
        public string FormName { get; set; }
        public byte[] FormData { get; set; }
    }
}
