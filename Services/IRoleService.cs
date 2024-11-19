using template_dotnet.DTOs;
using template_dotnet.Models;

namespace template_dotnet.Services
{
    public interface IRoleService
    {
        Task<Role> CreateRoleAsync(RoleDto roleDto);
        Task<bool> DeleteRoleAsync(long roleId);
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> GetRoleByIdAsync(long roleId);
    }

}
