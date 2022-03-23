using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeWarsReservationBackend.Migrations
{
    public partial class addedtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeWarName",
                table: "CohortInfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeWarName",
                table: "CohortInfo");
        }
    }
}
