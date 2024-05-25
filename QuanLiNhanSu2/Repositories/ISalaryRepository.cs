using QuanLiNhanSu2.Models.QuanLiNhanSuModels;

namespace QuanLiNhanSu2.Repositories
{
    public interface ISalaryRepository
    {
        public Task<List<SalaryModel>> GetAllSalariesAsync();
        Task<SalaryModel> GetSalaryByIdAsync(int id);
        Task<SalaryModel> GetSalaryByUserIdAsync(string userId);
        Task<int> AddSalaryAsync(SalaryModel salarymodel);
        Task UpdateSalaryAsync(SalaryModel salarymodel, int id);
        Task DeleteSalaryAsync(int id);
    }
}
