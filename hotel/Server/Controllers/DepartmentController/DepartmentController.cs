using Hotel.Server.Services.DepartmentService;
using Hotel.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Server.Controllers.DepartmentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _DepartmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _DepartmentService = departmentService;
        }

        [HttpGet]
        public async Task<List<Department>> GetDepartments()
        {
            return await _DepartmentService.GetDepartments();
        }

        [HttpGet("{id}")]
        public async Task<Department?> GetDepartmentById(int id)
        {
            return await _DepartmentService.GetDepartmentById(id);
        }

        [HttpGet("search/{searchText}")]
        public async Task<List<Department>> SearchDepartments(string searchText)
        {
            return await _DepartmentService.SearchDepartments(searchText);
        }

        [HttpPost]
        public async Task<Department?> CreateEmployee(Department Department)
        {
            return await _DepartmentService.CreateDepartment(Department);
        }

        [HttpPut("{id}")]
        public async Task<Department?> UpdateDepartment(int id, Department Department)
        {
            return await _DepartmentService.UpdateDepartment(id, Department);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteDepartment(int id)
        {
            return await _DepartmentService.DeleteDepartment(id);
        }
    }
}
