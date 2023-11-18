
using Hotel.Shared.Models;
namespace Hotel.Server.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee?> GetEmployeeById(int EmployeeId);
        Task<Employee> CreateEmployee(Employee Employee);
        Task<Employee?> UpdateEmployee(int EmployeeId, Employee Employee);
        Task<bool> DeleteEmployee(int EmployeeId);
    }
}
