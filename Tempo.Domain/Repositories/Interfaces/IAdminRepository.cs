using System.Collections.Generic;
using Tempo.Data.Entities.Models;
using Tempo.Domain.Abstractions;
using Tempo.Domain.Models.ViewModels;

namespace Tempo.Domain.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        ResponseResult AddEmployee(EmployeeModel employeeModel);
        Employee EditEmployee(int employeeId, EmployeeModel employeeModel);
        ResponseResult DeleteEmployee(int employeeId);
        ICollection<Employee> GetAllGymEmployees(int gymId);
        ICollection<RegularUser> GetAllGymUsers(int gymId);
        float GetTotalProfit(int gymId);
    }
}
