using System.Collections.Generic;

namespace Tempo.Data.Entities.Models
{
    public class RegularUser : User
    {
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public int? Age { get; set; }

        public ICollection<GymUser> GymUsers { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<RegularUser> Friends { get; set; }
    }
}
