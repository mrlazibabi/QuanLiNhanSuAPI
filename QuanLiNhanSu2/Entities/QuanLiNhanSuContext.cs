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
        public DbSet<User>? Users { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Role>? Roles { get; set; }

        #endregion
    }
}
