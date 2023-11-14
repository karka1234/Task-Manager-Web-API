using static Task_Manager_Web_API.Enums.Enums;
using Task_Manager_Web_API.Models;

namespace Task_Manager_Web_API.Data
{
    public interface IAssignmentRepository
    {
        void AddAssignment(Assignment assignment);
        void ChangeAssignmentStatus(Guid id, Status status);
        void DeleteAssignment(Guid id);
        IEnumerable<Assignment> GetAllAssignments();
        Assignment GetAssignmentById(Guid id);
        DateTime GetAssignmentDueDate(Guid id);
        IEnumerable<Assignment> GetAssignmentsByUserId(Guid userId);
        void UserToAssignment(Guid userId, Guid assignmentId);
    }
}