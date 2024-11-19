using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace template_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role_name",
                schema: "sip",
                table: "Roles",
                newName: "name");

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "sip",
                table: "Roles",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                schema: "sip",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "sip",
                table: "Roles",
                newName: "role_name");
        }
    }
}
