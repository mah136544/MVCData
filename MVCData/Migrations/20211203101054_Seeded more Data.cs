using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCData.Migrations
{
    public partial class SeededmoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "City", "Name", "PhoneNumber" },
                values: new object[] { 5, "Karlstad", "Eva", "0778090127" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "City", "Name", "PhoneNumber" },
                values: new object[] { 6, "Ystad", "Adam", "0788090128" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 6);
        }
    }
}
