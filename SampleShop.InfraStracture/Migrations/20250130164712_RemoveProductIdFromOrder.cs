using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleShop.InfraStracture.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProductIdFromOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
