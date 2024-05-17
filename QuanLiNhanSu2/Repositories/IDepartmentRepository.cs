using QuanLiNhanSu2.Entities;

namespace QuanLiNhanSu2.Repositories
{
    public interface IDepartmentRepository
    {
        public Task<Department> GetById(string id);
    }
}
