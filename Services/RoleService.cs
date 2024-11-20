using Microsoft.EntityFrameworkCore;
using template_dotnet.Data;
using template_dotnet.DTOs;
using template_dotnet.Models;
using template_dotnet.Repositories;

namespace template_dotnet.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> CreateRoleAsync(RoleDto roleDto)
        {
            var role = new Role
            {
                Name = roleDto.Name,
                Description = roleDto.Description,
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false
            };

            return await _roleRepository.CreateRoleAsync(role);
        }

        public async Task<bool> DeleteRoleAsync(long roleId)
        {
            return await _roleRepository.DeleteRoleAsync(roleId);
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllRolesAsync();
        }

        public async Task<Role> GetRoleByIdAsync(long roleId)
        {
            var role = await _roleRepository.GetRoleByIdAsync(roleId);
            if (role == null)
            {
                throw new KeyNotFoundException($"Role with ID {roleId} not found.");
            }
            return role;
        }

    }

}
