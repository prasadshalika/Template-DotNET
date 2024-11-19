using template_dotnet.DTOs;

namespace template_dotnet.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(long id);
        Task<UserDto> CreateUserAsync(CreateUserRequestDto createUserDto);
        Task UpdateUserAsync(long id, CreateUserRequestDto updateUserDto);
        Task DeleteUserAsync(long id);
    }

}
