using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerStatsNew.Migrations
{
    /// <inheritdoc />
    public partial class InitalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryModel",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlagURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryModel", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "VenuesModel",
                columns: table => new
                {
                    StadiumId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Surface = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenuesModel", x => x.StadiumId);
                });

            migrationBuilder.CreateTable(
                name: "LeagueModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeagueModel_CountryModel_Name",
                        column: x => x.Name,
                        principalTable: "CountryModel",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamModel",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    StadiumId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Founded = table.Column<int>(type: "int", nullable: true),
                    National = table.Column<bool>(type: "bit", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamModel", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_TeamModel_VenuesModel_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "VenuesModel",
                        principalColumn: "StadiumId");
                });

            migrationBuilder.CreateTable(
                name: "SeasonModel",
                columns: table => new
                {
                    SeasonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Standings = table.Column<bool>(type: "bit", nullable: false),
                    Players = table.Column<bool>(type: "bit", nullable: false),
                    TopScorers = table.Column<bool>(type: "bit", nullable: false),
                    TopAssists = table.Column<bool>(type: "bit", nullable: false),
                    TopCards = table.Column<bool>(type: "bit", nullable: false),
                    Injuries = table.Column<bool>(type: "bit", nullable: false),
                    Predictions = table.Column<bool>(type: "bit", nullable: false),
                    Odds = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonModel", x => x.SeasonId);
                    table.ForeignKey(
                        name: "FK_SeasonModel_CountryModel_CountryName",
                        column: x => x.CountryName,
                        principalTable: "CountryModel",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeasonModel_LeagueModel_Id",
                        column: x => x.Id,
                        principalTable: "LeagueModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeagueModel_Name",
                table: "LeagueModel",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonModel_CountryName",
                table: "SeasonModel",
                column: "CountryName");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonModel_Id",
                table: "SeasonModel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeamModel_StadiumId",
                table: "TeamModel",
                column: "StadiumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeasonModel");

            migrationBuilder.DropTable(
                name: "TeamModel");

            migrationBuilder.DropTable(
                name: "LeagueModel");

            migrationBuilder.DropTable(
                name: "VenuesModel");

            migrationBuilder.DropTable(
                name: "CountryModel");
        }
    }
}