using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tempo.Data.Entities.Models;
using Tempo.Domain.Repositories.Interfaces;
using Tempo.Web.Infrastructure;

namespace Tempo.Web.Controllers
{
    [Authorize(Policy = Policies.Employee)]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet(nameof(MembershipPayedInCash))]
        public ActionResult<string> MembershipPayedInCash(int userId, int gymId)
        {
            var response = _employeeRepository.MembershipPayedInCash(userId, gymId);

            if (response.IsError)
                return response.Message;

            return Ok();
        }

        [HttpGet(nameof(CheckMemberships))]
        public ActionResult<ICollection<RegularUser>> CheckMemberships(int gymId)
        {
            var usersWithUnpayedMembership = _employeeRepository.CheckMemberships(gymId);
            return Ok(usersWithUnpayedMembership);
        }

        [HttpDelete(nameof(DeleteMember))]
        public ActionResult<string> DeleteMember(int userId)
        {
            var response = _employeeRepository.DeleteMember(userId);

            if (response.IsError)
                return BadRequest(response.Message);

            return Ok();
        }
    }
}
