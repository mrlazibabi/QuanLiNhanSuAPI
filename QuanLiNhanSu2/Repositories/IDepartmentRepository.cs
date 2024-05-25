using QuanLiNhanSu2.Models.QuanLiNhanSuModels;

namespace QuanLiNhanSu2.Repositories
{
    public interface IDepartmentRepository
    {
        public Task<int> AddDepartment(DepartmentModel model);
        public Task<List<DepartmentModel>> GetAllDepartments();
        public Task<DepartmentModel> GetDepById(int id);
        public Task UpdateDepartment(int id, DepartmentModel model);
        public Task DeleteDepartment(int id);
    }
}
