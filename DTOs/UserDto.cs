namespace template_dotnet.DTOs
{
    public class UserDto
    {
        public long Id { get; set; } // Unique identifier
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty; // Name of the associated role
    }
}
