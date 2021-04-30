using System;
using System.Collections.Generic;
using Tempo.Data.Entities.Models;
using Tempo.Domain.Abstractions;
using Tempo.Domain.Models.ViewModels;

namespace Tempo.Domain.Repositories.Interfaces
{
    public interface IGymRepository
    {
        ICollection<Gym> GetAllGyms();
        ResponseResult AddGym(GymModel gymModel);
        Gym EditGym(GymModel gymModel);
        ResponseResult DeleteGym(int gymId);
        int? CheckGymCapacity(int gymId, DateTime date);
        ICollection<RegularUser> SeeFriendsInGym(int userId, int gymId);
    }
}
