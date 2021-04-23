namespace Tempo.Domain.Models.ViewModels
{
    public class GymModel
    {
        public string Name { get; set; }
        public float Rating { get; set; }
        public string ContactEmail { get; set; }
        public float MembershipFee { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int Capacity { get; set; }
    }
}
