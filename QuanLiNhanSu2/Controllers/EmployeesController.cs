﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Models.QuanLiNhanSuModels;
using QuanLiNhanSu2.Services;

namespace QuanLiNhanSu2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeServices _empService;
        public EmployeesController(IEmployeeServices empService)
        {
            _empService = empService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var emps = await _empService.GetAllEmployees();
                return Ok(emps);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetEmpById(string id)
        {
            var user = await _empService.GetEmpById(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddEmployee(EmployeeModel model)
        {
            try
            {
                // var newUserId = await _userRepo.AddUserAsync(model);
                var newEmp = await _empService.AddEmployee(model);
                return Ok(newEmp);
            }
            catch
            {
                return BadRequest("Adding Error");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateEmployee(string id, EmployeeModel model)
        {
            if (id == model.Id)
            {
                await _empService.UpdateEmployee(id, model);
                return Ok();
            }
            else
            {
                return BadRequest("Not Found");
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                await _empService.DeleteEmployee(id);
                return Ok();
            }
        }
    }
}
