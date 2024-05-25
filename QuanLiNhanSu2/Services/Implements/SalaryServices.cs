using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Models.QuanLiNhanSuModels;
using QuanLiNhanSu2.Repositories;
using QuanLiNhanSu2.Repositories.Implements;

namespace QuanLiNhanSu2.Services.Implements
{
    public class SalaryServices : ISalaryServices
    {
        private readonly ISalaryRepository _salaryRepository;

        public SalaryServices(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }
        public Task<int> AddSalaryAsync(SalaryModel salarymodel)
        {
            return _salaryRepository.AddSalaryAsync(salarymodel);
        }

        public Task DeleteSalaryAsync(int id)
        {
            return _salaryRepository.DeleteSalaryAsync(id);
        }

        public Task<List<SalaryModel>> GetAllSalariesAsync()
        {
            return _salaryRepository.GetAllSalariesAsync();
        }

        public Task<SalaryModel> GetSalaryByIdAsync(int id)
        {
            return _salaryRepository.GetSalaryByIdAsync(id);
        }

        public Task<SalaryModel> GetSalaryByUserIdAsync(string userId)
        {
            return _salaryRepository.GetSalaryByUserIdAsync(userId);
        }

        public Task UpdateSalaryAsync(SalaryModel salarymodel, int id)
        {
            return _salaryRepository.UpdateSalaryAsync(salarymodel, id);
        }
    }
}
