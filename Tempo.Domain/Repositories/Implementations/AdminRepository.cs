using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tempo.Data.Entities;
using Tempo.Data.Entities.Models;
using Tempo.Domain.Abstractions;
using Tempo.Domain.Models.ViewModels;
using Tempo.Domain.Repositories.Interfaces;

namespace Tempo.Domain.Repositories.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly TempoDbContext _dbContext;

        public AdminRepository(TempoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResponseResult AddEmployee(EmployeeModel employeeModel)
        {
            var employee = new Employee
            {
                Id = employeeModel.Id,
                Name = employeeModel.Name,
                Email = employeeModel.Email,
                HiredOn = employeeModel.HiredOn,
                PricePerHour = employeeModel.PricePerHour,
                EmployeeRole = employeeModel.EmployeeRole,
                GymId = employeeModel.Gym.Id,
            };

            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public Employee EditEmployee(EmployeeModel employeeModel)
        {
            var employee = _dbContext.Employees.Find(employeeModel.Id);
            employee.Id = employeeModel.Id;
            employee.Name = employeeModel.Name;
            employee.Email = employeeModel.Email;
            employee.HiredOn = employeeModel.HiredOn;
            employee.PricePerHour = employeeModel.PricePerHour;
            employee.EmployeeRole = employeeModel.EmployeeRole;
            employee.GymId = employeeModel.Gym.Id;

            _dbContext.SaveChanges();

            return employee;
        }

        public ResponseResult DeleteEmployee(int employeeId)
        {
            var employee = _dbContext.Employees.Find(employeeId);
            if (employee == null)
                return ResponseResult.Error("Employee not founf");

            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public ICollection<Employee> GetAllGymEmployees(int gymId)
        {
            var employees = _dbContext.Employees.Where(e => e.GymId == gymId).ToList();
            if (employees.Count() == 0)
                return new List<Employee>();

            return employees;
        }

        public ICollection<RegularUser> GetAllGymUsers(int gymId)
        {
            var gymMembers = _dbContext.RegularUsers
                .Include(gu => gu.GymUsers.Where(gu => gu.GymId == gymId))
                .ToList();

            if (gymMembers.Count() == 0)
                return new List<RegularUser>();

            return gymMembers;
        }
    }
}
