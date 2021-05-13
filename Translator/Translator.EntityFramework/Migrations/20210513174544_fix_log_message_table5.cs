using Microsoft.EntityFrameworkCore.Migrations;

namespace Translator.EntityFramework.Migrations
{
    public partial class fix_log_message_table5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "226dd9a7-bc59-43ca-bd37-7e6a09d5633d", "cdb121cf-7112-4b8f-a6a9-9d9abd966b2f", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "176d2989-2a45-4c99-868b-438e9a052b5b", "be29fa8a-7c3a-4801-8f29-43cec27f9195", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "176d2989-2a45-4c99-868b-438e9a052b5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "226dd9a7-bc59-43ca-bd37-7e6a09d5633d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d0d2b94-fa52-4f0b-ab25-743762bfba08", "38f08675-4679-40cc-8c25-12c5e804127b", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "065c108c-12d9-48ca-96cc-738b455c9a15", "5ff3cd21-b750-4038-819d-34b118de7d3f", "Administrator", "ADMINISTRATOR" });
        }
    }
}
