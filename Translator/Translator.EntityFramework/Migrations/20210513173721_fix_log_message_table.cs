using Microsoft.EntityFrameworkCore.Migrations;

namespace Translator.EntityFramework.Migrations
{
    public partial class fix_log_message_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "54696300-44ae-4824-b69b-06ac8b7ab85a", "d019e94a-0cb9-47b0-bd0f-da176edffc55", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "970595e3-9487-4ffc-a964-65a219f5a5d4", "273bbb91-a6c0-4da8-993a-9ec88bd58394", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54696300-44ae-4824-b69b-06ac8b7ab85a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "970595e3-9487-4ffc-a964-65a219f5a5d4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19bdf353-cae2-4ef4-af8c-672f3d33c00b", "04d274c2-6fb3-4048-9ebd-32887524ac85", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd5da5c4-ba25-4021-b413-1d88541a2006", "1e4603c4-4b2f-4529-b360-91868204f426", "Administrator", "ADMINISTRATOR" });
        }
    }
}
