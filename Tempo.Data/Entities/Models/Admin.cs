using Gymify.Data.Enums;
using System.Collections.Generic;

namespace Gymify.Data.Entities.Models
{
    public class Admin
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
