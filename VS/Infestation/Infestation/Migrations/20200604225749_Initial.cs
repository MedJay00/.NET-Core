using Microsoft.EntityFrameworkCore.Migrations;

namespace Infestation.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorldPart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldPart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Population = table.Column<int>(nullable: false),
                    SickCount = table.Column<int>(nullable: false),
                    DeadCount = table.Column<int>(nullable: false),
                    RecoveredCount = table.Column<int>(nullable: false),
                    Vaccine = table.Column<bool>(nullable: false),
                    WorldPartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_WorldPart_WorldPartId",
                        column: x => x.WorldPartId,
                        principalTable: "WorldPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Humans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    IsSick = table.Column<bool>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Humans_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    IsFake = table.Column<bool>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Humans_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Humans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WorldPart",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Australia" },
                    { 2, "Asia" },
                    { 3, "America" },
                    { 4, "Antarctica" },
                    { 5, "Africa" },
                    { 6, "Europe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_WorldPartId",
                table: "Countries",
                column: "WorldPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Humans_CountryId",
                table: "Humans",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_News_AuthorId",
                table: "News",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Humans");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "WorldPart");
        }
    }
}
