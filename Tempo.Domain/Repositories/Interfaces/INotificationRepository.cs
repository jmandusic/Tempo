using System.Collections.Generic;
using Tempo.Data.Entities.Models;
using Tempo.Domain.Abstractions;
using Tempo.Domain.Models.ViewModels;

namespace Tempo.Domain.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        ICollection<Notification> GetUnOpenedNotificationsForUser(int userId);
        ResponseResult PostNotification(NotificationModel notification);
        ResponseResult OpenNotification(int userId, int notificationId);
    }
}
