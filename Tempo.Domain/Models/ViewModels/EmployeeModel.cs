using System;
using Tempo.Data.Entities.Models;
using Tempo.Data.Enums;

namespace Tempo.Domain.Models.ViewModels
{
    public class EmployeeModel : UserModel
    {
        public DateTime HiredOn { get; set; }
        public float PricePerHour { get; set; }
        public EmployeeRole EmployeeRole { get; set; }
        public Gym Gym { get; set; }
    }
}
