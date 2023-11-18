﻿
using Hotel.Client;
using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;


namespace Hotel.Client.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;

        public EmployeeService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManger = navigationManger;
        }

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public async Task CreateEmployee(Employee Employee)
        {
            await _http.PostAsJsonAsync("api/Employee", Employee);
            _navigationManger.NavigateTo("Employees");
        }

        public async Task DeleteEmployee(int id)
        {
            var result = await _http.DeleteAsync($"api/Employee/{id}");
            _navigationManger.NavigateTo("Employees");
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            var result = await _http.GetAsync($"api/Employee/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Employee>();
            }
            return null;
        }

        public async Task GetEmployees()
        {
            var result = await _http.GetFromJsonAsync<List<Employee>>("api/Employee");
            if (result is not null)
                Employees = result;
        }

        public async Task UpdateEmployee(int id, Employee Employee)
        {
            await _http.PutAsJsonAsync($"api/Employee/{id}", Employee);
            _navigationManger.NavigateTo("Employees");
        }
    }
}