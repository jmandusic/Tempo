namespace Tempo.Data.Entities.Models
{
    public class GymUser
    {
        public int Id { get; set; }

        public int? GymId { get; set; }
        public Gym Gym { get; set; }

        public int? RegularUserId { get; set; }
        public RegularUser RegularUser { get; set; }
    }
}
