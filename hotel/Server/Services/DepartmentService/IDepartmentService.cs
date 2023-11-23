using Hotel.Shared.Models;

namespace Hotel.Server.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetDepartments();
        Task<Department?> GetDepartmentById(int DepartmentId);
        Task<List<Department>> SearchDepartments(string searchText);
        Task<Department> CreateDepartment(Department Department);
        Task<Department?> UpdateDepartment(int DepartmentId, Department Department);
        Task<bool> DeleteDepartment(int DepartmentId);
    }
}
 