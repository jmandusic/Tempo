using System.Linq;
using Tempo.Data.Entities;
using Tempo.Data.Entities.Models;
using Tempo.Domain.Abstractions;
using Tempo.Domain.Helpers;
using Tempo.Domain.Models.ViewModels;
using Tempo.Domain.Models.ViewModels.Account;
using Tempo.Domain.Repositories.Interfaces;
using Tempo.Domain.Services.Interfaces;

namespace Tempo.Domain.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly TempoDbContext _dbContext;
        private readonly IClaimProvider _claimProvider;

        public UserRepository(TempoDbContext dbContext, IClaimProvider claimProvider)
        {
            _dbContext = dbContext;
            _claimProvider = claimProvider;
        }

        public ResponseResult CheckEmail(string email)
        {
            var isEmailTaken = _dbContext.Users.Any(u => u.Email == email.ToLower().Trim());

            return isEmailTaken
                ? ResponseResult.Error($"{email} is already taken")
                : ResponseResult.Ok;
        }

        public ResponseResult<User> GetUserIfValidCredentials(LoginModel model)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == model.Email.ToLower().Trim());
            if (user is null)
                return ResponseResult<User>.Error("Invalid password or email");

            var isValidPassword = EncryptionHelper.ValidatePassword(model.Password, user.Password);
            return isValidPassword
                ? new ResponseResult<User>(user)
                : ResponseResult<User>.Error("Invalid password or email");
        }

        public User GetUser(int userId)
        {
            var user = _dbContext.Users.Find(userId);
            return user;
        }

        public UserModel GetCurrentUserModel()
        {
            var user = _dbContext.Users
                .Where(u => u.Id == _claimProvider.GetUserId())
                .Select(u => new UserModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    Name = u.Name,
                })
                .SingleOrDefault();

            return user;
        }
    }
}

