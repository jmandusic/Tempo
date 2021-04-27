namespace Tempo.Data.Entities.Models
{
    public class UserNotification
    {
        public int Id { get; set; }
        public bool Opened { get; set; } = false;

        public int? NotificationId { get; set; }
        public Notification Notification { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}