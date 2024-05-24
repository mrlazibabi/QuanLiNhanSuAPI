using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu2.Entities;

namespace QuanLiNhanSu2.Services.Implements
{
    public class FormServices : IFormServices
    {
        private readonly QuanLiNhanSuContext _context;

        public FormServices(QuanLiNhanSuContext context)
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
