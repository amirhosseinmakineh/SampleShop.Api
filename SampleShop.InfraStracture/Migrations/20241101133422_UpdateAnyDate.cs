using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleShop.InfraStracture.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAnyDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreateObjectDat",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "CreateObjectTime",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateObjectTime",
                table: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateObjectDat",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
