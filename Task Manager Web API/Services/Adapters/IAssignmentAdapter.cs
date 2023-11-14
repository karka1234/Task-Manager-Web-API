using Task_Manager_Web_API.Dto;
using Task_Manager_Web_API.Models;

namespace Task_Manager_Web_API.Services.Adapters
{
    public interface IAssignmentAdapter
    {
        public Assignment Bind(AddAssignmentDto task);
    }
}