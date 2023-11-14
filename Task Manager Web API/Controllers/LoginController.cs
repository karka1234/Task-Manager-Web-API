using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Manager_Web_API.Data;
using static Task_Manager_Web_API.Enums.Enums;
using Task_Manager_Web_API.Requests;
using Task_Manager_Web_API.Services;
using Task_Manager_Web_API.Models;

namespace Task_Manager_Web_API.Controllers
{
    [Route("Login/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {         
        private readonly ILoginService _loginService;
        private readonly IJwtService _jwtService;

        public LoginController(IJwtService jwtService, ILoginService loginService)
        {
            _jwtService = jwtService;
            _loginService = loginService;
        }

        [HttpPost("RegisterNewUser")]
        public IActionResult RegisterNewUser([FromBody] SignupNewAccountRequest request)
        {
            var account = _loginService.RegisterNewUser(request.UserName, request.Password);
            return Ok(account);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var response = _loginService.Login(request.UserName, request.Password);
            if (!response.isSuccess) 
                return Unauthorized();
            return Ok(_jwtService.GetJwtToken(request.UserName, (Role)response.Role));//cia gal ID naudoti
        }

    }
}
