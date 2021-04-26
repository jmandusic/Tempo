using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tempo.Domain.Models.ViewModels;
using Tempo.Domain.Models.ViewModels.Account;
using Tempo.Domain.Repositories.Interfaces;
using Tempo.Domain.Services.Interfaces;

namespace Tempo.Web.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IRegularUserRepository _regularUserRepository;
        private readonly IJwtService _jwtService;

        public AccountController(IUserRepository userRepository,
            IRegularUserRepository regularUserRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _regularUserRepository = regularUserRepository;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost(nameof(RegisterRegularUser))]
        public ActionResult<string> RegisterRegularUser(RegistrationModel model)
        {
            var checkMailResponse = _userRepository.CheckEmail(model.Email);
            if (checkMailResponse.IsError)
                return BadRequest(checkMailResponse.Message);

            var registerRegularUserResult = _regularUserRepository.RegisterRegularUser(model);
            if (registerRegularUserResult.IsError)
                return BadRequest(registerRegularUserResult.Message);

            var token = _jwtService.GetJwtTokenForUser(registerRegularUserResult.Data);
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public ActionResult<string> Login(LoginModel model)
        {
            var result = _userRepository.GetUserIfValidCredentials(model);
            if (result.IsError)
                return BadRequest(result.Message);

            var user = result.Data;
            var token = _jwtService.GetJwtTokenForUser(user);
            return Ok(token);
        }

        [HttpGet]
        public ActionResult<UserModel> GetCurrentUserModel()
        {
            var user = _userRepository.GetCurrentUserModel();
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpGet(nameof(RefreshToken))]
        public ActionResult<string> RefreshToken([FromQuery] string token)
        {
            var newToken = _jwtService.GetNewToken(token);

            return Ok(newToken);
        }
    }
}
