using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceV4.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addStoreColums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Store",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Store",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreName",
                table: "Store",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Store",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Company",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Company",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "StoreName",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Company");
        }
    }
}
