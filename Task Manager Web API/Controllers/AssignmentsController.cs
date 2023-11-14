using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Manager_Web_API.Data;
using Task_Manager_Web_API.Dto;
using Task_Manager_Web_API.Models;
using Task_Manager_Web_API.Services.Adapters;
using static Task_Manager_Web_API.Enums.Enums;

namespace Task_Manager_Web_API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = nameof(Role.User))]
    [Route("Assignment/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IAssignmentAdapter _assignmentAdapter;
        public AssignmentsController(IAssignmentRepository assignmentRepository, IAssignmentAdapter assignmentAdapter)
        {
            _assignmentRepository = assignmentRepository;
            _assignmentAdapter = assignmentAdapter;
        }

        [HttpPost("AddAssignment")]
        public IActionResult AddAssignment([FromBody] AddAssignmentDto request)
        {
            Assignment newAssignment = _assignmentAdapter.Bind(request);
            newAssignment.Created = DateTime.Now;
            newAssignment.Stat = Status.NotAssigned;
            newAssignment.Visibility = AssignmentVisibility.privateView;
            _assignmentRepository.AddAssignment(newAssignment);
            return Ok(newAssignment);
        }

        /*
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
         */
    }
}
