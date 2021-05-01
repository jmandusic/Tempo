using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tempo.Domain.Models.ViewModels;
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

        [HttpPost(nameof(JoinGym))]
        public IActionResult JoinGym(JoinGymModel model)
        {
            return Ok(_regularUserRepository.JoinGym(model.UserId, model.GymId));
        }

        [HttpPost(nameof(PayMembership))]
        public IActionResult PayMembership(PayMembershipModel model)
        {
            return Ok(_regularUserRepository.PayMembership(model.UserId, model.GymId));
        }
    }
}
