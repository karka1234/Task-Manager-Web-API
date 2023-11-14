using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Task_Manager_Web_API.Enums.Enums;

namespace Task_Manager_Web_API.Models
{
    public class Assignment
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(20)")]
        public Status Stat { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public AssignmentVisibility Visibility { get; set; }
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;     
        public DateTime DueDate { get; set; }
        public DateTime Created { get; set; }

        //Relations
        public User? User { get; set; } 




    }
}
