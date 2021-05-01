using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tempo.Domain.Models.ViewModels;
using Tempo.Domain.Repositories.Interfaces;
using Tempo.Web.Infrastructure;

namespace Tempo.Web.Controllers
{
    [Authorize(Policy = Policies.Admin)]
    public class AdminController : ApiController
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }


        [HttpGet(nameof(GetAllGymUsers))]
        public ActionResult<RegularUserModel> GetAllGymUsers([FromQuery] int gymId)
        {
            return Ok(_adminRepository.GetAllGymUsers(gymId));
        }


        [HttpGet(nameof(GetAllGymEmployees))]
        public ActionResult<ICollection<GymModel>> GetAllGymEmployees([FromQuery] int gymId)
        {
            return Ok(_adminRepository.GetAllGymEmployees(gymId));
        }


        [HttpPost(nameof(AddEmployee))]
        public ActionResult<string> AddEmployee(EmployeeModel model)
        {
            var addEmployeeResponse = _adminRepository.AddEmployee(model);

            if (addEmployeeResponse.IsError)
                return BadRequest(addEmployeeResponse.Message);

            return Ok();
        }

        [HttpPut(nameof(EditEmployee))]
        public ActionResult<EmployeeModel> EditEmployee(EmployeeModel model)
        {
            var employee = _adminRepository.EditEmployee(model);
            return Ok(employee);
        }

        [HttpDelete(nameof(DeleteEmployee))]
        public ActionResult<string> DeleteEmployee(int id)
        {
            var deleteEmployeeResponse = _adminRepository.DeleteEmployee(id);

            if (deleteEmployeeResponse.IsError)
                return BadRequest(deleteEmployeeResponse.Message);

            return Ok();
        }
    }
}
