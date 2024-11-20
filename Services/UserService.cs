using template_dotnet.Data;
using template_dotnet.DTOs;
using template_dotnet.Models;
using template_dotnet.Repositories;

namespace template_dotnet.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.UserName,
                FirstName = u.FirstName,
                LastName = u.LastName,
                RoleName = u.Role.Name
            });
        }

        public async Task<UserDto?> GetUserByIdAsync(long id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                RoleName = user.Role.Name
            };
        }

        public async Task<UserDto> CreateUserAsync(CreateUserRequestDto createUserDto)
        {
            var role = await _userRepository.GetRoleByIdAsync(createUserDto.RoleId);
            if (role == null)
                throw new ArgumentException("Invalid RoleId");

            if (string.IsNullOrWhiteSpace(createUserDto.UserName) || string.IsNullOrWhiteSpace(createUserDto.Password))
            {
                throw new ArgumentException("Username and Password are required.");
            }

            // Hash the password (ensure `HashPassword` is working properly)
            string hashedPassword = HashPassword(createUserDto.Password);

            // Initialize UserAccount with non-null values
            var userAccount = new UserAccount(
                createUserDto.UserName,                       // Assuming this is required
                hashedPassword,                               // Ensure it's hashed properly
                createUserDto.RestoredPassword ?? string.Empty, // If it's optional, use an empty string
                createUserDto.FirstName ?? string.Empty,      // If optional, default to empty string
                createUserDto.LastName ?? string.Empty,       // If optional, default to empty string
                role                                          // Ensure `role` is a valid `Role` object
            );

            await _userRepository.AddUserAsync(userAccount);

            return new UserDto
            {
                Id = userAccount.Id,
                UserName = userAccount.UserName,
                FirstName = userAccount.FirstName,
                LastName = userAccount.LastName,
                RoleName = role.Name
            };
        }

        public async Task UpdateUserAsync(long id, CreateUserRequestDto updateUserDto)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            var role = await _userRepository.GetRoleByIdAsync(updateUserDto.RoleId);
            if (role == null)
                throw new ArgumentException("Invalid RoleId");

            user.UserName = updateUserDto.UserName;
            user.Password = HashPassword(updateUserDto.Password);
            user.RestoredPassword = updateUserDto.RestoredPassword;
            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            user.Role = role;

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(long id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        private string HashPassword(string password)
        {
            // Implement password hashing here
            return password; // Placeholder
        }
    }

}
