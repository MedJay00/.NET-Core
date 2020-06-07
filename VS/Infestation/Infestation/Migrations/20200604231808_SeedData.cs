using Microsoft.EntityFrameworkCore.Migrations;

namespace Infestation.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                    table: "Countries",
                    columns: new[] { "Id", "DeadCount", "Name", "Population", "RecoveredCount", "SickCount", "Vaccine", "WorldPartId" },
                    values: new object[] { 1, 97811, "US", 328200000, 376266, 1647741, false, 3 });

            migrationBuilder.InsertData(
                    table: "Countries",
                    columns: new[] { "Id", "Name", "Population", "SickCount", "DeadCount", "RecoveredCount", "Vaccine", "WorldPartId" },
                    values: new object[] { 2, "Brazil", 209500000, 271628, 17971, 100459, false, 3 });

            migrationBuilder.InsertData(
                    table: "Countries",
                    columns: new[] { "Id", "Name", "Population", "SickCount", "DeadCount", "RecoveredCount", "Vaccine", "WorldPartId" },
                    values: new object[] { 3, "Russia", 144500000, 299941, 2837, 76130, false, 2 });



            migrationBuilder.InsertData(
                    table: "Humans",
                    columns: new[] { "Id", "Age", "CountryId", "FirstName", "Gender", "IsSick", "LastName" },
                    values: new object[] { 1, 38, 1, "Obi-wan", "Male", false, "Kenobi" });

            migrationBuilder.InsertData(
                    table: "Humans",
                    columns: new[] { "Id", "Age", "CountryId", "FirstName", "Gender", "IsSick", "LastName" },
                    values: new object[] { 2, 54, 1, "Sanwise", "Male", false, "Gamgee" });

            migrationBuilder.InsertData(
                    table: "Humans",
                    columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                    values: new object[] { 3, "Hose", "Rodriges", 30, true, "Male", 3 });

            migrationBuilder.InsertData(
                    table: "Humans",
                    columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                    values: new object[] { 4, "Consuela", "Tridana", 43, false, "Female", 3 });

            migrationBuilder.InsertData(
                    table: "Humans",
                    columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                    values: new object[] { 5, "Ana", "Cormelia", 25, true, "Female", 3 });

            migrationBuilder.InsertData(
                    table: "Humans",
                    columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                    values: new object[] { 6, "Svetlana", "Sokolova", 44, false, "Female", 2 });

            migrationBuilder.InsertData(
                    table: "Humans",
                    columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                    values: new object[] { 7, "Petr", "Ilich", 53, true, "Male", 2 });

            migrationBuilder.InsertData(
                    table: "Humans",
                    columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                    values: new object[] { 8, "Thomas", "Edison", 84, true, "Male", 1 });

            migrationBuilder.InsertData(
                    table: "Humans",
                    columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                    values: new object[] { 9, "Arnold", "Schwarzenegger", 72, true, "Male", 1 });

            migrationBuilder.InsertData(
                    table: "Humans",
                    columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                    values: new object[] { 10, "Jeremy", "Clarkson", 60, false, "Male", 2 });

            migrationBuilder.InsertData(
                    table: "Humans",
                    columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                    values: new object[] { 11, "Richard", "Hammond", 50, true, "Male", 3 });



            migrationBuilder.InsertData(
                    table: "News",
                    columns: new[] { "Id", "Title", "Text", "IsFake", "AuthorId" },
                    values: new object[] { 0, "Humanity finally colonized the Mercury!!", "", true, 1 });

            migrationBuilder.InsertData(
                    table: "News",
                    columns: new[] { "Id", "Title", "Text", "IsFake", "AuthorId" },
                    values: new object[] { 1, "Increase your lifespan by 10 years, every morning you need...", "", true, 3 }); ;

            migrationBuilder.InsertData(
                    table: "News",
                    columns: new[] { "Id", "Title", "Text", "IsFake", "AuthorId" },
                    values: new object[] { 2, "Scientists estimed the time of the vaccine invension: it is a summer of 2021", "", false, 9 });

            migrationBuilder.InsertData(
                    table: "News",
                    columns: new[] { "Id", "Title", "Text", "IsFake", "AuthorId" },
                    values: new object[] { 3, "Ukraine reduces the cost of its obligations!", "", false, 11 });

            migrationBuilder.InsertData(
                    table: "News",
                    columns: new[] { "Id", "Title", "Text", "IsFake", "AuthorId" },
                    values: new object[] { 4, "A species were discovered in Africa: it is blue legless cat", "", true, 10 });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
