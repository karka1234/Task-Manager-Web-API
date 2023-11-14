using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Task_Manager_Web_API.Data;
using static Task_Manager_Web_API.Enums.Enums;

namespace Task_Manager_Web_API.Controllers
{
    [Authorize]
    [Route("User/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        /*  // del custom status code
         *         }
        // POST api/<CarController>
        [HttpPost("AddCar")]
        public async Task<IActionResult> AddNewCarAsync([FromBody] AddCarDto request)
        {
            if (string.IsNullOrEmpty(request?.Brand))
            {
                _logger.LogWarning("Post: Brand is null or empty");
                return ValidationProblem(detail: "Brand is required", statusCode: 400);
            }
            var cars = _carAdapter.Bind(request);
            await _carRepository.AddNew(cars);
            return Ok(cars);
        }
        // PUT api/<CarController>/5**/


        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("GetCurrentUser")]
        public IActionResult GetUsername()
        {
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            return Ok($"Hello, {username}!");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = (nameof(Role.User) + "," + nameof(Role.Admin)))]       
        
        [HttpGet("GetAllUsers")] // need to make more secure, integrate paging
        public IActionResult GetAllUsers()
        {
            var userList = _userRepository.GetAllUsers();
            if (userList == null) return NotFound();
            return Ok(userList);
        }

        [HttpGet("GetUserAssignments/{userId}")]
        public IActionResult GetUserAssignments([FromRoute] Guid userId)
        {
            var userAssignmentsList = _userRepository.GetUserAssignments(userId);
            if (userAssignmentsList == null) return NotFound();
            return Ok(userAssignmentsList);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = (nameof(Role.User) + "," + nameof(Role.Admin)))]
        [HttpGet("GetUserByItsNAme/{userName}")] // need to make more secure, integrate paging
        public IActionResult GetUserByUserName([FromRoute] string userName)
        {
            var userList = _userRepository.GetUserByUserName(userName);
            if (userList == null) return NotFound();
            return Ok(userList);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = (nameof(Role.User) + "," + nameof(Role.Admin)))]
        [HttpPut("{userId}")]
        public IActionResult ChangeUserRoleById([FromRoute] Guid userId, [FromBody] Role role)
        {
            _userRepository.ChangeUserRoleById(userId, role);
            return Ok("Role was changed");
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = (nameof(Role.User) + "," + nameof(Role.Admin)))]
        [HttpDelete("{userId}")]
        public IActionResult DeleteUser([FromRoute] Guid userId)
        {
            _userRepository.DeleteUser(userId);
            return Ok("User was deleted");
        }

        


    }
}
