using Hotel_Framework_Test.Client;
using Hotel_Framework_Test.Server.Models;
using System.Net.Http.Json;


namespace Hotel_Framework_Test.Client.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _http;

        public EmployeeService(HttpClient http)
        {
            _http = http;
        }
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public Task CreateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetEmployees()
        {
            var result = await _http.GetFromJsonAsync<List<Employee>>("api/Employees");
            if(result is not null)
            {
                Employees = result;
            }
        }

        public Task UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
