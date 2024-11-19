using template_dotnet.Data;
using template_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace template_dotnet.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserAccount>> GetAllUsersAsync()
        {
            return await _context.UserAccounts.Include(u => u.Role).ToListAsync();
        }

        public async Task<UserAccount?> GetUserByIdAsync(long id)
        {
            return await _context.UserAccounts
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddUserAsync(UserAccount userAccount)
        {
            await _context.UserAccounts.AddAsync(userAccount);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserAccount userAccount)
        {
            _context.UserAccounts.Update(userAccount);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(long id)
        {
            var user = await _context.UserAccounts.FindAsync(id);
            if (user != null)
            {
                _context.UserAccounts.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Role?> GetRoleByIdAsync(long roleId)
        {
            return await _context.Roles.FindAsync(roleId);
        }
    }

}
