using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportSystem.Migrations
{
    public partial class Addedcities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ecd9490-1ee9-4783-8973-938f71a066c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28aa4b91-a687-44e0-bf70-ef8bebeebfd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "415a3af2-039f-4925-8d8e-f89ccf34704e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7801fd28-3655-4c63-b242-f6e29132c55b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dede6577-6b71-4424-ba4b-b5a4dfcf16a3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f3ecf096-3661-426d-81e4-ffbbabb6725d", "644d7956-827b-4767-b0f5-1efef04d4651", "Developer", "DEVELOPER" },
                    { "8e118f4d-394b-4cba-befd-ce7324360453", "603fbafb-fbb4-43bc-9f12-edf246e01cdf", "NormalUser", "NORMALUSER" },
                    { "a2d643bf-bac3-4f71-8f8b-3bdf866445c0", "db5f7a99-ee61-4790-b69a-14bc9347c397", "BranchUser", "BRANCHUSER" },
                    { "0a350b95-2b24-442d-80df-73a5baac0f1d", "e1a38ada-39d1-4392-ab89-52ec67c4577f", "CompanyUser", "COMPANYUSER" },
                    { "eedd5e78-c873-491b-aee7-9e979824f91a", "91985314-9df6-486c-a770-17ac00282c57", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "ArabicName", "EnglishName" },
                values: new object[,]
                {
                    { 1, "طرابلس", "Tripoli" },
                    { 2, "بنغازي", "Benghazi" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a350b95-2b24-442d-80df-73a5baac0f1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e118f4d-394b-4cba-befd-ce7324360453");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2d643bf-bac3-4f71-8f8b-3bdf866445c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eedd5e78-c873-491b-aee7-9e979824f91a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3ecf096-3661-426d-81e4-ffbbabb6725d");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ecd9490-1ee9-4783-8973-938f71a066c5", "2f343443-7d70-4576-bd1e-93a63e82d433", "Developer", "DEVELOPER" },
                    { "415a3af2-039f-4925-8d8e-f89ccf34704e", "4f4ca802-1a2a-41f6-990f-bd9a580ef170", "NormalUser", "NORMALUSER" },
                    { "dede6577-6b71-4424-ba4b-b5a4dfcf16a3", "ed92685d-9864-41d4-b341-587e1d6cee59", "BranchUser", "BRANCHUSER" },
                    { "7801fd28-3655-4c63-b242-f6e29132c55b", "73e94b56-4acf-4571-a13a-4ee1f1116def", "CompanyUser", "COMPANYUSER" },
                    { "28aa4b91-a687-44e0-bf70-ef8bebeebfd7", "4efebb61-2f87-42a6-ab18-b5553665c789", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
