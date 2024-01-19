using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumManagmentSystem.Infrastructure.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "DeletedOn", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("04b58ca9-5a97-45d5-ba89-17600af91ceb"), null, false, "Asia" },
                    { new Guid("1e4da066-7d20-4f76-be37-1b0f3754a9d1"), null, false, "South America" },
                    { new Guid("2c12083b-b69b-4d0f-a181-0469e915a2a2"), null, false, "Bulgaria" },
                    { new Guid("48a0c91a-7224-47a0-a9b4-0982413cc6ef"), null, false, "charity" },
                    { new Guid("6d2a98bd-6f14-4415-9cf1-51ece05c5d0d"), null, false, "Australia" },
                    { new Guid("6dca0270-56f0-4cde-9e44-9b5f0a94abe5"), null, false, "economy" },
                    { new Guid("9088ef78-e55f-4476-b91b-8c93bfbcf92f"), null, false, "Europe" },
                    { new Guid("9864ada2-3acf-493b-bb25-25a8b684b9a9"), null, false, "Varna" },
                    { new Guid("98ac7668-59a5-4f8f-8c49-5641f8bf1781"), null, false, "investment" },
                    { new Guid("9fb0f687-c6ff-4ccc-b712-5b28ee566ab5"), null, false, "Africa" },
                    { new Guid("ab05d812-3753-4025-9ddd-46ca0bd92aa5"), null, false, "science" },
                    { new Guid("bb86bd18-e65d-44b1-adb5-bd07c686070a"), null, false, "funny" },
                    { new Guid("c1863b7b-10c7-4cb3-b93c-7655ea299aac"), null, false, "Plovdiv" },
                    { new Guid("d63cf14e-e897-499a-85fd-9bacef405f82"), null, false, "event" },
                    { new Guid("d92347d5-e8f5-4dc2-838b-d86a74769564"), null, false, "Sofiq" },
                    { new Guid("e4aa0e54-fa05-4757-a084-df0a989c5fa5"), null, false, "Burgas" },
                    { new Guid("f6188a63-2a5c-4e78-b733-7d4716f84a41"), null, false, "North America" },
                    { new Guid("fa187072-6a28-4606-b096-9fbafd8029c7"), null, false, "tournament" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Email", "FirstName", "IsAdmin", "IsBlocked", "IsDeleted", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { new Guid("3522894c-0f15-4f9e-b379-ab644f4e918e"), new DateTime(2024, 1, 19, 11, 49, 7, 587, DateTimeKind.Local).AddTicks(8749), null, "tes2@mail.com", "test2A", false, false, false, "test2B", new byte[] { 165, 196, 217, 130, 173, 225, 82, 58, 64, 96, 126, 243, 81, 198, 152, 7, 239, 105, 101, 244, 37, 212, 243, 220, 45, 85, 136, 31, 149, 218, 147, 156, 131, 200, 141, 191, 78, 163, 10, 102, 213, 167, 132, 32, 206, 143, 91, 103, 230, 176, 97, 52, 252, 232, 236, 1, 65, 228, 140, 96, 110, 48, 245, 29 }, new byte[] { 46, 78, 60, 63, 212, 204, 100, 222, 52, 81, 27, 53, 207, 179, 178, 138, 219, 242, 62, 101, 24, 50, 134, 14, 117, 221, 2, 114, 111, 25, 175, 186, 206, 226, 115, 203, 226, 10, 53, 14, 241, 202, 163, 43, 96, 133, 235, 93, 215, 212, 143, 247, 105, 99, 1, 145, 96, 198, 180, 196, 126, 64, 8, 4, 150, 174, 191, 71, 205, 138, 116, 193, 165, 49, 105, 68, 111, 39, 88, 245, 170, 2, 150, 45, 73, 138, 28, 66, 16, 164, 138, 11, 221, 108, 165, 25, 80, 155, 194, 139, 119, 215, 151, 108, 156, 129, 22, 73, 208, 61, 109, 153, 123, 38, 127, 84, 221, 42, 210, 93, 103, 20, 45, 251, 219, 80, 90, 12 }, null, "test2" },
                    { new Guid("b87b9540-c07f-4ce6-905d-41e2f33a6a95"), new DateTime(2024, 1, 19, 11, 49, 7, 587, DateTimeKind.Local).AddTicks(8752), null, "admin@mail.com", "admin1A", true, false, false, "admin1B", new byte[] { 100, 174, 69, 49, 244, 40, 75, 242, 75, 190, 7, 50, 191, 21, 210, 51, 175, 89, 167, 216, 73, 209, 117, 127, 139, 6, 180, 213, 120, 123, 133, 100, 188, 7, 2, 113, 119, 171, 30, 108, 70, 31, 89, 21, 19, 74, 54, 168, 215, 248, 61, 25, 88, 232, 12, 142, 33, 133, 48, 181, 98, 99, 28, 12 }, new byte[] { 43, 56, 56, 111, 186, 118, 3, 172, 167, 56, 181, 194, 18, 120, 38, 44, 137, 72, 218, 163, 59, 187, 112, 33, 97, 84, 98, 154, 97, 235, 245, 32, 84, 45, 125, 196, 21, 83, 244, 137, 213, 139, 121, 57, 94, 1, 246, 221, 12, 23, 215, 214, 55, 71, 95, 63, 80, 125, 227, 215, 222, 181, 230, 236, 115, 100, 176, 93, 123, 253, 250, 164, 139, 9, 44, 103, 183, 94, 206, 158, 143, 89, 195, 79, 216, 67, 113, 158, 40, 113, 128, 113, 134, 82, 255, 141, 63, 144, 198, 189, 93, 213, 143, 48, 75, 0, 205, 196, 250, 159, 165, 251, 43, 148, 33, 154, 107, 114, 204, 180, 14, 17, 75, 195, 74, 155, 208, 6 }, null, "admin" },
                    { new Guid("e806ad30-83cb-4bbe-a350-ae52c1f9bf73"), new DateTime(2024, 1, 19, 11, 49, 7, 587, DateTimeKind.Local).AddTicks(8716), null, "test1@mail.com", "test1A", false, false, false, "test1B", new byte[] { 176, 106, 231, 100, 108, 29, 115, 161, 14, 148, 23, 30, 182, 158, 247, 123, 201, 10, 65, 203, 194, 13, 241, 178, 112, 17, 20, 234, 84, 22, 78, 173, 189, 179, 19, 170, 218, 107, 94, 188, 99, 222, 178, 144, 2, 42, 112, 59, 65, 153, 167, 161, 78, 38, 210, 238, 154, 190, 85, 226, 161, 100, 131, 44 }, new byte[] { 150, 226, 213, 246, 103, 226, 64, 200, 233, 86, 209, 89, 127, 33, 123, 161, 86, 253, 227, 236, 3, 195, 5, 152, 141, 197, 135, 78, 163, 232, 142, 18, 176, 185, 243, 46, 84, 25, 48, 214, 189, 77, 151, 95, 147, 42, 252, 161, 140, 194, 214, 25, 230, 195, 31, 64, 118, 183, 152, 35, 184, 220, 74, 149, 152, 189, 63, 46, 242, 6, 17, 6, 64, 131, 216, 114, 72, 190, 152, 177, 86, 252, 181, 188, 124, 222, 122, 42, 246, 207, 55, 245, 55, 3, 73, 124, 232, 200, 251, 167, 80, 86, 27, 153, 181, 58, 182, 90, 169, 111, 211, 212, 61, 62, 107, 5, 180, 87, 46, 178, 247, 9, 31, 78, 200, 19, 177, 87 }, null, "test1" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedOn", "DeletedOn", "IsDeleted", "LikesCount", "Title" },
                values: new object[] { new Guid("044e86a6-fc9f-4677-98a5-bbfe475c9366"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras suscipit justo vitae quam gravida feugiat.", new Guid("e806ad30-83cb-4bbe-a350-ae52c1f9bf73"), new DateTime(2024, 1, 19, 11, 49, 7, 587, DateTimeKind.Local).AddTicks(8782), null, false, 2, "Lorem ipsum dolor sit amet." });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedOn", "DeletedOn", "IsDeleted", "LikesCount", "Title" },
                values: new object[] { new Guid("1f3d1fbd-7fda-4970-b87f-3c2f921e973a"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque et sollicitudin purus, in commodo lectus. Suspendisse nibh est, facilisis eget.", new Guid("b87b9540-c07f-4ce6-905d-41e2f33a6a95"), new DateTime(2024, 1, 19, 11, 49, 7, 587, DateTimeKind.Local).AddTicks(8790), null, false, 0, "Vestibulum vitae est sed diam." });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedOn", "DeletedOn", "IsDeleted", "LikesCount", "Title" },
                values: new object[] { new Guid("e3010802-149f-4457-bd0d-e9db557836cc"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus vitae tortor vitae orci posuere bibendum. Morbi ornare a felis in.", new Guid("3522894c-0f15-4f9e-b379-ab644f4e918e"), new DateTime(2024, 1, 19, 11, 49, 7, 587, DateTimeKind.Local).AddTicks(8787), null, false, 1, "Lorem ipsum dolor sit amet, consectetur." });

            migrationBuilder.InsertData(
                table: "PostLikes",
                columns: new[] { "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("044e86a6-fc9f-4677-98a5-bbfe475c9366"), new Guid("3522894c-0f15-4f9e-b379-ab644f4e918e") },
                    { new Guid("044e86a6-fc9f-4677-98a5-bbfe475c9366"), new Guid("e806ad30-83cb-4bbe-a350-ae52c1f9bf73") },
                    { new Guid("e3010802-149f-4457-bd0d-e9db557836cc"), new Guid("3522894c-0f15-4f9e-b379-ab644f4e918e") }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { new Guid("044e86a6-fc9f-4677-98a5-bbfe475c9366"), new Guid("48a0c91a-7224-47a0-a9b4-0982413cc6ef") },
                    { new Guid("044e86a6-fc9f-4677-98a5-bbfe475c9366"), new Guid("bb86bd18-e65d-44b1-adb5-bd07c686070a") },
                    { new Guid("e3010802-149f-4457-bd0d-e9db557836cc"), new Guid("bb86bd18-e65d-44b1-adb5-bd07c686070a") }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedOn", "DeletedOn", "IsDeleted", "LikesCount", "PostId" },
                values: new object[,]
                {
                    { new Guid("36bf0e5f-d891-4ce5-9a75-83ae737ddc58"), "Nam ipsum est, vulputate non leo sed, gravida gravida est. Vivamus pharetra porta dolor, ac pharetra dolor lacinia quis. Donec ut vestibulum mauris. Praesent ornare a lorem vel ultrices. Pellentesque.", new Guid("e806ad30-83cb-4bbe-a350-ae52c1f9bf73"), new DateTime(2024, 1, 19, 11, 49, 7, 587, DateTimeKind.Local).AddTicks(8840), null, false, 0, new Guid("e3010802-149f-4457-bd0d-e9db557836cc") },
                    { new Guid("370a8faa-e834-43d6-9a34-a78be008d768"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur sit.", new Guid("e806ad30-83cb-4bbe-a350-ae52c1f9bf73"), new DateTime(2024, 1, 19, 11, 49, 7, 587, DateTimeKind.Local).AddTicks(8827), null, false, 2, new Guid("044e86a6-fc9f-4677-98a5-bbfe475c9366") },
                    { new Guid("81560736-d320-40d6-98e0-2223268c36c6"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean mattis turpis quis urna congue, finibus dignissim dolor vestibulum. Nullam aliquet.", new Guid("3522894c-0f15-4f9e-b379-ab644f4e918e"), new DateTime(2024, 1, 19, 11, 49, 7, 587, DateTimeKind.Local).AddTicks(8837), null, false, 1, new Guid("e3010802-149f-4457-bd0d-e9db557836cc") }
                });

            migrationBuilder.InsertData(
                table: "ReplyLikes",
                columns: new[] { "ReplyId", "UserId" },
                values: new object[] { new Guid("370a8faa-e834-43d6-9a34-a78be008d768"), new Guid("3522894c-0f15-4f9e-b379-ab644f4e918e") });

            migrationBuilder.InsertData(
                table: "ReplyLikes",
                columns: new[] { "ReplyId", "UserId" },
                values: new object[] { new Guid("370a8faa-e834-43d6-9a34-a78be008d768"), new Guid("e806ad30-83cb-4bbe-a350-ae52c1f9bf73") });

            migrationBuilder.InsertData(
                table: "ReplyLikes",
                columns: new[] { "ReplyId", "UserId" },
                values: new object[] { new Guid("81560736-d320-40d6-98e0-2223268c36c6"), new Guid("3522894c-0f15-4f9e-b379-ab644f4e918e") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostLikes",
                keyColumns: new[] { "PostId", "UserId" },
                keyValues: new object[] { new Guid("044e86a6-fc9f-4677-98a5-bbfe475c9366"), new Guid("3522894c-0f15-4f9e-b379-ab644f4e918e") });

            migrationBuilder.DeleteData(
                table: "PostLikes",
                keyColumns: new[] { "PostId", "UserId" },
                keyValues: new object[] { new Guid("044e86a6-fc9f-4677-98a5-bbfe475c9366"), new Guid("e806ad30-83cb-4bbe-a350-ae52c1f9bf73") });

            migrationBuilder.DeleteData(
                table: "PostLikes",
                keyColumns: new[] { "PostId", "UserId" },
                keyValues: new object[] { new Guid("e3010802-149f-4457-bd0d-e9db557836cc"), new Guid("3522894c-0f15-4f9e-b379-ab644f4e918e") });

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { new Guid("044e86a6-fc9f-4677-98a5-bbfe475c9366"), new Guid("48a0c91a-7224-47a0-a9b4-0982413cc6ef") });

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { new Guid("044e86a6-fc9f-4677-98a5-bbfe475c9366"), new Guid("bb86bd18-e65d-44b1-adb5-bd07c686070a") });

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { new Guid("e3010802-149f-4457-bd0d-e9db557836cc"), new Guid("bb86bd18-e65d-44b1-adb5-bd07c686070a") });

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("1f3d1fbd-7fda-4970-b87f-3c2f921e973a"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: new Guid("36bf0e5f-d891-4ce5-9a75-83ae737ddc58"));

            migrationBuilder.DeleteData(
                table: "ReplyLikes",
                keyColumns: new[] { "ReplyId", "UserId" },
                keyValues: new object[] { new Guid("370a8faa-e834-43d6-9a34-a78be008d768"), new Guid("3522894c-0f15-4f9e-b379-ab644f4e918e") });

            migrationBuilder.DeleteData(
                table: "ReplyLikes",
                keyColumns: new[] { "ReplyId", "UserId" },
                keyValues: new object[] { new Guid("370a8faa-e834-43d6-9a34-a78be008d768"), new Guid("e806ad30-83cb-4bbe-a350-ae52c1f9bf73") });

            migrationBuilder.DeleteData(
                table: "ReplyLikes",
                keyColumns: new[] { "ReplyId", "UserId" },
                keyValues: new object[] { new Guid("81560736-d320-40d6-98e0-2223268c36c6"), new Guid("3522894c-0f15-4f9e-b379-ab644f4e918e") });

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("04b58ca9-5a97-45d5-ba89-17600af91ceb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1e4da066-7d20-4f76-be37-1b0f3754a9d1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2c12083b-b69b-4d0f-a181-0469e915a2a2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6d2a98bd-6f14-4415-9cf1-51ece05c5d0d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6dca0270-56f0-4cde-9e44-9b5f0a94abe5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9088ef78-e55f-4476-b91b-8c93bfbcf92f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9864ada2-3acf-493b-bb25-25a8b684b9a9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("98ac7668-59a5-4f8f-8c49-5641f8bf1781"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9fb0f687-c6ff-4ccc-b712-5b28ee566ab5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ab05d812-3753-4025-9ddd-46ca0bd92aa5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c1863b7b-10c7-4cb3-b93c-7655ea299aac"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d63cf14e-e897-499a-85fd-9bacef405f82"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d92347d5-e8f5-4dc2-838b-d86a74769564"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e4aa0e54-fa05-4757-a084-df0a989c5fa5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f6188a63-2a5c-4e78-b733-7d4716f84a41"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fa187072-6a28-4606-b096-9fbafd8029c7"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: new Guid("370a8faa-e834-43d6-9a34-a78be008d768"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: new Guid("81560736-d320-40d6-98e0-2223268c36c6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("48a0c91a-7224-47a0-a9b4-0982413cc6ef"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bb86bd18-e65d-44b1-adb5-bd07c686070a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b87b9540-c07f-4ce6-905d-41e2f33a6a95"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("044e86a6-fc9f-4677-98a5-bbfe475c9366"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("e3010802-149f-4457-bd0d-e9db557836cc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3522894c-0f15-4f9e-b379-ab644f4e918e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e806ad30-83cb-4bbe-a350-ae52c1f9bf73"));
        }
    }
}
