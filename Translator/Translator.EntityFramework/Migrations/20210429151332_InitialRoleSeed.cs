using Microsoft.EntityFrameworkCore.Migrations;

namespace Translator.EntityFramework.Migrations
{
    public partial class InitialRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e6ad6f3-277b-42ef-a355-e48bd1d9f00b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0542ec3-d941-4216-accc-2f32c5d86739");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e41ba9c-21ae-4714-895e-87ad5de42768", "881da919-2179-48d6-b2d2-e052a91a4041", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "952b9f7c-e919-455b-a4a6-354d24f9ca9b", "0a169212-6090-44d0-8ea2-aff2e9b6ce32", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e41ba9c-21ae-4714-895e-87ad5de42768");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "952b9f7c-e919-455b-a4a6-354d24f9ca9b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0542ec3-d941-4216-accc-2f32c5d86739", "fe5f6b23-4871-493d-a6b8-f361b9b5dc90", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e6ad6f3-277b-42ef-a355-e48bd1d9f00b", "6137b9a3-322d-428b-bdb5-f9a03892c791", "Administrator", "ADMINISTRATOR" });
        }
    }
}
