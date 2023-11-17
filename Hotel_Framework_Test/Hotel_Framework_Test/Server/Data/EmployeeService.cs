using Hotel_Framework_Test.Server.Context;
using Hotel_Framework_Test.Server.Models;

//using Hotel_Framework_Test.Shared;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Framework_Test.Server.Data
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _applicationDbContext.Employees.ToListAsync();
        }

        //Add New Employee Record
        public async Task<bool> AddNewEmployee(Employee employee)
        {
            await _applicationDbContext.Employees.AddAsync(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        //Get Employee Record By Id
        public async Task<Employee> GetEmployeeByID(int id)
        {
            //Employee employee = await _applicationDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            Employee employee = await _applicationDbContext.Employees.FirstOrDefaultAsync(x => x.EId == id);
            return employee;

        }

        //Update EMployee Data
        public async Task<bool> UpdateEmployeeDetails(Employee employee)
        {
            _applicationDbContext.Employees.Update(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        //Delete EMployee Data
        public async Task<bool> DeleteEmployee(Employee employee)
        {
            _applicationDbContext.Employees.Remove(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}
