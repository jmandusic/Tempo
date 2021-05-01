using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tempo.Data.Entities.Models;
using Tempo.Domain.Models.ViewModels;
using Tempo.Domain.Repositories.Interfaces;
using Tempo.Web.Infrastructure;

namespace Tempo.Web.Controllers
{
    public class NotificationController : ApiController
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        [AllowAnonymous]
        [HttpGet(nameof(GetUnOpenedNotificationsForUser))]
        public ActionResult<ICollection<Notification>> GetUnOpenedNotificationsForUser([FromQuery] int userId)
        {
            return Ok(_notificationRepository
                .GetUnOpenedNotificationsForUser(userId));
        }

        [Authorize(Policy = Policies.Admin)]
        [HttpPost(nameof(PostNotification))]
        public IActionResult PostNotification(NotificationModel model)
        {
            return Ok(_notificationRepository.PostNotification(model));
        }

        [AllowAnonymous]
        [HttpPut(nameof(OpenNotification))]
        public ActionResult<string> OpenNotification(OpenNotificationModel model)
        {
            var response = _notificationRepository.OpenNotification(model.UserId, model.NotificationId);

            if (response.IsError)
                return BadRequest(response.Message);

            return Ok();
        }

    }
}
