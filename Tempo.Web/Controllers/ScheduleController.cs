using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tempo.Domain.Models.ViewModels;
using Tempo.Domain.Repositories.Interfaces;

namespace Tempo.Web.Controllers
{
    public class ScheduleController : ApiController
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<string> ReserveSchedule(ReserveScheduleModel model)
        {
            var response = _scheduleRepository.ReserveSchedule(model.ScheduleModel, model.UserId);

            if (response.IsError)
                return BadRequest(response.Message);

            return Ok();
        }
    }
}
