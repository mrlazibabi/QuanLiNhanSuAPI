using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Models.QuanLiNhanSuModels;
using QuanLiNhanSu2.Repositories;

namespace QuanLiNhanSu2.Services.Implements
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentServices(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<int> AddDepartment(DepartmentModel model)
        {
            return await _departmentRepository.AddDepartment(model);
        }

        public Task DeleteDepartment(int id)
        {
            return _departmentRepository.DeleteDepartment(id);
        }

        public Task<List<DepartmentModel>> GetAllDepartments()
        {
            return _departmentRepository.GetAllDepartments();
        }

        public Task<DepartmentModel> GetDepById(int id)
        {
            return _departmentRepository.GetDepById(id);
        }

        public Task UpdateDepartment(int id, DepartmentModel model)
        {
            return _departmentRepository.UpdateDepartment(id, model);

        }
    }
}
