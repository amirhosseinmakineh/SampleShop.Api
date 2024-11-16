using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleShop.InfraStracture.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoruId",
                table: "ProductDetails");

            migrationBuilder.AddColumn<long>(
                name: "ProductI",
                table: "Colors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductI",
                table: "Colors");

            migrationBuilder.AddColumn<int>(
                name: "CategoruId",
                table: "ProductDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
