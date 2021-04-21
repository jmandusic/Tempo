using Tempo.Data.Entities;
using Tempo.Domain.Repositories.Interfaces;
using Tempo.Domain.Services.Interfaces;

namespace Tempo.Domain.Repositories.Implementations
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly TempoDbContext _dbContext;
        private readonly IClaimProvider _claimProvider;

        public NotificationRepository(TempoDbContext dbContext, IClaimProvider claimProvider)
        {
            _dbContext = dbContext;
            _claimProvider = claimProvider;
        }
    }
}
