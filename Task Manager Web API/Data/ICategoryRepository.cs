using Task_Manager_Web_API.Models;

namespace Task_Manager_Web_API.Data
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        void AssignmentToCategory(string categoryName, Guid assignmentId);
        void DeleteCategory(string categoryName);
        IEnumerable<Assignment> GetCategoryAssignments(string categoryName);
        Category GetCategoryByName(string categoryName);
    }
}