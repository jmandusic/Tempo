using System.Collections.Generic;

namespace Tempo.Data.Entities.Models
{
    public class RegularUser : User
    {
        public ICollection<Schedule> Schedules { get; set; }
    }
}
