using System;

namespace Gymify.Data.Entities.Models
{
    public class Notificiation
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime SentOn { get; set; }

        public int? RegularUserId { get; set; }
        public RegularUser RegularUser { get; set; }

        public int? AdminId { get; set; }
        public Admin Admin { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
