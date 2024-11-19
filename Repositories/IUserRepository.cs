using template_dotnet.Models;

namespace template_dotnet.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserAccount>> GetAllUsersAsync();
        Task<UserAccount?> GetUserByIdAsync(long id);
        Task AddUserAsync(UserAccount userAccount);
        Task UpdateUserAsync(UserAccount userAccount);
        Task DeleteUserAsync(long id);
        Task<Role?> GetRoleByIdAsync(long roleId);
    }
}
