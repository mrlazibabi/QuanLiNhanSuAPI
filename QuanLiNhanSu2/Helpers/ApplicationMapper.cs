using AutoMapper;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Models.QuanLiNhanSuModels;

namespace QuanLiNhanSu2.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Role, RoleModel>().ReverseMap();
            CreateMap<Department, DepartmentModel>().ReverseMap();
            CreateMap<Salary, SalaryModel>().ReverseMap();
        }
    }
}
