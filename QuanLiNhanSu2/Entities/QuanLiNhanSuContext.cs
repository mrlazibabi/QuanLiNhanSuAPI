using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu2.Models;

namespace QuanLiNhanSu2.Entities
{
    public class QuanLiNhanSuContext : DbContext
    {
        public QuanLiNhanSuContext(DbContextOptions<QuanLiNhanSuContext> opt): base(opt)
        {

        }

        #region DbSet
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<QuanLiNhanSu2.Models.EmployeeModel>? EmployeeModel { get; set; }
        #endregion
    }
}
