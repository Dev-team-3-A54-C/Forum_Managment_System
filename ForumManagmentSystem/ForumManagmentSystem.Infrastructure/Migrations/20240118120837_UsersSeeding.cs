using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumManagmentSystem.Infrastructure.Migrations
{
    public partial class UsersSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("04aebc32-da35-4b56-85c8-baa8179f34f3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0f4889fa-e377-4382-996a-dab173b863e0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1199699a-8dd5-4ade-af8a-2fd05cdd0786"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("41e18d36-e2e4-4155-85fe-8771ce68989e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("449eb51c-2c2c-4141-b25c-64301de61977"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5a1a9098-b13b-45af-bf0b-24a8271200ab"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5a2eccbb-c50a-4296-b970-348435a65f74"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("68c133da-ce93-4f28-ba99-67ad71ac5cdb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6c18e00d-6fbb-4a54-93f5-4e7e5b0ec94c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("70a8ff7c-b51c-41d7-a095-2beb23f16ff4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8269a7a2-8a2a-40f7-9ee3-d944de01dd0d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8c0a4108-2a2e-4a8c-b989-a467783bff1a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a5401430-a2ac-45e0-aa2f-0603917fad34"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b1d052b0-4559-489a-9b1f-356e554b9b27"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b768e6c9-3477-491b-ac64-06069a64432b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c8824a3a-8f0e-441f-9527-1ad69b828875"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f9d4542d-de81-468e-9fc0-364646a30b97"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("febe504f-7075-428c-83b5-4803a67c09ab"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("63e1353d-2f60-41f4-b347-94d85dab299a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d9ab9d2-8896-4459-a532-949ceb5dad0b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b98fda67-5984-4e7d-916d-7fcb906cd2b1"));

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "DeletedOn", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("15c2084c-0066-4066-88c1-6a04cb5f3fdb"), null, false, "Plovdiv" },
                    { new Guid("27083416-5d6f-424c-bdc8-28d403db5319"), null, false, "Bulgaria" },
                    { new Guid("3821394b-e2d1-4c76-9794-5b1ced0167ac"), null, false, "event" },
                    { new Guid("47ccafb1-ad6f-4ee8-b887-70b750f8b5c3"), null, false, "Asia" },
                    { new Guid("5c291373-f99c-46dc-ad5b-cf65dab10e4a"), null, false, "science" },
                    { new Guid("633b87a9-07de-4b61-a299-26772df39620"), null, false, "Sofiq" },
                    { new Guid("70821498-d479-4abd-85d0-272aaca771a1"), null, false, "Europe" },
                    { new Guid("985e2478-e0f8-4c19-9584-36582a768c88"), null, false, "Australia" },
                    { new Guid("a96d1c49-c671-4eda-9631-bf7391bb7a77"), null, false, "South America" },
                    { new Guid("aa809d98-011f-4a99-bc16-f3ed28a11087"), null, false, "funny" },
                    { new Guid("c2a2243e-41e6-4709-be4b-0b13bc90304f"), null, false, "economy" },
                    { new Guid("ca7db341-5a3d-4ae0-9267-badfbf38fdc8"), null, false, "Africa" },
                    { new Guid("d06b7c90-3f47-4863-8fbd-0dccdff99a82"), null, false, "investment" },
                    { new Guid("d2cf4e8f-d6e5-4896-bb28-f085c19cd2fb"), null, false, "charity" },
                    { new Guid("e01a3224-4aa9-4078-9d10-d1f766012533"), null, false, "North America" },
                    { new Guid("f1515d9b-447a-4272-ab46-8b60e98635dc"), null, false, "tournament" },
                    { new Guid("f65fd854-b94e-4a33-908a-1a16047810bb"), null, false, "Varna" },
                    { new Guid("fb71c371-18a4-4282-b830-4822ba3a423f"), null, false, "Burgas" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Email", "FirstName", "IsAdmin", "IsBlocked", "IsDeleted", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { new Guid("3522894c-0f15-4f9e-b379-ab644f4e918e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "tes2@mail.com", "test2A", false, false, false, "test2B", new byte[] { 165, 196, 217, 130, 173, 225, 82, 58, 64, 96, 126, 243, 81, 198, 152, 7, 239, 105, 101, 244, 37, 212, 243, 220, 45, 85, 136, 31, 149, 218, 147, 156, 131, 200, 141, 191, 78, 163, 10, 102, 213, 167, 132, 32, 206, 143, 91, 103, 230, 176, 97, 52, 252, 232, 236, 1, 65, 228, 140, 96, 110, 48, 245, 29 }, new byte[] { 46, 78, 60, 63, 212, 204, 100, 222, 52, 81, 27, 53, 207, 179, 178, 138, 219, 242, 62, 101, 24, 50, 134, 14, 117, 221, 2, 114, 111, 25, 175, 186, 206, 226, 115, 203, 226, 10, 53, 14, 241, 202, 163, 43, 96, 133, 235, 93, 215, 212, 143, 247, 105, 99, 1, 145, 96, 198, 180, 196, 126, 64, 8, 4, 150, 174, 191, 71, 205, 138, 116, 193, 165, 49, 105, 68, 111, 39, 88, 245, 170, 2, 150, 45, 73, 138, 28, 66, 16, 164, 138, 11, 221, 108, 165, 25, 80, 155, 194, 139, 119, 215, 151, 108, 156, 129, 22, 73, 208, 61, 109, 153, 123, 38, 127, 84, 221, 42, 210, 93, 103, 20, 45, 251, 219, 80, 90, 12 }, null, "test2" },
                    { new Guid("b87b9540-c07f-4ce6-905d-41e2f33a6a95"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@mail.com", "admin1A", true, false, false, "admin1B", new byte[] { 100, 174, 69, 49, 244, 40, 75, 242, 75, 190, 7, 50, 191, 21, 210, 51, 175, 89, 167, 216, 73, 209, 117, 127, 139, 6, 180, 213, 120, 123, 133, 100, 188, 7, 2, 113, 119, 171, 30, 108, 70, 31, 89, 21, 19, 74, 54, 168, 215, 248, 61, 25, 88, 232, 12, 142, 33, 133, 48, 181, 98, 99, 28, 12 }, new byte[] { 43, 56, 56, 111, 186, 118, 3, 172, 167, 56, 181, 194, 18, 120, 38, 44, 137, 72, 218, 163, 59, 187, 112, 33, 97, 84, 98, 154, 97, 235, 245, 32, 84, 45, 125, 196, 21, 83, 244, 137, 213, 139, 121, 57, 94, 1, 246, 221, 12, 23, 215, 214, 55, 71, 95, 63, 80, 125, 227, 215, 222, 181, 230, 236, 115, 100, 176, 93, 123, 253, 250, 164, 139, 9, 44, 103, 183, 94, 206, 158, 143, 89, 195, 79, 216, 67, 113, 158, 40, 113, 128, 113, 134, 82, 255, 141, 63, 144, 198, 189, 93, 213, 143, 48, 75, 0, 205, 196, 250, 159, 165, 251, 43, 148, 33, 154, 107, 114, 204, 180, 14, 17, 75, 195, 74, 155, 208, 6 }, null, "admin" },
                    { new Guid("e806ad30-83cb-4bbe-a350-ae52c1f9bf73"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "test1@mail.com", "test1A", false, false, false, "test1B", new byte[] { 176, 106, 231, 100, 108, 29, 115, 161, 14, 148, 23, 30, 182, 158, 247, 123, 201, 10, 65, 203, 194, 13, 241, 178, 112, 17, 20, 234, 84, 22, 78, 173, 189, 179, 19, 170, 218, 107, 94, 188, 99, 222, 178, 144, 2, 42, 112, 59, 65, 153, 167, 161, 78, 38, 210, 238, 154, 190, 85, 226, 161, 100, 131, 44 }, new byte[] { 150, 226, 213, 246, 103, 226, 64, 200, 233, 86, 209, 89, 127, 33, 123, 161, 86, 253, 227, 236, 3, 195, 5, 152, 141, 197, 135, 78, 163, 232, 142, 18, 176, 185, 243, 46, 84, 25, 48, 214, 189, 77, 151, 95, 147, 42, 252, 161, 140, 194, 214, 25, 230, 195, 31, 64, 118, 183, 152, 35, 184, 220, 74, 149, 152, 189, 63, 46, 242, 6, 17, 6, 64, 131, 216, 114, 72, 190, 152, 177, 86, 252, 181, 188, 124, 222, 122, 42, 246, 207, 55, 245, 55, 3, 73, 124, 232, 200, 251, 167, 80, 86, 27, 153, 181, 58, 182, 90, 169, 111, 211, 212, 61, 62, 107, 5, 180, 87, 46, 178, 247, 9, 31, 78, 200, 19, 177, 87 }, null, "test1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("15c2084c-0066-4066-88c1-6a04cb5f3fdb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("27083416-5d6f-424c-bdc8-28d403db5319"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3821394b-e2d1-4c76-9794-5b1ced0167ac"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("47ccafb1-ad6f-4ee8-b887-70b750f8b5c3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5c291373-f99c-46dc-ad5b-cf65dab10e4a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("633b87a9-07de-4b61-a299-26772df39620"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("70821498-d479-4abd-85d0-272aaca771a1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("985e2478-e0f8-4c19-9584-36582a768c88"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a96d1c49-c671-4eda-9631-bf7391bb7a77"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("aa809d98-011f-4a99-bc16-f3ed28a11087"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c2a2243e-41e6-4709-be4b-0b13bc90304f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ca7db341-5a3d-4ae0-9267-badfbf38fdc8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d06b7c90-3f47-4863-8fbd-0dccdff99a82"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d2cf4e8f-d6e5-4896-bb28-f085c19cd2fb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e01a3224-4aa9-4078-9d10-d1f766012533"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f1515d9b-447a-4272-ab46-8b60e98635dc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f65fd854-b94e-4a33-908a-1a16047810bb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fb71c371-18a4-4282-b830-4822ba3a423f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3522894c-0f15-4f9e-b379-ab644f4e918e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b87b9540-c07f-4ce6-905d-41e2f33a6a95"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e806ad30-83cb-4bbe-a350-ae52c1f9bf73"));

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "DeletedOn", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("04aebc32-da35-4b56-85c8-baa8179f34f3"), null, false, "Asia" },
                    { new Guid("0f4889fa-e377-4382-996a-dab173b863e0"), null, false, "South America" },
                    { new Guid("1199699a-8dd5-4ade-af8a-2fd05cdd0786"), null, false, "Burgas" },
                    { new Guid("41e18d36-e2e4-4155-85fe-8771ce68989e"), null, false, "tournament" },
                    { new Guid("449eb51c-2c2c-4141-b25c-64301de61977"), null, false, "science" },
                    { new Guid("5a1a9098-b13b-45af-bf0b-24a8271200ab"), null, false, "charity" },
                    { new Guid("5a2eccbb-c50a-4296-b970-348435a65f74"), null, false, "economy" },
                    { new Guid("68c133da-ce93-4f28-ba99-67ad71ac5cdb"), null, false, "Australia" },
                    { new Guid("6c18e00d-6fbb-4a54-93f5-4e7e5b0ec94c"), null, false, "event" },
                    { new Guid("70a8ff7c-b51c-41d7-a095-2beb23f16ff4"), null, false, "Europe" },
                    { new Guid("8269a7a2-8a2a-40f7-9ee3-d944de01dd0d"), null, false, "Africa" },
                    { new Guid("8c0a4108-2a2e-4a8c-b989-a467783bff1a"), null, false, "Plovdiv" },
                    { new Guid("a5401430-a2ac-45e0-aa2f-0603917fad34"), null, false, "investment" },
                    { new Guid("b1d052b0-4559-489a-9b1f-356e554b9b27"), null, false, "funny" },
                    { new Guid("b768e6c9-3477-491b-ac64-06069a64432b"), null, false, "Sofiq" },
                    { new Guid("c8824a3a-8f0e-441f-9527-1ad69b828875"), null, false, "North America" },
                    { new Guid("f9d4542d-de81-468e-9fc0-364646a30b97"), null, false, "Bulgaria" },
                    { new Guid("febe504f-7075-428c-83b5-4803a67c09ab"), null, false, "Varna" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Email", "FirstName", "IsAdmin", "IsBlocked", "IsDeleted", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { new Guid("63e1353d-2f60-41f4-b347-94d85dab299a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "test1@mail.com", "test1A", false, false, false, "test1B", new byte[] { 176, 106, 231, 100, 108, 29, 115, 161, 14, 148, 23, 30, 182, 158, 247, 123, 201, 10, 65, 203, 194, 13, 241, 178, 112, 17, 20, 234, 84, 22, 78, 173, 189, 179, 19, 170, 218, 107, 94, 188, 99, 222, 178, 144, 2, 42, 112, 59, 65, 153, 167, 161, 78, 38, 210, 238, 154, 190, 85, 226, 161, 100, 131, 44 }, new byte[] { 150, 226, 213, 246, 103, 226, 64, 200, 233, 86, 209, 89, 127, 33, 123, 161, 86, 253, 227, 236, 3, 195, 5, 152, 141, 197, 135, 78, 163, 232, 142, 18, 176, 185, 243, 46, 84, 25, 48, 214, 189, 77, 151, 95, 147, 42, 252, 161, 140, 194, 214, 25, 230, 195, 31, 64, 118, 183, 152, 35, 184, 220, 74, 149, 152, 189, 63, 46, 242, 6, 17, 6, 64, 131, 216, 114, 72, 190, 152, 177, 86, 252, 181, 188, 124, 222, 122, 42, 246, 207, 55, 245, 55, 3, 73, 124, 232, 200, 251, 167, 80, 86, 27, 153, 181, 58, 182, 90, 169, 111, 211, 212, 61, 62, 107, 5, 180, 87, 46, 178, 247, 9, 31, 78, 200, 19, 177, 87 }, null, "test1" },
                    { new Guid("8d9ab9d2-8896-4459-a532-949ceb5dad0b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "tes2@mail.com", "test2A", false, false, false, "test2B", new byte[] { 165, 196, 217, 130, 173, 225, 82, 58, 64, 96, 126, 243, 81, 198, 152, 7, 239, 105, 101, 244, 37, 212, 243, 220, 45, 85, 136, 31, 149, 218, 147, 156, 131, 200, 141, 191, 78, 163, 10, 102, 213, 167, 132, 32, 206, 143, 91, 103, 230, 176, 97, 52, 252, 232, 236, 1, 65, 228, 140, 96, 110, 48, 245, 29 }, new byte[] { 46, 78, 60, 63, 212, 204, 100, 222, 52, 81, 27, 53, 207, 179, 178, 138, 219, 242, 62, 101, 24, 50, 134, 14, 117, 221, 2, 114, 111, 25, 175, 186, 206, 226, 115, 203, 226, 10, 53, 14, 241, 202, 163, 43, 96, 133, 235, 93, 215, 212, 143, 247, 105, 99, 1, 145, 96, 198, 180, 196, 126, 64, 8, 4, 150, 174, 191, 71, 205, 138, 116, 193, 165, 49, 105, 68, 111, 39, 88, 245, 170, 2, 150, 45, 73, 138, 28, 66, 16, 164, 138, 11, 221, 108, 165, 25, 80, 155, 194, 139, 119, 215, 151, 108, 156, 129, 22, 73, 208, 61, 109, 153, 123, 38, 127, 84, 221, 42, 210, 93, 103, 20, 45, 251, 219, 80, 90, 12 }, null, "test2" },
                    { new Guid("b98fda67-5984-4e7d-916d-7fcb906cd2b1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@mail.com", "admin1A", false, false, false, "admin1B", new byte[] { 100, 174, 69, 49, 244, 40, 75, 242, 75, 190, 7, 50, 191, 21, 210, 51, 175, 89, 167, 216, 73, 209, 117, 127, 139, 6, 180, 213, 120, 123, 133, 100, 188, 7, 2, 113, 119, 171, 30, 108, 70, 31, 89, 21, 19, 74, 54, 168, 215, 248, 61, 25, 88, 232, 12, 142, 33, 133, 48, 181, 98, 99, 28, 12 }, new byte[] { 43, 56, 56, 111, 186, 118, 3, 172, 167, 56, 181, 194, 18, 120, 38, 44, 137, 72, 218, 163, 59, 187, 112, 33, 97, 84, 98, 154, 97, 235, 245, 32, 84, 45, 125, 196, 21, 83, 244, 137, 213, 139, 121, 57, 94, 1, 246, 221, 12, 23, 215, 214, 55, 71, 95, 63, 80, 125, 227, 215, 222, 181, 230, 236, 115, 100, 176, 93, 123, 253, 250, 164, 139, 9, 44, 103, 183, 94, 206, 158, 143, 89, 195, 79, 216, 67, 113, 158, 40, 113, 128, 113, 134, 82, 255, 141, 63, 144, 198, 189, 93, 213, 143, 48, 75, 0, 205, 196, 250, 159, 165, 251, 43, 148, 33, 154, 107, 114, 204, 180, 14, 17, 75, 195, 74, 155, 208, 6 }, null, "admin" }
                });
        }
    }
}
