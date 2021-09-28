using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillPayments_Residents_ResidentId",
                table: "BillPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_DuesPayments_Residents_ResidentId",
                table: "DuesPayments");

            migrationBuilder.DropIndex(
                name: "IX_DuesPayments_ResidentId",
                table: "DuesPayments");

            migrationBuilder.DropIndex(
                name: "IX_BillPayments_ResidentId",
                table: "BillPayments");

            migrationBuilder.DropColumn(
                name: "ResidentId",
                table: "DuesPayments");

            migrationBuilder.DropColumn(
                name: "ResidentId",
                table: "BillPayments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResidentId",
                table: "DuesPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResidentId",
                table: "BillPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DuesPayments_ResidentId",
                table: "DuesPayments",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_BillPayments_ResidentId",
                table: "BillPayments",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillPayments_Residents_ResidentId",
                table: "BillPayments",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DuesPayments_Residents_ResidentId",
                table: "DuesPayments",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
