using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Manager_Web_API.Data;
using Task_Manager_Web_API.Requests;
using Task_Manager_Web_API.Services;

namespace Task_Manager_Web_API.Controllers
{
    [Route("Login/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public LoginController(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        [HttpPost(("SignupNewAccount"))]
        public IActionResult SignupNewAccount([FromBody] SignupNewAccountRequest request)
        {
            var account = _userRepository.RegisterNewUser(request.UserName, request.Password, request.JobTitle);
            return Ok(account);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var success = _userRepository.Login(request.Username, request.Password);
            if (!success) 
                return Unauthorized();
            return Ok(_jwtService.GetJwtToken(request.Username));
        }
    }
}
