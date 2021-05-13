using Microsoft.EntityFrameworkCore.Migrations;

namespace Translator.EntityFramework.Migrations
{
    public partial class fix_log_message_table6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "0bd626bc-6a68-4270-8de1-d3c9d9b6187d", "43725020-b398-4ddd-aeb2-b750a7150961", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c95e285e-221e-4365-9eeb-d05af0ec961a", "1a569e0f-3fda-4692-bbc7-8f304b966163", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bd626bc-6a68-4270-8de1-d3c9d9b6187d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c95e285e-221e-4365-9eeb-d05af0ec961a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "226dd9a7-bc59-43ca-bd37-7e6a09d5633d", "cdb121cf-7112-4b8f-a6a9-9d9abd966b2f", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "176d2989-2a45-4c99-868b-438e9a052b5b", "be29fa8a-7c3a-4801-8f29-43cec27f9195", "Administrator", "ADMINISTRATOR" });
        }
    }
}
