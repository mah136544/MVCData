using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCData.Migrations
{
    public partial class addTablecity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MLinks",
                keyColumn: "Name",
                keyValue: "AJAX",
                column: "Title",
                value: "AJAX");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MLinks",
                keyColumn: "Name",
                keyValue: "AJAX",
                column: "Title",
                value: "AJAX Mode");
        }
    }
}
