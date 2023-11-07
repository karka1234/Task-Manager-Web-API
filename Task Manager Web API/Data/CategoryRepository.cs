using Task_Manager_Web_API.Database;
using Task_Manager_Web_API.Enums;
using Task_Manager_Web_API.Models;

namespace Task_Manager_Web_API.Data
{
    public class CategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }



    }
}
