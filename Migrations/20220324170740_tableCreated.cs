using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeWarsReservationBackend.Migrations
{
    public partial class tableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CohortInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CohortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeWarName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CohortLevelOfDifficulty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CohortInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompletedKatasInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeWarName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KataName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KataSlug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KataLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KataLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedKatasInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeWarName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KataName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KataSlug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KataLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KataLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CohortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeWarName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CohortInfo");

            migrationBuilder.DropTable(
                name: "CompletedKatasInfo");

            migrationBuilder.DropTable(
                name: "ReservationInfo");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
