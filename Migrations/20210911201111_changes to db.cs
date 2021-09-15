using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportSystem.Migrations
{
    public partial class changestodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Informtion",
                table: "Invoices",
                newName: "Information");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Invoices",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5150dcea-24a2-4a32-b1a6-cacb212e130a", "ab51ef2b-09f3-4900-bab2-391cb4fa5978", "Developer", "DEVELOPER" },
                    { "33a1dc35-9cf1-4cbd-8532-eae7a6ae72ea", "30af3e38-0c42-4b73-9bfb-96254d431ea7", "NormalUser", "NORMALUSER" },
                    { "547075d7-6956-4a69-b08f-908fd7bdd7bb", "3f6b190a-7eaf-4c6f-8916-5f85f9e06466", "BranchUser", "BRANCHUSER" },
                    { "7c26f58e-a0e1-4641-afc0-77b71c93b207", "30fa1118-805a-4051-b3d6-e2604e7ea4ef", "CompanyUser", "COMPANYUSER" },
                    { "9d686d5d-bf99-495e-a3ec-27899f08f778", "2c4485b4-04ff-4424-8f83-fbfdc4c924eb", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CompanyId",
                table: "Invoices",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Companies_CompanyId",
                table: "Invoices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Companies_CompanyId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_CompanyId",
                table: "Invoices");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33a1dc35-9cf1-4cbd-8532-eae7a6ae72ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5150dcea-24a2-4a32-b1a6-cacb212e130a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "547075d7-6956-4a69-b08f-908fd7bdd7bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c26f58e-a0e1-4641-afc0-77b71c93b207");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d686d5d-bf99-495e-a3ec-27899f08f778");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "Information",
                table: "Invoices",
                newName: "Informtion");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Invoices",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

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
    }
}
