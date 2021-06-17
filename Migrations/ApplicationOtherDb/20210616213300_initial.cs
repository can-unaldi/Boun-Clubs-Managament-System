using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BounClubs.Migrations.ApplicationOtherDb
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClubUserName = table.Column<string>(nullable: true),
                    ClubName = table.Column<string>(nullable: true),
                    ClubDescription = table.Column<string>(nullable: true),
                    ClubMail = table.Column<string>(nullable: true),
                    ClubWebSite = table.Column<string>(nullable: true),
                    ClubAdvisorUserName = table.Column<string>(nullable: true),
                    ClubLogo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClubId = table.Column<string>(nullable: true),
                    ClubName = table.Column<string>(nullable: true),
                    EventName = table.Column<string>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    EventDescription = table.Column<string>(nullable: true),
                    ParticipantCount = table.Column<int>(nullable: false),
                    Revenue = table.Column<bool>(nullable: false),
                    Media = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    Speaker = table.Column<string>(nullable: true),
                    AdvisorApproval = table.Column<int>(nullable: false),
                    ReservationApproval = table.Column<int>(nullable: false),
                    KakApproval = table.Column<int>(nullable: false),
                    DeanAproval = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
