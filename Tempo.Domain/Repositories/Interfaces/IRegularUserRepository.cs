using Tempo.Data.Entities.Models;
using Tempo.Domain.Abstractions;
using Tempo.Domain.Models.ViewModels.Account;

namespace Tempo.Domain.Repositories.Interfaces
{
    public interface IRegularUserRepository
    {
        ResponseResult<RegularUser> RegisterRegularUser(RegistrationModel model);
    }
}
