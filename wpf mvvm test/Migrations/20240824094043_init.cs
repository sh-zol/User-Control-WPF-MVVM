using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace wpf_mvvm_test.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    TokenValue = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "TokenValue" },
                values: new object[] { 1, "testemail@gmail.com", "test", "12345", "d6ce67f2-0915-4298-bce8-aa00d8472a59" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "TokenValue" },
                values: new object[] { 2, "test2email@gmail.com", "test2", "12345", "12152273-dc8e-4cb2-a2d1-6599b91b976f" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "TokenValue" },
                values: new object[] { 3, "test3email@gmail.com", "test3", "12345", "cfdb36d4-de14-42c9-8ca1-1f3f2ef78845" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
