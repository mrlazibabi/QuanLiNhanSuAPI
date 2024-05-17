using QuanLiNhanSu2.Models.QuanLiNhanSuModels;

namespace QuanLiNhanSu2.Services
{
    public interface IDepartmentServices
    {
        public Task<string> AddDepartment(DepartmentModel model);
        public Task<List<DepartmentModel>> GetAllDepartments();
        public Task<DepartmentModel> GetDepById(string id);
        public Task UpdateDepartment(string id, DepartmentModel model);
        public Task DeleteDepartment(string id);
    }
}
