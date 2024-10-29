using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeInsuranceApplication.Migrations
{
    public partial class renameRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Claimaint",
                table: "Users",
                newName: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "Claimaint");
        }
    }
}
