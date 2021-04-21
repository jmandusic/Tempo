using Tempo.Data.Entities.Models;
using Tempo.Domain.Abstractions;
using Tempo.Domain.Models.ViewModels;
using Tempo.Domain.Models.ViewModels.Account;

namespace Tempo.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        ResponseResult CheckEmail(string email);
        ResponseResult<User> GetUserIfValidCredentials(LoginModel model);
        User GetUser(int userId);
        UserModel GetCurrentUserModel();
    }
}
