using System.Collections.Generic;

namespace Tempo.Data.Entities.Models
{
    public class RegularUser : User
    {
        public ICollection<GymUser> GymUsers { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
