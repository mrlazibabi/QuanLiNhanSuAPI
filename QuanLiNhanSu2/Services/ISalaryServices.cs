using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Models.QuanLiNhanSuModels;

namespace QuanLiNhanSu2.Services
{
    public interface ISalaryServices
    {
        //Task<IEnumerable<SalaryModel>> GetAllSalariesAsync();
        public Task<List<SalaryModel>> GetAllSalariesAsync();
        Task<SalaryModel> GetSalaryByIdAsync(int id);
        Task<SalaryModel> GetSalaryByUserIdAsync(string userId);
        //Task AddSalaryAsync(SalaryModel salarymodel);
        Task<int> AddSalaryAsync(SalaryModel salarymodel);
        Task UpdateSalaryAsync(SalaryModel salarymodel, int id);
        Task DeleteSalaryAsync(int id);
    }
}
