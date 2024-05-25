using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Models.QuanLiNhanSuModels;

namespace QuanLiNhanSu2.Repositories.Implements
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly QuanLiNhanSuContext _context;
        private readonly IMapper _mapper;

        public DepartmentRepository(QuanLiNhanSuContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddDepartment(DepartmentModel model)
        {
            var newDep = _mapper.Map<Department>(model);
            _context.Departments!.Add(newDep);
            await _context.SaveChangesAsync();

            return newDep.DepartmentId;
        }

        public async Task DeleteDepartment(int id)
        {
            var deleteDep = _context.Departments!.SingleOrDefault(x => x.DepartmentId == id);
            if (deleteDep != null)
            {
                _context.Departments!.Remove(deleteDep);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DepartmentModel>> GetAllDepartments()
        {
            var deps = await _context.Departments!.ToListAsync();
            return _mapper.Map<List<DepartmentModel>>(deps);
        }

        public async Task<DepartmentModel> GetDepById(int id)
        {
            var emp = await _context.Departments!.FindAsync(id);
            return _mapper.Map<DepartmentModel>(emp);
        }

        public async Task UpdateDepartment(int id, DepartmentModel model)
        {
            if (id == model.DepartmentId)
            {
                var updateDep = _mapper.Map<Department>(model);
                _context.Departments!.Update(updateDep);
                await _context.SaveChangesAsync();
            }
        }
    }
}
