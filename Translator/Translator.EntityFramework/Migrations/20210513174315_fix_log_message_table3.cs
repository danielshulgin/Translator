using Microsoft.EntityFrameworkCore.Migrations;

namespace Translator.EntityFramework.Migrations
{
    public partial class fix_log_message_table3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4ff44b6-8b13-4342-8db9-8f39c0ff0c40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4720b5a-29b4-4532-a632-c87783b89a92");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d0d2b94-fa52-4f0b-ab25-743762bfba08", "38f08675-4679-40cc-8c25-12c5e804127b", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "065c108c-12d9-48ca-96cc-738b455c9a15", "5ff3cd21-b750-4038-819d-34b118de7d3f", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "065c108c-12d9-48ca-96cc-738b455c9a15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d0d2b94-fa52-4f0b-ab25-743762bfba08");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4ff44b6-8b13-4342-8db9-8f39c0ff0c40", "2d5a32c2-6819-43ce-a6f9-9311b537aade", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4720b5a-29b4-4532-a632-c87783b89a92", "a218712f-e5da-493b-a09b-372a693872ef", "Administrator", "ADMINISTRATOR" });
        }
    }
}
