using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu2.Entities;

namespace QuanLiNhanSu2.Repositories.Implements
{
    public class FormRepository : IFormRepository
    {
        private readonly QuanLiNhanSuContext _context;

        public FormRepository(QuanLiNhanSuContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Form>> GetAllAsync()
        {
            return await _context.Forms.ToListAsync();
        }

        public async Task<Form> GetByIdAsync(int id)
        {
            return await _context.Forms.FindAsync(id);
        }
    }
}
