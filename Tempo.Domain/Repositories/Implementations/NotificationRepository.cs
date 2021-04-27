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
    public class NotificationRepository : INotificationRepository
    {
        private readonly TempoDbContext _dbContext;

        public NotificationRepository(TempoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public ICollection<Notification> GetUnOpenedNotificationsForUser(int userId)
        {
            var notifications = _dbContext.Notificiations
                .Include(n => n.UserNotifications
                .Where(un => !un.Opened && un.UserId == userId))
                .ToList();

            return notifications;
        }

        public ResponseResult PostNotification(NotificationModel notification)
        {
            var newNotification = new Notification
            {
                Id = _dbContext.Notificiations.Last().Id + 1,
                Message = notification.Message,
                SentOn = notification.SentOn,
            };
            _dbContext.Notificiations.Add(newNotification);


            var allUsers = _dbContext.Users.ToList();
            foreach (var user in allUsers)
            {
                foreach (var forUser in notification.ForUsers)
                {
                    if (user.Id == forUser.Id)
                    {
                        var newUserNotification = new UserNotification
                        {
                            UserId = user.Id,
                            NotificationId = newNotification.Id,
                        };
                        _dbContext.UserNotifications.Add(newUserNotification);
                    }
                }
            }

            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public ResponseResult OpenNotification(int userId, int notificationId)
        {
            var userNotification = _dbContext.UserNotifications
                .FirstOrDefault(un => un.UserId == userId && un.NotificationId == notificationId);

            if (userNotification == null)
                return ResponseResult.Error("Notification not found or already opened");


            userNotification.Opened = true;

            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }
    }
}
