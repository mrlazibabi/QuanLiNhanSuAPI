using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiNhanSu2.Entities
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User>? Users { get; set; }
    }
}
