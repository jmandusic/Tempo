using Tempo.Domain.Abstractions;
using Tempo.Domain.Models.ViewModels;

namespace Tempo.Domain.Repositories.Interfaces
{
    public interface IScheduleRepository
    {
        ResponseResult ReserveSchedule(ScheduleModel scheduleModel, int userId);
    }
}
