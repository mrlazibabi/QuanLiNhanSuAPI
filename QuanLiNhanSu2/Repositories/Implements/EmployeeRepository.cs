using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu2.Entities;


namespace QuanLiNhanSu2.Repositories.Implements
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly QuanLiNhanSuContext _context;

        public EmployeeRepository(QuanLiNhanSuContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddEmpEntityAsync(Employee employee)
        {
            var empReturn = _context.Employees!.Add(employee);
            await _context.SaveChangesAsync();
            return empReturn.Entity;
        }
    }
}
