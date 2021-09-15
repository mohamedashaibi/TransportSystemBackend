using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportSystem.Migrations
{
    public partial class Addedcities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb32593-7af4-4ab5-a2e5-6bbe94462f75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7134f440-05d0-450e-9c4c-8124eb97a7ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f26cd61-035f-42b4-925c-89ed2c7a31c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bf76ef8-0df9-484f-b378-6334494a581d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c50b049d-c5ec-45db-8a07-984934a25ed0");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "7134f440-05d0-450e-9c4c-8124eb97a7ae", "22aa2fee-a15f-455b-a5e8-24a9f396cf78", "Developer", "DEVELOPER" },
                    { "9bf76ef8-0df9-484f-b378-6334494a581d", "d3058930-a029-430c-9e49-d4fb0876d74e", "NormalUser", "NORMALUSER" },
                    { "5cb32593-7af4-4ab5-a2e5-6bbe94462f75", "c8ed24ec-bad6-486d-b300-3c01ef7414ed", "BranchUser", "BRANCHUSER" },
                    { "c50b049d-c5ec-45db-8a07-984934a25ed0", "d0c073c1-dec2-421a-9087-5d55c2c4b622", "CompanyUser", "COMPANYUSER" },
                    { "8f26cd61-035f-42b4-925c-89ed2c7a31c1", "4e578397-09fd-4c4e-bfd0-4ed5c5c23004", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
