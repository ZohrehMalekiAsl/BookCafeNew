using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookCafe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addaddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Customer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Plaque",
                table: "Customer",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Customer",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Address_Plaque",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Customer");
        }
    }
}
