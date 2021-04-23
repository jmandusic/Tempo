using System;

namespace Tempo.Data.Entities.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }


        public int? RegularUserId { get; set; }
        public RegularUser RegularUSer { get; set; }

        public int? GymId { get; set; }
        public Gym Gym { get; set; }
    }
}
