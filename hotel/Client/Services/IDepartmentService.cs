using Hotel.Shared.Models;

namespace Hotel.Client.Services
{
    public interface IDepartmentService
    {
        List<Department> Departments { get; set; }
        Task GetDepartments();
        Task<Department?> GetDepartmentById(int id);
        Task<List<Department?>> SearchDepartments(string searchText);
        Task CreateDepartment(Department Employee);
        Task UpdateDepartment(int id, Department Employee);
        Task DeleteDepartment(int id);
    }
}