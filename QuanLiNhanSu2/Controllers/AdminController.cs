using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Models.QuanLiNhanSuModels;
using QuanLiNhanSu2.Services;
using QuanLiNhanSu2.Services.Implements;

namespace QuanLiNhanSu2.Controllers
{
    [Route("api/SuperAdmin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IDepartmentServices _depService;
        private readonly IUserServices _userServices;
        private readonly IFormServices _formServices;
        private readonly ISalaryServices _salaryServices;

        public AdminController(IDepartmentServices depService, IUserServices userServices, IFormServices formServices, ISalaryServices salaryServices)
        {
            _depService = depService;
            _userServices = userServices;
            _formServices = formServices;
            _salaryServices = salaryServices;
        }

        [HttpGet("/All-Departments")]
        [Authorize(Roles = "Admin")]
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

        [HttpGet("/Get-Department/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetDepById(int id)
        {
            var dep = await _depService.GetDepById(id);
            return dep == null ? NotFound() : Ok(dep);
        }

        [HttpPost("/Add-Department")]
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

        [HttpPut("/Update-Department/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDepartment(int id, DepartmentModel model)
        {
            if (id == model.DepartmentId)
            {
                await _depService.UpdateDepartment(id, model);
                return Ok();
            }
            else
            {
                return BadRequest("Not Found");
            }
        }

        [HttpDelete("/Remove-Department/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDepartment(int id)
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

        [HttpGet("/All-Employees")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userServices.GetAllUserAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/Get-Employee/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userServices.GetUserByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPut("/Update-Employee/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(string id, UserModel model)
        {
            if (id == model.UserId)
            {
                await _userServices.UpdateUserAsync(id, model);
                return Ok();
            }
            else
            {
                return BadRequest($"{id} not found");
            }
        }

        [HttpDelete("/Remove-Employee/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveUser(string id)
        {
            if (id == null)
            {
                return BadRequest($"{id} not found");
            }
            else
            {
                await _userServices.DeleteUserAsync(id);
                return Ok();
            }
        }

        [HttpGet("/AllForms")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Form>>> GetAllForms()
        {
            var forms = await _formServices.GetAllAsync();
            return Ok(forms);
        }

        [HttpGet("/Form/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Form>> GetForm(int id)
        {
            var form = await _formServices.GetByIdAsync(id);
            if (form == null)
            {
                return NotFound();
            }

            return Ok(form);
        }

        [HttpGet("/AllSalaries")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Salary>>> GetAllSalaries()
        {
            var salaries = await _salaryServices.GetAllSalariesAsync();
            return Ok(salaries);
        }

        [HttpGet("/Salary/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Salary>> GetSalary(int id)
        {
            var salary = await _salaryServices.GetSalaryByIdAsync(id);
            if (salary == null)
            {
                return NotFound();
            }

            return Ok(salary);
        }

        [HttpPost("/Add-Salary")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddSalary(SalaryModel salarymodel)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //await _salaryServices.AddSalaryAsync(salarymodel);

            //return Ok(salarymodel);

            try
            {
                var newSalary = await _salaryServices.AddSalaryAsync(salarymodel);
                return Ok(newSalary);
            }catch (Exception ex)
            {
                return BadRequest("Adding Error");
            }
        }
    }
}
