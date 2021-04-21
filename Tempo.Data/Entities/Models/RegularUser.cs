using Gymify.Data.Enums;
using System.Collections.Generic;
using Tempo.Data.Entities.Models;

namespace Gymify.Data.Entities.Models
{
    public class RegularUser : User
    {
        public ICollection<GymUser> GymUsers { get; set; }
    }
}
