using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace Hotel.Client.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;
        public DepartmentService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManger = navigationManger;
        }

        public List<Department> Departments { get; set; } = new List<Department>();

        public async Task CreateDepartment(Department Department)
        {
            await _http.PostAsJsonAsync("api/Department", Department);
            _navigationManger.NavigateTo("admin/Departments");
        }

        public async Task DeleteDepartment(int id)
        {
            var result = await _http.DeleteAsync($"api/Department/{id}");
            _navigationManger.NavigateTo("admin/Departments");
        }

        public async Task<Department?> GetDepartmentById(int id)
        {
            var result = await _http.GetAsync($"api/Department/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Department>();
            }
            return null;
        }

        public async Task GetDepartments()
        {
            var result = await _http.GetFromJsonAsync<List<Department>>("api/Department");
            if (result is not null)
            {
                Departments = result;
            }
        }

        public async Task<Department?> SearchDepartments(string searchText)
        {
            var result = await _http.GetAsync($"api/Department/search/{searchText}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Department>();
            }
            return null;
        }

        public async Task UpdateDepartment(int id, Department Employee)
        {
            await _http.PutAsJsonAsync($"api/Employee/{id}", Employee);
            _navigationManger.NavigateTo("admin/employees");
        }
    }
}