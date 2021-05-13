using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Translator.EntityFramework.Migrations
{
    public partial class fix_log_message_table2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54696300-44ae-4824-b69b-06ac8b7ab85a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "970595e3-9487-4ffc-a964-65a219f5a5d4");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "LogMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "LogMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4ff44b6-8b13-4342-8db9-8f39c0ff0c40", "2d5a32c2-6819-43ce-a6f9-9311b537aade", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4720b5a-29b4-4532-a632-c87783b89a92", "a218712f-e5da-493b-a09b-372a693872ef", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4ff44b6-8b13-4342-8db9-8f39c0ff0c40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4720b5a-29b4-4532-a632-c87783b89a92");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "LogMessages");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "LogMessages");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54696300-44ae-4824-b69b-06ac8b7ab85a", "d019e94a-0cb9-47b0-bd0f-da176edffc55", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "970595e3-9487-4ffc-a964-65a219f5a5d4", "273bbb91-a6c0-4da8-993a-9ec88bd58394", "Administrator", "ADMINISTRATOR" });
        }
    }
}
