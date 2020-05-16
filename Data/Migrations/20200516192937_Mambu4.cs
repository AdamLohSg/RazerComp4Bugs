using Microsoft.EntityFrameworkCore.Migrations;

namespace FourBugs.Data.Migrations
{
    public partial class Mambu4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AccountRoles",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DocumentID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MambuId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SavingsAccountID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValidUntil",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountRoles",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DocumentID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MambuId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SavingsAccountID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ValidUntil",
                table: "AspNetUsers");
        }
    }
}
