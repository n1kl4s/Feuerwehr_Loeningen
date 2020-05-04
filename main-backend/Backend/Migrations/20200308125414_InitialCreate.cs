using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Backend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classification",
                columns: table => new
                {
                    classificationid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    classificationart = table.Column<string>(maxLength: 50, nullable: false),
                    classificationtype = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classification", x => x.classificationid);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    clientid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clientname = table.Column<string>(maxLength: 50, nullable: false),
                    clientprename = table.Column<string>(maxLength: 50, nullable: false),
                    clientsurname = table.Column<string>(maxLength: 50, nullable: false),
                    clientpasswordhash = table.Column<string>(maxLength: 256, nullable: false),
                    clientpasswordsalt = table.Column<string>(maxLength: 128, nullable: false),
                    clientrole = table.Column<string>(maxLength: 100, nullable: false),
                    clientposition = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.clientid);
                });

            migrationBuilder.CreateTable(
                name: "crew",
                columns: table => new
                {
                    crewid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    crewvalue = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crew", x => x.crewid);
                });

            migrationBuilder.CreateTable(
                name: "engine",
                columns: table => new
                {
                    engineid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enginenumber = table.Column<string>(maxLength: 7, nullable: true),
                    engineps = table.Column<int>(nullable: true),
                    enginecapacityccm = table.Column<int>(nullable: true),
                    enginecylinder = table.Column<int>(nullable: true),
                    engineconstructionyear = table.Column<int>(nullable: false),
                    enginelength = table.Column<int>(nullable: false),
                    enginewidth = table.Column<int>(nullable: false),
                    enginehight = table.Column<int>(nullable: false),
                    enginebody = table.Column<string>(maxLength: 50, nullable: true),
                    enginechassis = table.Column<string>(maxLength: 50, nullable: true),
                    engineisdeprecated = table.Column<bool>(nullable: false),
                    enginelicenseplate = table.Column<string>(maxLength: 12, nullable: false),
                    engineradiocall = table.Column<string>(maxLength: 50, nullable: true),
                    classificationid = table.Column<int>(nullable: false),
                    crewid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_engine", x => x.engineid);
                    table.ForeignKey(
                        name: "FK_engine_classification_classificationid",
                        column: x => x.classificationid,
                        principalTable: "classification",
                        principalColumn: "classificationid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_engine_crew_crewid",
                        column: x => x.crewid,
                        principalTable: "crew",
                        principalColumn: "crewid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_engine_classificationid",
                table: "engine",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "IX_engine_crewid",
                table: "engine",
                column: "crewid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "engine");

            migrationBuilder.DropTable(
                name: "classification");

            migrationBuilder.DropTable(
                name: "crew");
        }
    }
}
