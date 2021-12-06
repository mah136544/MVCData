using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCData.Migrations
{
    public partial class ChangeNameiMLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MLinks",
                keyColumn: "Name",
                keyValue: "AJAX",
                column: "LinkURL",
                value: "/Ajax/Index");

            migrationBuilder.InsertData(
                table: "MLinks",
                columns: new[] { "Name", "LinkURL", "Title" },
                values: new object[] { "AjAX", "/Ajax/", "AjAX" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MLinks",
                keyColumn: "Name",
                keyValue: "AjAX");

            migrationBuilder.UpdateData(
                table: "MLinks",
                keyColumn: "Name",
                keyValue: "AJAX",
                column: "LinkURL",
                value: "/Ajax/");
        }
    }
}
