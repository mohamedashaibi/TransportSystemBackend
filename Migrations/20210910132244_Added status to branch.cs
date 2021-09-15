using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportSystem.Migrations
{
    public partial class Addedstatustobranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d003569-85ea-4376-84cb-0b1c7c985988");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "772a2826-4dd2-400b-8ea7-432815006b22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95f1273a-e3d8-4d83-864b-9ab01efa387b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99c61408-7f0c-4288-bb92-e548b6589f25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d226581b-feb2-4c1a-ab95-6260e28fcc46");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Branches",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Branches");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d003569-85ea-4376-84cb-0b1c7c985988", "d8c1133e-c5d7-4ae2-aa1f-9d3d2745da35", "Developer", "DEVELOPER" },
                    { "d226581b-feb2-4c1a-ab95-6260e28fcc46", "62dea75f-65af-4203-9599-cb451d248f81", "NormalUser", "NORMALUSER" },
                    { "95f1273a-e3d8-4d83-864b-9ab01efa387b", "1caf57c3-b711-4d36-b6b8-2ddebdad410b", "BranchUser", "BRANCHUSER" },
                    { "772a2826-4dd2-400b-8ea7-432815006b22", "c2c37635-9626-4ce9-a44f-78c591c31c15", "CompanyUser", "COMPANYUSER" },
                    { "99c61408-7f0c-4288-bb92-e548b6589f25", "10e2fb79-33fc-457d-9b23-20bdb79d878a", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
