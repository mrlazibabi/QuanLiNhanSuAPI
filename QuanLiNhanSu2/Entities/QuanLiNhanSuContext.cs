using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu2.Models;

namespace QuanLiNhanSu2.Entities
{
    public class QuanLiNhanSuContext : IdentityDbContext<ApplicationUsers>
    {
        public QuanLiNhanSuContext(DbContextOptions<QuanLiNhanSuContext> opt): base(opt)
        {

        }

        #region DbSet
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<QuanLiNhanSu2.Models.EmployeeModel>? EmployeeModel { get; set; }
        public DbSet<QuanLiNhanSu2.Models.DepartmentModel>? DepartmentModel { get; set; }
        #endregion
    }
}
