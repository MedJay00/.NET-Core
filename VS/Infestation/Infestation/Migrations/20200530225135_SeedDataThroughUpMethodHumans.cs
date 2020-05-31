using Microsoft.EntityFrameworkCore.Migrations;

namespace Infestation.Migrations
{
    public partial class SeedDataThroughUpMethodHumans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                values: new object[] { 9, "Arnold", "Schwarzenegger", 72, true, "Male", 1 });
            migrationBuilder.InsertData(
               table: "Humans",
               columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
               values: new object[] { 10, "Will", "Smith", 51, true, "Male", 2 });
            migrationBuilder.InsertData(
               table: "Humans",
               columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
               values: new object[] { 11, "Steven", "Rogers", 33, true, "Male", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

        }
    }
}
