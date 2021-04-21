using Tempo.Data.Entities.Models;

namespace Tempo.Domain.Services.Interfaces
{
    public interface IJwtService
    {
        string GetJwtTokenForUser(User user);
        string GetNewToken(string token);
    }
}
