using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportSystem.Migrations
{
    public partial class addedpricetoinvoiceproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CompanyProducts");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "InvoiceProducts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8f522bdc-a577-4674-85f6-491a7847a11a", "0aa2c4fc-592b-4bc5-840e-08847f859c61", "Developer", "DEVELOPER" },
                    { "2d169c3c-a093-450d-b5cb-d234988e40cf", "df2bc595-993d-49b6-8b31-3cf7234c4823", "NormalUser", "NORMALUSER" },
                    { "27f0dd74-9ab9-465f-9b8a-61a5e2d9ad0c", "c78f00f9-f136-4df9-81fc-7f20300f4c9e", "BranchUser", "BRANCHUSER" },
                    { "c49e5e8a-fe9e-4ec8-9ba5-ada14d996d77", "2ec5c925-f05b-4f45-960c-2d997d946f81", "CompanyUser", "COMPANYUSER" },
                    { "94c5c3ff-9076-4172-b664-33892054d39f", "62df679b-6512-4b98-88ec-68bb68f836f6", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27f0dd74-9ab9-465f-9b8a-61a5e2d9ad0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d169c3c-a093-450d-b5cb-d234988e40cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f522bdc-a577-4674-85f6-491a7847a11a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94c5c3ff-9076-4172-b664-33892054d39f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c49e5e8a-fe9e-4ec8-9ba5-ada14d996d77");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "InvoiceProducts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Companies");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "CompanyProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
        }
    }
}
