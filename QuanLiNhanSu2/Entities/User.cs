using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace QuanLiNhanSu2.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        [Required]
        public string Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [ForeignKey("DepartmentId")]
        public virtual Department? Departments { get; set; }
        public int DepartmentId { get; set; }
        [Required]
        [ForeignKey("RoleId")]
        public virtual Role? Roles { get; set; }
        public int RoleId { get; set; }
    }
}
