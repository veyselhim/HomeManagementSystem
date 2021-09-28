using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ResidentDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Residents_ResidentId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Residents_ResidentId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Residents_ResidentId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Dueses_Residents_ResidentId",
                table: "Dueses");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Residents_ResidentId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_User_UserId",
                table: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Residents");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.RenameColumn(
                name: "ResidentId",
                table: "Messages",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ResidentId",
                table: "Messages",
                newName: "IX_Messages_UserId");

            migrationBuilder.RenameColumn(
                name: "ResidentId",
                table: "Dueses",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Dueses_ResidentId",
                table: "Dueses",
                newName: "IX_Dueses_UserId");

            migrationBuilder.RenameColumn(
                name: "ResidentId",
                table: "Cards",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_ResidentId",
                table: "Cards",
                newName: "IX_Cards_UserId");

            migrationBuilder.RenameColumn(
                name: "ResidentId",
                table: "Bills",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_ResidentId",
                table: "Bills",
                newName: "IX_Bills_UserId");

            migrationBuilder.RenameColumn(
                name: "ResidentId",
                table: "Apartments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Apartments_ResidentId",
                table: "Apartments",
                newName: "IX_Apartments_UserId");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehiclePlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Users_UserId",
                table: "Apartments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Users_UserId",
                table: "Bills",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Users_UserId",
                table: "Cards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dueses_Users_UserId",
                table: "Dueses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_Users_UserId",
                table: "UserOperationClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Users_UserId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Users_UserId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Users_UserId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Dueses_Users_UserId",
                table: "Dueses");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_Users_UserId",
                table: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Messages",
                newName: "ResidentId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                newName: "IX_Messages_ResidentId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Dueses",
                newName: "ResidentId");

            migrationBuilder.RenameIndex(
                name: "IX_Dueses_UserId",
                table: "Dueses",
                newName: "IX_Dueses_ResidentId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cards",
                newName: "ResidentId");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_UserId",
                table: "Cards",
                newName: "IX_Cards_ResidentId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Bills",
                newName: "ResidentId");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_UserId",
                table: "Bills",
                newName: "IX_Bills_ResidentId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Apartments",
                newName: "ResidentId");

            migrationBuilder.RenameIndex(
                name: "IX_Apartments_UserId",
                table: "Apartments",
                newName: "IX_Apartments_ResidentId");

            migrationBuilder.CreateTable(
                name: "Residents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehiclePlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    VehiclePlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Residents_ResidentId",
                table: "Apartments",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Residents_ResidentId",
                table: "Bills",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Residents_ResidentId",
                table: "Cards",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dueses_Residents_ResidentId",
                table: "Dueses",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Residents_ResidentId",
                table: "Messages",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_User_UserId",
                table: "UserOperationClaims",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
