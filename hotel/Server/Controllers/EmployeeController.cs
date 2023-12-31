﻿using Microsoft.AspNetCore.Mvc;
using Hotel.Shared.Models;
using Hotel.Server.Services.EmployeeService;

namespace Hotel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _EmployeeService;

        public EmployeeController(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }

        [HttpGet]
        public async Task<List<Employee>> GetEmployees()
        {
            return await _EmployeeService.GetEmployees();
        }

        [HttpGet("{id}")]
        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await _EmployeeService.GetEmployeeById(id);
        }

        [HttpGet("search/{searchText}")]
        public async Task<List<Employee>> SearchEmployees(string searchText)
        {
            return await _EmployeeService.SearchEmployees(searchText);
        }

        [HttpPost]
        public async Task<Employee?> CreateEmployee(Employee Employee)
        {
            return await _EmployeeService.CreateEmployee(Employee);
        }

        [HttpPut("{id}")]
        public async Task<Employee?> UpdateEmployee(int id, Employee Employee)
        {
            return await _EmployeeService.UpdateEmployee(id, Employee);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteEmployee(int id)
        {
            return await _EmployeeService.DeleteEmployee(id);
        }
    }
}
