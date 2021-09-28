using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class cardDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillPayments_Cards_CardId",
                table: "BillPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_DuesPayments_Cards_CardId",
                table: "DuesPayments");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_DuesPayments_CardId",
                table: "DuesPayments");

            migrationBuilder.DropIndex(
                name: "IX_BillPayments_CardId",
                table: "BillPayments");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "DuesPayments");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "BillPayments");

            migrationBuilder.AddColumn<string>(
                name: "CardDocumentId",
                table: "BillPayments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardDocumentId",
                table: "BillPayments");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "DuesPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "BillPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cvv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuesPayments_CardId",
                table: "DuesPayments",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_BillPayments_CardId",
                table: "BillPayments",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserId",
                table: "Cards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillPayments_Cards_CardId",
                table: "BillPayments",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DuesPayments_Cards_CardId",
                table: "DuesPayments",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
