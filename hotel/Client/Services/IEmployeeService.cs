
using Hotel.Shared.Models;

namespace Hotel.Client.Services
{
    public interface IEmployeeService
    {
        List<Employee> Employees { get; set; }
        Task GetEmployees();
        Task<Employee?> GetEmployeeById(int id);
        Task<List<Employee?>> SearchEmployees(string searchText);
        Task CreateEmployee(Employee Employee);
        Task UpdateEmployee(int id, Employee Employee);
        Task DeleteEmployee(int id);
    }
}