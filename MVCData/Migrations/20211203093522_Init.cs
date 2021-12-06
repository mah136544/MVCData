using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCData.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MLinks",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Title = table.Column<string>(maxLength: 20, nullable: false),
                    LinkURL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MLinks", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "MLinks",
                columns: new[] { "Name", "LinkURL", "Title" },
                values: new object[] { "AJAX", "/Ajax/Index", "AJAX" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "City", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Göteborg", "Mahnoush", "0738090123" },
                    { 2, "Stockholm", "Donja", "0748090124" },
                    { 3, "Ystad", "Awa", "0758090125" },
                    { 4, "Malmö", "Diana", "0768090126" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MLinks");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
