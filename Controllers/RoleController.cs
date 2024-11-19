using Microsoft.AspNetCore.Mvc;
using template_dotnet.DTOs;
using template_dotnet.Models;
using template_dotnet.Services;

namespace template_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // POST: api/role
        [HttpPost]
        public async Task<ActionResult<Role>> CreateRole([FromBody] RoleDto roleDto)
        {
            if (roleDto == null || string.IsNullOrEmpty(roleDto.Name))
            {
                return BadRequest("Invalid role data.");
            }

            var role = await _roleService.CreateRoleAsync(roleDto);

            return CreatedAtAction(nameof(GetRoleById), new { id = role.Id }, role);
        }

        // DELETE: api/role/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(long id)
        {
            var result = await _roleService.DeleteRoleAsync(id);

            if (!result)
            {
                return NotFound("Role not found.");
            }

            return NoContent(); // Successful delete, return 204 status code
        }

        // GET: api/role/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRoleById(long id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);

            if (role == null)
            {
                return NotFound("Role not found.");
            }

            return Ok(role);
        }

        // GET: api/role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }
    }
}
