using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiNhanSu2.Entities
{
    [Table ("Employee")]
    public class Employee
    {
        [Key]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? DepId { get; set; }

        public Department Department { get; set; }
    }
}
