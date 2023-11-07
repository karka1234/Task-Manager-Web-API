using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager_Web_API.Models
{
    public class Category
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        //relations
        public List<Assignment> Assignments { get; set; }
        //Constructors
        public Category()
        {
        }

    }
}
