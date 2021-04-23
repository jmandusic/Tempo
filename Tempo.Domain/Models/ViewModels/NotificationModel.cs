using System;
using Tempo.Data.Entities.Models;

namespace Tempo.Domain.Models.ViewModels
{
    public class NotificationModel
    {
        public string Message { get; set; }
        public DateTime SentOn { get; set; }
        public User User { get; set; }
    }
}
