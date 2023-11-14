using Task_Manager_Web_API.Database;
using static Task_Manager_Web_API.Enums.Enums;
using Task_Manager_Web_API.Models;

namespace Task_Manager_Web_API.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly IAssignmentRepository _assignmentRepository;

        public CategoryRepository(AppDbContext context, IAssignmentRepository assignmentRepository)
        {
            _context = context;
            _assignmentRepository = assignmentRepository;
        }

       //add
        public void AddCategory(Category category)
        {
            _context.Categoryes.Add(category);
            _context.SaveChanges();
        }

        //update
        public void AssignmentToCategory(string categoryName, Guid assignmentId)
        {
            var category = GetCategoryByName(categoryName);
            var assignment = _assignmentRepository.GetAssignmentById(assignmentId);
            category.Assignments.Add(assignment);
            _context.SaveChanges();
        }

        //delete
        public void DeleteCategory(string categoryName)
        {
            var category = GetCategoryByName(categoryName);
            _context.Categoryes.Remove(category);
            _context.SaveChanges();
        }

        //get
        public Category GetCategoryByName(string categoryName)
        {
            var category = _context.Categoryes.FirstOrDefault(c => c.Name == categoryName);
            return category;
        }
        public IEnumerable<Assignment> GetCategoryAssignments(string categoryName)
        {
            var category = GetCategoryByName(categoryName);
            return category.Assignments;
        }
     
    }
}
