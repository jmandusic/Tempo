using Tempo.Data.Entities;
using Tempo.Data.Entities.Models;
using Tempo.Domain.Abstractions;
using Tempo.Domain.Helpers;
using Tempo.Domain.Models.ViewModels.Account;
using Tempo.Domain.Repositories.Interfaces;

namespace Tempo.Domain.Repositories.Implementations
{
    public class RegularUserRepository : IRegularUserRepository
    {
        private readonly TempoDbContext _dbContext;

        public RegularUserRepository(TempoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResponseResult<RegularUser> RegisterRegularUser(RegistrationModel model)
        {
            var password = EncryptionHelper.Hash(model.Password);
            var regularUser = new RegularUser
            {
                Email = model.Email,
                Name = model.Name,
                Password = password
            };

            _dbContext.Add(regularUser);
            _dbContext.SaveChanges();
            return new ResponseResult<RegularUser>(regularUser);
        }
    }
}
