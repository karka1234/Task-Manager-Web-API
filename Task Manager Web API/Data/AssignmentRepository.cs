using Task_Manager_Web_API.Database;
using Task_Manager_Web_API.Enums;
using Task_Manager_Web_API.Models;

namespace Task_Manager_Web_API.Data
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _userRepository;
        public AssignmentRepository(AppDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }
        //add
        public void AddAssignment(Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            _context.SaveChanges();
        }

        //update
        public void UserToAssignment(Guid userId, Guid assignmentId)
        {
            var user = _userRepository.GetUserById(userId);
            var assignment = GetAssignmentById(assignmentId);
            assignment.User = user;
            _context.SaveChanges();
        }
        public void ChangeAssignmentStatus(Guid id, Status status)
        {
            var assignment = GetAssignmentById(id);
            assignment.Stat = status;
            _context.SaveChanges();
        }

        //delete

        public void DeleteAssignment(Guid id)
        {
            var assignment = GetAssignmentById(id);
            _context.Assignments.Remove(assignment);
            _context.SaveChanges();
        }

        //get
        public IEnumerable<Assignment> GetAllAssignments()
        {
            var assignment = _context.Assignments;
            return assignment;
        }
        public Assignment GetAssignmentById(Guid id)
        {
            return _context.Assignments.FirstOrDefault(u => u.Id == id);
        }
        public IEnumerable<Assignment> GetAssignmentsByUserId(Guid userId)//testinti turetu sumapint 
        {
            //var user = _userRepository.GetUserById(userId);
            return _context.Assignments.Where(u => u.User.Id == userId);
        }
        public DateTime GetAssignmentDueDate(Guid id)
        {
            var assignment = GetAssignmentById(id);
            return assignment.DueDate;
        }


    }
}
