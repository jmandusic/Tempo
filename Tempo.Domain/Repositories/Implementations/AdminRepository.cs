using Tempo.Data.Entities;
using Tempo.Domain.Repositories.Interfaces;
using Tempo.Domain.Services.Interfaces;

namespace Tempo.Domain.Repositories.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly TempoDbContext _dbContext;
        private readonly IClaimProvider _claimProvider;

        public AdminRepository(TempoDbContext dbContext, IClaimProvider claimProvider)
        {
            _dbContext = dbContext;
            _claimProvider = claimProvider;
        }
    }
}
