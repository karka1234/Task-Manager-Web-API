using static Task_Manager_Web_API.Enums.Enums;

namespace Task_Manager_Web_API.Dto
{
    public record LoginResponseDTO(bool isSuccess, Role? Role = null);


}
