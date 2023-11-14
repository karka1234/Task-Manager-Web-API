using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Task_Manager_Web_API.Enums.Enums;

namespace Task_Manager_Web_API.Models
{
    public class User
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public byte[] Password { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(20)")]
        public JobTitle Job { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public Role AppRole { get; set; }

        //Relations
        public List<Assignment>? Assignments { get; set; }






    }
}
