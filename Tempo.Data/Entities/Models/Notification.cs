using System;
using System.Collections.Generic;

namespace Tempo.Data.Entities.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime SentOn { get; set; }

        public ICollection<UserNotification> UserNotifications { get; set; }
    }
}
