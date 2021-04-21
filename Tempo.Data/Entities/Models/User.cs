using Gymify.Data.Entities.Models;
using Gymify.Data.Enums;
using System.Collections.Generic;

namespace Tempo.Data.Entities.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Oib { get; set; }
        public Role Role { get; set; }

        public ICollection<Notificiation> Notificiations { get; set; }
    }
}
