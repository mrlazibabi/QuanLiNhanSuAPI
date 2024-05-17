using AutoMapper;
using QuanLiNhanSu2.Entities;


namespace QuanLiNhanSu2.Repositories.Implements
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly QuanLiNhanSuContext _context;

        public DepartmentRepository(QuanLiNhanSuContext context)
        {
            _context = context;
        }
        public async Task<Department> GetById(string id)
        {
            var dep = await _context.Departments!.FindAsync(id);
            return dep;
        }
    }
}
