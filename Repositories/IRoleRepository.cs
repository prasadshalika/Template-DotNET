using template_dotnet.Models;

namespace template_dotnet.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> CreateRoleAsync(Role role);
        Task<bool> DeleteRoleAsync(long roleId);
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role?> GetRoleByIdAsync(long roleId);
    }
}
