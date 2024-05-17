﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Models;
using QuanLiNhanSu2.Repositories;

namespace QuanLiNhanSu2.Services.Implements
{
    public class EmployeeServices : IEmployeeServices
    {
        private QuanLiNhanSuContext _context;
        private IMapper _mapper;
        private readonly IDepartmentRepository _depRepo;
        private readonly IEmployeeRepository _empRepo;

        public EmployeeServices(QuanLiNhanSuContext context, IMapper mapper, IDepartmentRepository depRepo, IEmployeeRepository empRepo)
        {
            _context = context;
            _mapper = mapper;
            _depRepo = depRepo;
            _empRepo = empRepo;
            
        }

        //public async Task<string> AddEmployee(EmployeeModel model)
        //{

        //    try
        //    {
        //        var newEmp = _mapper.Map<Employee>(model);
        //        _context.Employees!.Add(newEmp);
        //        await _context.SaveChangesAsync();

        //        return newEmp.Id;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.InnerException.Message;
        //    }
        //}

        public async Task<EmployeeModel> AddEmployee(EmployeeModel model)
        {
            try
            {
                var newEmp = _mapper.Map<Employee>(model);
                newEmp.Department = _depRepo!.GetById(model.DepartmentId).Result;
                await _empRepo.AddEmpEntityAsync(newEmp);

                return _mapper!.Map<EmployeeModel>(model);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public  async Task DeleteEmployee(string id)
        {
            var deleteEmp = _context.Employees!.SingleOrDefault(x => x.Id == id);
            if (deleteEmp != null)
            {
                _context.Employees!.Remove(deleteEmp);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var emps = await _context.Employees!.ToListAsync();
            return _mapper.Map<List<EmployeeModel>>(emps);
        }

        public async Task<EmployeeModel> GetEmpById(string id)
        {
            var emp = await _context.Employees!.FindAsync(id);
            return _mapper.Map<EmployeeModel>(emp);
        }

        public async Task UpdateEmployee(string id, EmployeeModel model)
        {
            if (id == model.Id)
            {
                var updateEmp = _mapper.Map<Employee>(model);
                _context.Employees!.Update(updateEmp);
                await _context.SaveChangesAsync();
            }

        }
    }
}
