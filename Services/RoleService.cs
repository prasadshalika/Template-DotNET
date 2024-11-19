using Microsoft.EntityFrameworkCore;
using template_dotnet.Data;
using template_dotnet.DTOs;
using template_dotnet.Models;

namespace template_dotnet.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;

        public RoleService(AppDbContext context)
        {
            _context = context;
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

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return role;
        }

        public async Task<bool> DeleteRoleAsync(long roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role == null)
                return false;

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            var roles = await _context.Roles.ToListAsync();

            // Ensure roles are never null
            return roles;
        }

        public async Task<Role> GetRoleByIdAsync(long roleId)
        {
            var role = await _context.Roles
                .Include(r => r.Users) // Include related users, if necessary
                .FirstOrDefaultAsync(r => r.Id == roleId);

            if (role == null)
            {
                // Handle the case where the role is not found (you can throw an exception or return null)
                throw new KeyNotFoundException($"Role with ID {roleId} not found.");
            }

            return role;
        }

    }

}
