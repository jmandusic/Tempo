using System;
using Tempo.Data.Entities.Models;

namespace Gymify.Data.Entities.Models
{
    public class Notificiation
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime SentOn { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
