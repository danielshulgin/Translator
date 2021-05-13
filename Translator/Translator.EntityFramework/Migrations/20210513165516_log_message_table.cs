using Microsoft.EntityFrameworkCore.Migrations;

namespace Translator.EntityFramework.Migrations
{
    public partial class log_message_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a753750e-f351-4704-b33f-d061f17047b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b02e4d43-ac69-4924-af82-46ccd6f70e0b");

            migrationBuilder.CreateTable(
                name: "LogMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogMessages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19bdf353-cae2-4ef4-af8c-672f3d33c00b", "04d274c2-6fb3-4048-9ebd-32887524ac85", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd5da5c4-ba25-4021-b413-1d88541a2006", "1e4603c4-4b2f-4529-b360-91868204f426", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogMessages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19bdf353-cae2-4ef4-af8c-672f3d33c00b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd5da5c4-ba25-4021-b413-1d88541a2006");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b02e4d43-ac69-4924-af82-46ccd6f70e0b", "9aeac30e-8663-4fe0-9d45-9a2577c4f338", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a753750e-f351-4704-b33f-d061f17047b0", "a221f02d-401b-4395-abfe-8dfd5b2dd94f", "Administrator", "ADMINISTRATOR" });
        }
    }
}
