using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiNhanSu2.Models.QuanLiNhanSuModels;
using QuanLiNhanSu2.Services;

namespace QuanLiNhanSu2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentServices _depService;
        public DepartmentsController(IDepartmentServices depService)
        {
            _depService = depService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {
                var deps = await _depService.GetAllDepartments();
                return Ok(deps);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepById(string id)
        {
            var dep = await _depService.GetDepById(id);
            return dep == null ? NotFound() : Ok(dep);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddDepartment(DepartmentModel model)
        {
            try
            {
                var newDep = await _depService.AddDepartment(model);
                return Ok(newDep);
            }
            catch
            {
                return BadRequest("Adding Error");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDepartment(string id, DepartmentModel model)
        {
            if (id == model.Id)
            {
                await _depService.UpdateDepartment(id, model);
                return Ok();
            }
            else
            {
                return BadRequest("Not Found");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDepartment(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                await _depService.DeleteDepartment(id);
                return Ok();
            }
        }
    }
}

