using static Task_Manager_Web_API.Enums.Enums;

namespace Task_Manager_Web_API.Requests
{
    public class SignupNewAccountRequest
    {
        public string UserName { get; set; }
        public JobTitle JobTitle { get; set; }
        public string Password { get; set; }
    }
}
