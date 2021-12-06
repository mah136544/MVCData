using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCData.Migrations
{
    public partial class SeededAjax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MLinks",
                keyColumn: "Name",
                keyValue: "AJAX",
                column: "LinkURL",
                value: "/Ajax/");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MLinks",
                keyColumn: "Name",
                keyValue: "AJAX",
                column: "LinkURL",
                value: "/Ajax/Index");
        }
    }
}
