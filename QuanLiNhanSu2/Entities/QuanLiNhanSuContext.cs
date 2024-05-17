using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu2.Models.QuanLiNhanSuModels;

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
        public DbSet<EmployeeModel>? EmployeeModel { get; set; }
        public DbSet<DepartmentModel>? DepartmentModel { get; set; }
        #endregion
    }
}
