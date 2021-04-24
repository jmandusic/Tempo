using System.Collections.Generic;
using Tempo.Data.Enums;

namespace Tempo.Data.Entities.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Oib { get; set; }
        public Role Role { get; set; }

        public ICollection<Notificiation> Notificiations { get; set; }
    }
}
