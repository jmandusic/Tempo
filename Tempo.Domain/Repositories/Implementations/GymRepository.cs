using Tempo.Data.Entities;
using Tempo.Domain.Repositories.Interfaces;
using Tempo.Domain.Services.Interfaces;

namespace Tempo.Domain.Repositories.Implementations
{
    public class GymRepository : IGymRepository
    {
        private readonly TempoDbContext _dbContext;
        private readonly IClaimProvider _claimProvider;

        public GymRepository(TempoDbContext dbContext, IClaimProvider claimProvider)
        {
            _dbContext = dbContext;
            _claimProvider = claimProvider;
        }
    }
}
