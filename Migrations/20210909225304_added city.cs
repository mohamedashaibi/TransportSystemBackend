using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportSystem.Migrations
{
    public partial class addedcity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0420f1d1-bcdc-4184-91fb-bf4c526b0c00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8eb0cc37-8144-434b-9dae-6f2012190ea6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b91d9494-a69b-487e-8eef-1267cac5f492");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1719f33-a66d-4e49-ae5d-1f9ef8f6d61e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1808b16-9671-49fa-9114-fec779ee946e");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "NormalUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "NormalUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DeveloperUsers");

            migrationBuilder.AddColumn<string>(
                name: "Informtion",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Information",
                table: "InvoiceProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Branches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CityId",
                table: "Branches",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_City_CityId",
                table: "Branches",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_City_CityId",
                table: "Branches");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropIndex(
                name: "IX_Branches_CityId",
                table: "Branches");

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

            migrationBuilder.DropColumn(
                name: "Informtion",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Information",
                table: "InvoiceProducts");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Branches");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "NormalUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "NormalUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DeveloperUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b91d9494-a69b-487e-8eef-1267cac5f492", "8dd32fed-a083-465c-bb70-f259bfd0fb42", "Developer", "DEVELOPER" },
                    { "0420f1d1-bcdc-4184-91fb-bf4c526b0c00", "da14c7e7-beb3-400b-a02f-03f437e76d48", "NormalUser", "NORMALUSER" },
                    { "c1719f33-a66d-4e49-ae5d-1f9ef8f6d61e", "bfefb72f-f10c-4ef3-bbba-e9f4b6788277", "BranchUser", "BRANCHUSER" },
                    { "d1808b16-9671-49fa-9114-fec779ee946e", "920fcf69-e703-4ce5-9c1d-300d239f1d0a", "CompanyUser", "COMPANYUSER" },
                    { "8eb0cc37-8144-434b-9dae-6f2012190ea6", "0f8de773-1aca-410d-bc72-c5a3cd7a1cbb", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
