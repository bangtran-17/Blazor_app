
using System.Net;
using Hotel.Server.Data;

using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Server.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly MyDbContext _context;

        public EmployeeService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployee(Employee Employee)
        {
            _context.Add(Employee);
            await _context.SaveChangesAsync();
            return Employee;
        }

        public async Task<bool> DeleteEmployee(int EmployeeId)
        {
            var dbEmployee = await _context.Employees.FindAsync(EmployeeId);
            if (dbEmployee == null)
            {
                return false;
            }

            _context.Remove(dbEmployee);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<Employee?> GetEmployeeById(int EmployeeId)
        {
            var dbEmployee = await _context.Employees.FindAsync(EmployeeId);
            return dbEmployee;
        }
        public async Task<List<Employee>> GetEmployeeByFName(string fname)
        {
            //var dbEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.EFirstName == fname);
            var dbEmployee = await _context.Employees
                    .Where(e =>
                        EF.Functions.Like(e.EFirstName, $"%{fname}%") ||
                        EF.Functions.Like(e.ELastName, $"%{fname}%") ||
                        EF.Functions.Like(e.EDesignation, $"%{fname}%") ||
                        EF.Functions.Like(e.EContactNumber, $"%{fname}%") ||
                        EF.Functions.Like(e.EEmail, $"%{fname}%") ||
                        EF.Functions.Like(e.EAddress, $"%{fname}%"))
                    .ToListAsync();
            return dbEmployee;
        }
        //public async Task<List<Employee>> SearchEmployees(string searchText)
        //{
        //    var result = await _context.Employees
        //        .Where(e =>
        //            EF.Functions.Like(e.EFirstName, $"%{searchText}%") ||
        //            EF.Functions.Like(e.ELastName, $"%{searchText}%") ||
        //            EF.Functions.Like(e.EDesignation, $"%{searchText}%") ||
        //            EF.Functions.Like(e.EContactNumber, $"%{searchText}%") ||
        //            EF.Functions.Like(e.EEmail, $"%{searchText}%") ||
        //            EF.Functions.Like(e.EAddress, $"%{searchText}%"))
        //        .ToListAsync();

        //    return result;
        //}


        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> UpdateEmployee(int EmployeeId, Employee Employee)
        {
            var dbEmployee = await _context.Employees.FindAsync(EmployeeId);
            if (dbEmployee != null)
            {
                dbEmployee.EId = Employee.EId;
                dbEmployee.EFirstName = Employee.EFirstName;
                dbEmployee.ELastName = Employee.ELastName;
                dbEmployee.EContactNumber = Employee.EContactNumber;
                dbEmployee.EEmail = Employee.EEmail;
                dbEmployee.EAddress = Employee.EAddress;

                await _context.SaveChangesAsync();
            }

            return dbEmployee;
        }
    }
}
