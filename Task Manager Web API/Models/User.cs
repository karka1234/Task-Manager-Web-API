using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Task_Manager_Web_API.Enums;

namespace Task_Manager_Web_API.Models
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        public byte[] Password { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public JobTitle Job { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public Role AppRole { get; set; }

        //Relations
        public List<Assignment> Tasks { get; set; }




        //Constructors
        public User()
        {
        }


    }
}
