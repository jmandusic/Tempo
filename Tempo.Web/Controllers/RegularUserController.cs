using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tempo.Domain.Repositories.Interfaces;
using Tempo.Web.Infrastructure;

namespace Tempo.Web.Controllers
{
    [Authorize(Policy = Policies.RegularUser)]
    public class RegularUserController : ApiController
    {
        private readonly IRegularUserRepository _regularUserRepository;

        public RegularUserController(IRegularUserRepository regularUserRepository)
        {
            _regularUserRepository = regularUserRepository;
        }

        [HttpPost]
        public IActionResult JoinGym(int userId, int gymId)
        {
            return Ok(_regularUserRepository.JoinGym(userId, gymId));
        }

        [HttpPost]
        public IActionResult PayMembership(int userId, int gymId)
        {
            return Ok(_regularUserRepository.PayMembership(userId, gymId));
        }
    }
}
