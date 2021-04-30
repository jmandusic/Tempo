using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tempo.Data.Entities.Models;
using Tempo.Domain.Models.ViewModels;
using Tempo.Domain.Repositories.Interfaces;
using Tempo.Web.Infrastructure;

namespace Tempo.Web.Controllers
{
    public class GymController : ApiController
    {
        private readonly IGymRepository _gymRepository;

        public GymController(IGymRepository gymRepository)
        {
            _gymRepository = gymRepository;
        }

        [Authorize(Policy = Policies.RegularUser)]
        [HttpGet(nameof(GetAllGyms))]
        public ActionResult<ICollection<Gym>> GetAllGyms()
        {
            var gyms = _gymRepository.GetAllGyms();
            return Ok(gyms);
        }

        [Authorize(Policy = Policies.Admin)]
        [HttpPost(nameof(AddGym))]
        public ActionResult<string> AddGym(GymModel model)
        {
            var response = _gymRepository.AddGym(model);
            return Ok();
        }

        [Authorize(Policy = Policies.Admin)]
        [HttpPut(nameof(EditGym))]
        public ActionResult<GymModel> EditGym(GymModel model)
        {
            var gym = _gymRepository.EditGym(model);
            return Ok(gym);
        }

        [Authorize(Policy = Policies.Admin)]
        [HttpDelete(nameof(DeleteGym))]
        public ActionResult<string> DeleteGym(int id)
        {
            var deleteGymResponse = _gymRepository.DeleteGym(id);

            if (deleteGymResponse.IsError)
                return BadRequest(deleteGymResponse.Message);

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(nameof(CheckGymCapacity))]
        public ActionResult<int?> CheckGymCapacity(int gymId, DateTime date)
        {
            var capacity = _gymRepository.CheckGymCapacity(gymId, date);

            if (capacity == null)
                return BadRequest();

            return Ok(capacity);
        }


        [Authorize(Policy = Policies.RegularUser)]
        [HttpGet(nameof(SeeFriendsInGym))]
        public ActionResult<ICollection<RegularUser>> SeeFriendsInGym(int userId, int gymId)
        {
            return Ok(_gymRepository.SeeFriendsInGym(userId, gymId));
        }
    }
}
