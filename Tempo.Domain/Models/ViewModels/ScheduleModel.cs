using System;

namespace Tempo.Domain.Models.ViewModels
{
    public class ScheduleModel
    {
        public DateTime Time { get; set; }
        public RegularUserModel RegularUser { get; set; }
        public GymModel Gym { get; set; }
    }
}
