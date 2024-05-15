using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Models;

namespace QuanLiNhanSu2.Services.Implements
{
    public class EmployeeServices : IEmployeeServices
    {
        private QuanLiNhanSuContext _context;
        private IMapper _mapper;

        public EmployeeServices(QuanLiNhanSuContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        public async Task<string> AddEmployee(EmployeeModel model)
        {
            var newEmp = _mapper.Map<Employee>(model);
            _context.Employees!.Add(newEmp);
            await _context.SaveChangesAsync();

            return newEmp.Id;
        }

        public  async Task DeleteEmployee(string id)
        {
            var deleteEmp = _context.Employees!.SingleOrDefault(x => x.Id == id);
            if (deleteEmp != null)
            {
                _context.Employees!.Remove(deleteEmp);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var emps = await _context.Employees!.ToListAsync();
            return _mapper.Map<List<EmployeeModel>>(emps);
        }

        public async Task<EmployeeModel> GetEmpById(string id)
        {
            var emp = await _context.Employees!.FindAsync(id);
            return _mapper.Map<EmployeeModel>(emp);
        }

        public async Task UpdateEmployee(string id, EmployeeModel model)
        {
            if (id == model.Id)
            {
                var updateEmp = _mapper.Map<Employee>(model);
                _context.Employees!.Update(updateEmp);
                await _context.SaveChangesAsync();
            }

        }
    }
}
