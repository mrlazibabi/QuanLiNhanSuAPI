using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Models.QuanLiNhanSuModels;

namespace QuanLiNhanSu2.Services.Implements
{
    public class SalaryServices : ISalaryServices
    {
        private readonly QuanLiNhanSuContext _context;
        private readonly IMapper _mapper;

        public SalaryServices(QuanLiNhanSuContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddSalaryAsync(SalaryModel salarymodel)
        {
            //_context.Salaries.Add(salarymodel);
            //await _context.SaveChangesAsync();      
            var newSalary = _mapper.Map<Salary>(salarymodel);
            _context.Salaries!.Add(newSalary);
            await _context.SaveChangesAsync();

            return newSalary.SalaryId;
        }

        public async Task DeleteSalaryAsync(int id)
        {
            var salary = await _context.Salaries.FindAsync(id);
            if (salary != null)
            {
                _context.Salaries.Remove(salary);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<SalaryModel>> GetAllSalariesAsync()
        {
            //return await _context.Salaries.ToListAsync();
            var salaries = await _context.Salaries!.ToListAsync();
            return _mapper.Map<List<SalaryModel>>(salaries);
        }

        public async Task<SalaryModel> GetSalaryByIdAsync(int id)
        {
            //return await _context.Salaries.FirstOrDefaultAsync(s => s.SalaryId == id);
            var salary = await _context.Salaries.FindAsync(id);
            return _mapper.Map<SalaryModel>(salary);
        }

        public async Task<SalaryModel> GetSalaryByUserIdAsync(string userId)
        {
            //return await _context.Salaries.Where(s => s.UserId == userId).ToListAsync();
            //var userSalary = await _context.Salaries.FindAsync(userId);

            var userSalary = await _context.Salaries.Where(s => s.UserId == userId).FirstOrDefaultAsync();
            return _mapper.Map<SalaryModel>(userSalary);

        }

        public async Task UpdateSalaryAsync(SalaryModel salarymodel, int id)
        {
            //_context.Salaries.Update(salarymodel);
            //await _context.SaveChangesAsync();
            if(id == salarymodel.SalaryId)
            {
                var updateSalary = _mapper.Map<Salary>(salarymodel);
                _context.Salaries!.Update(updateSalary);
                await _context.SaveChangesAsync();
            }
        }
    }
}
