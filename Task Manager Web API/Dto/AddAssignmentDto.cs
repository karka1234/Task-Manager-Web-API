using static Task_Manager_Web_API.Enums.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager_Web_API.Dto
{
    public class AddAssignmentDto
    {
        public string Title { get; set; } = string.Empty;        
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }

/*      kurimo metu setint
 *      
        public AssignmentVisibility Visibility { get; set; }
        public Status Stat { get; set; } // update metu reiks tik tvarkyt
        public DateTime Created { get; set; } //sukurimo metu tik
*/
    }
}
