using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tempo.Data.Entities;
using Tempo.Data.Entities.Models;
using Tempo.Domain.Abstractions;
using Tempo.Domain.Models.ViewModels;
using Tempo.Domain.Repositories.Interfaces;

namespace Tempo.Domain.Repositories.Implementations
{
    public class GymRepository : IGymRepository
    {
        private readonly TempoDbContext _dbContext;

        public GymRepository(TempoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Gym> GetAllGyms()
        {
            return _dbContext.Gyms.ToList();
        }


        public ResponseResult AddGym(GymModel gymModel)
        {
            var gym = new Gym
            {
                Id = gymModel.Id,
                Name = gymModel.Name,
                Rating = gymModel.Rating,
                ContactEmail = gymModel.ContactEmail,
                Capacity = gymModel.Capacity,
                Latitude = gymModel.Latitude,
                Longitude = gymModel.Longitude,
                StartOfWork = gymModel.StartOfWork,
                EndOfWork = gymModel.EndOfWork,
                AdminId = gymModel.Admin.Id,
                AdressId = gymModel.Adress.Id,
            };

            _dbContext.Gyms.Add(gym);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public Gym EditGym(int gymId, GymModel gymModel)
        {
            var gym = _dbContext.Gyms.Find(gymId);

            gym.Name = gymModel.Name;
            gym.Rating = gymModel.Rating;
            gym.ContactEmail = gymModel.ContactEmail;
            gym.Capacity = gymModel.Capacity;
            gym.Latitude = gymModel.Latitude;
            gym.Longitude = gymModel.Longitude;
            gym.StartOfWork = gymModel.StartOfWork;
            gym.EndOfWork = gymModel.EndOfWork;
            gym.AdminId = gymModel.Admin.Id;
            gym.AdressId = gymModel.Adress.Id;

            _dbContext.SaveChanges();

            return gym;
        }


        public ResponseResult DeleteGym(int gymId)
        {
            var gym = _dbContext.Gyms.FirstOrDefault(g => g.Id == gymId);
            if (gym == null)
                return ResponseResult.Error("Gym not found");

            _dbContext.Gyms.Remove(gym);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public int? CheckGymCapacity(int gymId, DateTime date)
        {
            var gym = _dbContext.Gyms.Find(gymId);
            if (gym == null)
                return null;

            var oneHourInTicks = 72000;
            var membersAtTheTime = _dbContext.Schedules
                .Where(s => s.GymId == gymId 
                && s.Time.Ticks > date.Ticks - oneHourInTicks
                && s.Time.Ticks < date.Ticks + oneHourInTicks)
                .ToList()
                .Count();

            return membersAtTheTime;
        }

        public ICollection<RegularUser> SeeFriendsInGym(int userId, int gymId)
        {
            var friendsList = new List<RegularUser>();

            var user = _dbContext.RegularUsers.Find(userId);
            var sameGymMembers = _dbContext.RegularUsers
                .Include(ru => ru.GymUsers
                .Where(gu => gu.GymId == gymId))
                .ToList();

            foreach (var sameGymMember in sameGymMembers)
            {
                if (user.Friends.Contains(sameGymMember))
                    friendsList.Add(sameGymMember);
            }

            return friendsList;

        }
    }
}
