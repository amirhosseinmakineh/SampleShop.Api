using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleShop.InfraStracture.Migrations
{
    /// <inheritdoc />
    public partial class removeuseridfromrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Roles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
