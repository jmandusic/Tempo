using System.Collections.Generic;

namespace Tempo.Data.Entities.Models
{
    public class Gym
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public string ContactEmail { get; set; }
        public float MembershipFee { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int Capacity { get; set; }

        public int? AdminId { get; set; }
        public Admin Admin { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<GymUser> GymUsers { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
