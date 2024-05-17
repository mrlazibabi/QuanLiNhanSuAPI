﻿using QuanLiNhanSu2.Entities;

namespace QuanLiNhanSu2.Models.QuanLiNhanSuModels
{
    public class EmployeeModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? DepartmentId { get; set; }
        public string? DepartmentName { get; set;}
        //public Department Department { get; set; }
    }
}
