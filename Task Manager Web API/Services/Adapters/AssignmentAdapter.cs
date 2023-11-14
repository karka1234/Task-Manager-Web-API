using Task_Manager_Web_API.Dto;
using Task_Manager_Web_API.Models;
using static Task_Manager_Web_API.Enums.Enums;

namespace Task_Manager_Web_API.Services.Adapters
{
    public class AssignmentAdapter : IAssignmentAdapter
    {
        public Assignment Bind(AddAssignmentDto task)
        {
            return new Assignment()
            {
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
            };
        }

    }
}
