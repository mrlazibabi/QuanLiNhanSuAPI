using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiNhanSu2.Entities
{
    [Table("Salary")]
    public class Salary
    {
        [Key]
        public int SalaryId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public virtual User? Users { get; set; }
        public string UserId { get; set; }
        public long BaseSalary { get; set; }
        public int AllowedOff { get; set; }
        public int ActualOff { get; set; }
        public long? Bonus { get; set; }
        public long? Deduction { get; set; }
        public long Final { get; set; }
    }
}
