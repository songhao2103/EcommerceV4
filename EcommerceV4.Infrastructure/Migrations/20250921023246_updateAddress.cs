using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceV4.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressDetail",
                table: "Company",
                newName: "addressDetail");

            migrationBuilder.AddColumn<string>(
                name: "addressDetail",
                table: "Store",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "city",
                table: "Store",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "commune",
                table: "Store",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "district",
                table: "Store",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "city",
                table: "Company",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "commune",
                table: "Company",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "district",
                table: "Company",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "addressDetail",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "city",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "commune",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "district",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "city",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "commune",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "district",
                table: "Company");

            migrationBuilder.RenameColumn(
                name: "addressDetail",
                table: "Company",
                newName: "AddressDetail");
        }
    }
}
