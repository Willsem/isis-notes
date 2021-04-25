using Microsoft.EntityFrameworkCore.Migrations;

namespace ISISNotesBackend.DataBase.NpgsqlContext.Migrations
{
    public partial class AddIsActivateFieldToSessionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Sessions",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Sessions");
        }
    }
}
