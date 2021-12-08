using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCData.Migrations
{
    public partial class AddedTableCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MLinks",
                keyColumn: "Name",
                keyValue: "AjAX");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "City",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "People",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    CountryCode = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryCode", "Name" },
                values: new object[] { 1, "IR", "Iran" });

            migrationBuilder.UpdateData(
                table: "MLinks",
                keyColumn: "Name",
                keyValue: "AJAX",
                columns: new[] { "LinkURL", "Title" },
                values: new object[] { "/AJAX/", "AJAX Mode" });

            migrationBuilder.InsertData(
                table: "MLinks",
                columns: new[] { "Name", "LinkURL", "Title" },
                values: new object[,]
                {
                    { "Cities", "/Cities/", "Cities" },
                    { "Countries", "/Countries/", "Countries" },
                    { "People", "/Home/", "People" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Tehran" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 2, 1, "Shiraz" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 3, 1, "Mashhad" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: 1,
                column: "CityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: 2,
                column: "CityId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: 3,
                column: "CityId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_People_CityId",
                table: "People",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_People_CityId",
                table: "People");

            migrationBuilder.DeleteData(
                table: "MLinks",
                keyColumn: "Name",
                keyValue: "Cities");

            migrationBuilder.DeleteData(
                table: "MLinks",
                keyColumn: "Name",
                keyValue: "Countries");

            migrationBuilder.DeleteData(
                table: "MLinks",
                keyColumn: "Name",
                keyValue: "People");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MLinks",
                keyColumn: "Name",
                keyValue: "AJAX",
                columns: new[] { "LinkURL", "Title" },
                values: new object[] { "/Ajax/Index", "AJAX" });

            migrationBuilder.InsertData(
                table: "MLinks",
                columns: new[] { "Name", "LinkURL", "Title" },
                values: new object[] { "AjAX", "/Ajax/", "AjAX" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: 1,
                column: "City",
                value: "Göteborg");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: 2,
                column: "City",
                value: "Stockholm");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: 3,
                column: "City",
                value: "Ystad");

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "City", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 4, "Malmö", "Diana", "0768090126" },
                    { 5, "Karlstad", "Eva", "0778090127" },
                    { 6, "Ystad", "Adam", "0788090128" }
                });
        }
    }
}
