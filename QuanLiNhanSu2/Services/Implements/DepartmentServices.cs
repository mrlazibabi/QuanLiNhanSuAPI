using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Models;

namespace QuanLiNhanSu2.Services.Implements
{
    public class DepartmentServices : IDepartmentServices
    {
        private QuanLiNhanSuContext _context;
        private IMapper _mapper;

        public DepartmentServices(QuanLiNhanSuContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<string> AddDepartment(DepartmentModel model)
        {
            var newDep = _mapper.Map<Department>(model);
            _context.Departments!.Add(newDep);
            await _context.SaveChangesAsync();

            return newDep.Id;
        }

        public async Task DeleteDepartment(string id)
        {
            var deleteDep = _context.Departments!.SingleOrDefault(x => x.Id == id);
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

        public async Task<DepartmentModel> GetDepById(string id)
        {
            var emp = await _context.Departments!.FindAsync(id);
            return _mapper.Map<DepartmentModel>(emp);
        }

        public async Task UpdateDepartment(string id, DepartmentModel model)
        {
            if (id == model.Id)
            {
                var updateDep = _mapper.Map<Department>(model);
                _context.Departments!.Update(updateDep);
                await _context.SaveChangesAsync();
            }

        }
    }
}
