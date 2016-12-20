using Microsoft.EntityFrameworkCore.Migrations;

namespace NetAdmin.DataAccess.Migrations
{
    public partial class RemoveHashColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Hash",
                "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                "Hash",
                "Users",
                nullable: true);
        }
    }
}