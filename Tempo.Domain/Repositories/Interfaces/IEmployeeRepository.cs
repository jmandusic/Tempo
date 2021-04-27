using System.Collections.Generic;
using Tempo.Data.Entities.Models;
using Tempo.Domain.Abstractions;

namespace Tempo.Domain.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        ResponseResult AddMember(int userId, int gymId);
        ResponseResult DeleteMember(int userId);
        ResponseResult MembershipPayedInCash(int userId, int gymId);
        ICollection<RegularUser> CheckMemberships(int gymId);
    }
}
