using System.Net;
using Hotel.Server.Data;

using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Server.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly MyDbContext _context;
        public DepartmentService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Department> CreateDepartment(Department Department)
        {
            _context.Add(Department);
            await _context.SaveChangesAsync();
            return Department;
        }

        public async Task<bool> DeleteDepartment(int DepartmentId)
        {
            var dbDepartment = await _context.Departments.FindAsync(DepartmentId);
            if (dbDepartment == null)
            {
                return false;
            }

            _context.Remove(dbDepartment);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Department>> SearchDepartments(string searchText)
        {
            var dbDepartments = await _context.Departments
                .Where(d =>
                    EF.Functions.Like(d.DeName, $"%{searchText}%") ||
                    EF.Functions.Like(d.DeDescription, $"%{searchText}%"))
                .ToListAsync();

            return dbDepartments;
        }


        public async Task<Department?> GetDepartmentById(int DepartmentId)
        {
            var dbEmployee = await _context.Departments.FindAsync(DepartmentId);
            return dbEmployee;
        }

        public async Task<List<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department?> UpdateDepartment(int departmentId, Department department)
        {
            var dbDepartment = await _context.Departments.FindAsync(departmentId);
            if (dbDepartment != null)
            {
                dbDepartment.DeId = department.DeId;
                dbDepartment.DeName = department.DeName;
                dbDepartment.DeDescription = department.DeDescription;
                dbDepartment.DeInitialSalary = department.DeInitialSalary;

                await _context.SaveChangesAsync();
            }

            return dbDepartment;
        }

    }
}