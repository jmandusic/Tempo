using System.Linq;
using Tempo.Data.Entities;
using Tempo.Data.Entities.Models;
using Tempo.Domain.Abstractions;
using Tempo.Domain.Models.ViewModels;
using Tempo.Domain.Repositories.Interfaces;
using Tempo.Domain.Services.Interfaces;

namespace Tempo.Domain.Repositories.Implementations
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly TempoDbContext _dbContext;

        public ScheduleRepository(TempoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResponseResult ReserveSchedule(ScheduleModel scheduleModel, int userId)
        {
            var user = _dbContext.RegularUsers.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return ResponseResult.Error("User not found");

            var newSchedule = new Schedule
            {
                GymId = scheduleModel.Gym.Id,
                RegularUserId = user.Id,
                Time = scheduleModel.Time
            };

            _dbContext.Schedules.Add(newSchedule);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }
    }
}
