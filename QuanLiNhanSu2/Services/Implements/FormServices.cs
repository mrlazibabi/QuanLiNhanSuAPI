using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Repositories;
using QuanLiNhanSu2.Repositories.Implements;

namespace QuanLiNhanSu2.Services.Implements
{
    public class FormServices : IFormServices
    {
        private readonly IFormRepository _formRepository;

        public FormServices(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }
        public async Task<IEnumerable<Form>> GetAllAsync()
        {
            return await _formRepository.GetAllAsync();
        }

        public async Task<Form> GetByIdAsync(int id)
        {
            return await _formRepository.GetByIdAsync(id);
        }
    }
}
