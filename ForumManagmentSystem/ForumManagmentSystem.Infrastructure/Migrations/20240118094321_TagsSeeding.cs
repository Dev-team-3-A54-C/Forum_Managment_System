using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumManagmentSystem.Infrastructure.Migrations
{
    public partial class TagsSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Users_CreatedBy",
                table: "Replies");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "DeletedOn", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("0a02dfc6-0df5-4603-896c-28a72fc83d8d"), null, false, "South America" },
                    { new Guid("0ef06111-3294-4bd2-bf9a-1c7eba2c4e89"), null, false, "Bulgaria" },
                    { new Guid("1b4418e8-8670-4bba-b21a-0f7c840ec869"), null, false, "Europe" },
                    { new Guid("264596ae-0cee-497e-ad53-f2c79edff147"), null, false, "Australia" },
                    { new Guid("35fa1269-4cde-4b32-bec5-f16aacfe7f07"), null, false, "science" },
                    { new Guid("3bb0450c-97ca-4160-b184-26f8267f4e3e"), null, false, "Asia" },
                    { new Guid("55f948a1-6462-44fb-ac09-3041b04e4190"), null, false, "economy" },
                    { new Guid("59cf6f09-a87b-4724-b6f9-0b1c10e57257"), null, false, "Africa" },
                    { new Guid("6e204671-fd9b-4aff-9dc7-436541f29ddf"), null, false, "investment" },
                    { new Guid("7a99a9c4-f215-4b26-9f98-c43f0242a801"), null, false, "Varna" },
                    { new Guid("7f23da9b-aae3-4ee2-988f-1a7372aa4a14"), null, false, "charity" },
                    { new Guid("979d02a1-8173-448c-8f73-81b80e925de0"), null, false, "Burgas" },
                    { new Guid("986d165f-a9c5-4abf-830b-fde784f545b9"), null, false, "funny" },
                    { new Guid("a70902a5-61d8-4fa8-b328-37ba83cf3ca9"), null, false, "Plovdiv" },
                    { new Guid("abdd7631-267f-49fe-8a82-31dbebeb9c5c"), null, false, "event" },
                    { new Guid("c1bfffb1-c805-415b-8475-066f441612b6"), null, false, "Sofiq" },
                    { new Guid("ebd7ac77-4a23-464e-a267-d34a1dafc64b"), null, false, "tournament" },
                    { new Guid("eea20146-e6cf-4113-ab48-78b6261c0d2b"), null, false, "North America" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Users_CreatedBy",
                table: "Replies",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Users_CreatedBy",
                table: "Replies");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0a02dfc6-0df5-4603-896c-28a72fc83d8d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0ef06111-3294-4bd2-bf9a-1c7eba2c4e89"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1b4418e8-8670-4bba-b21a-0f7c840ec869"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("264596ae-0cee-497e-ad53-f2c79edff147"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("35fa1269-4cde-4b32-bec5-f16aacfe7f07"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3bb0450c-97ca-4160-b184-26f8267f4e3e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("55f948a1-6462-44fb-ac09-3041b04e4190"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("59cf6f09-a87b-4724-b6f9-0b1c10e57257"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6e204671-fd9b-4aff-9dc7-436541f29ddf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7a99a9c4-f215-4b26-9f98-c43f0242a801"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7f23da9b-aae3-4ee2-988f-1a7372aa4a14"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("979d02a1-8173-448c-8f73-81b80e925de0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("986d165f-a9c5-4abf-830b-fde784f545b9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a70902a5-61d8-4fa8-b328-37ba83cf3ca9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("abdd7631-267f-49fe-8a82-31dbebeb9c5c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c1bfffb1-c805-415b-8475-066f441612b6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ebd7ac77-4a23-464e-a267-d34a1dafc64b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("eea20146-e6cf-4113-ab48-78b6261c0d2b"));

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Users_CreatedBy",
                table: "Replies",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
