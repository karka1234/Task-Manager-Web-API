using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Task_Manager_Web_API.Enums;

namespace Task_Manager_Web_API.Models
{
    public class Assignment
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public Status Stat { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public AssignmentVisibility Visibility { get; set; }        
        [MaxLength(200)]
        public string Description { get; set; }        
        public DateTime DueDate { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        //Relations
        public User User { get; set; }

        //Constructors
        public Assignment() { }


    }
}
