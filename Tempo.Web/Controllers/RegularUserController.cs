using Microsoft.AspNetCore.Authorization;
using Tempo.Domain.Repositories.Interfaces;
using Tempo.Web.Infrastructure;

namespace Tempo.Web.Controllers
{
    [Authorize(Policy = Policies.RegularUser)]
    public class RegularUserController : ApiController
    {
        private readonly IRegularUserRepository _regularUserRepository;

        public RegularUserController(IRegularUserRepository regularUserRepository)
        {
            _regularUserRepository = regularUserRepository;
        }
    }
}
