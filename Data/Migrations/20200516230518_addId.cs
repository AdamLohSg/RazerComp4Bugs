using Microsoft.EntityFrameworkCore.Migrations;

namespace FourBugs.Data.Migrations
{
    public partial class addId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Company",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Bid",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Company");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Bid",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
