using Task_Manager_Web_API.Database;
using Task_Manager_Web_API.Enums;
using Task_Manager_Web_API.Models;

namespace Task_Manager_Web_API.Data
{
    public class AssignmentRepository
    {
        private readonly AppDbContext _context;
        public AssignmentRepository(AppDbContext context)
        {
            _context = context;
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

        public IEnumerable<Assignment> GetAssignmentsByUserId(Guid userId)//testinti
        {
            //var user = _userRepository.GetUserById(userId);
            return _context.Assignments.Where(u => u.User.Id == userId);
        }

        //set
        public void Change(Guid id, Role role)
        {
            var assignment = GetUserById(id);
            user.AppRole = role;
            _context.SaveChanges();
        }
    }
}
