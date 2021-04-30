using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tempo.Data.Entities;
using Tempo.Data.Entities.Models;
using Tempo.Domain.Abstractions;
using Tempo.Domain.Repositories.Interfaces;

namespace Tempo.Domain.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TempoDbContext _dbContext;

        public EmployeeRepository(TempoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResponseResult DeleteMember(int userId)
        {
            var user = _dbContext.GymUsers.First(gu => gu.RegularUserId == userId);
            if (user == null)
                return ResponseResult.Error("User not found");

            _dbContext.GymUsers.Remove(user);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public ICollection<RegularUser> CheckMemberships(int gymId)
        {
            var oneMonthInTicks = 51846000;
            var gymUsers = _dbContext.GymUsers
                .Where(gu => gu.GymId == gymId
                && gu.PayedOn.Ticks <= DateTime.Now.Ticks - oneMonthInTicks)
                .ToList();

            if (gymUsers.Count() == 0)
                return new List<RegularUser>();


            foreach (var user in gymUsers)
            {
                user.isMembershipPayed = false;
            }

            _dbContext.SaveChanges();

            var usersWithUnpayedMembership = _dbContext.RegularUsers
                .Include(ru => ru.GymUsers
                .Where(gu => gu.GymId == gymId && !gu.isMembershipPayed))
                .ToList();

            return usersWithUnpayedMembership;
        }

        public ResponseResult MembershipPayedInCash(int userId, int gymId)
        {
            var gymUser = _dbContext.GymUsers
                .Where(gu => gu.GymId == gymId && gu.RegularUserId == userId)
                .FirstOrDefault();

            if (gymUser == null)
            {
                return ResponseResult.Error("User not found");
            }

            gymUser.isMembershipPayed = true;
            gymUser.PayedOn = DateTime.Now;

            _dbContext.SaveChanges();
            return ResponseResult.Ok;
        }


    }
}
