using Gymify.Data.Enums;
using System;

namespace Tempo.Data.Entities.Models
{
    public class Employee : User
    {
        public DateTime HiredOn { get; set; }
        public float PricePerHour { get; set; }
        public EmployeeRole EmployeeRole { get; set; }

        public int? GymId { get; set; }
        public Gym Gym { get; set; }
    }
}
