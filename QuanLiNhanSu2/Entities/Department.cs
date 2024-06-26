﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiNhanSu2.Entities
{
    [Table("Department")]
    public class Department
    {
        [Key]

        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User>? Users { get; set; }
    }
}
