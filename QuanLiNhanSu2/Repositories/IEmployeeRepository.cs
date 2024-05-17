using QuanLiNhanSu2.Entities;

namespace QuanLiNhanSu2.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<Employee> AddEmpEntityAsync(Employee employee);
    }
}
