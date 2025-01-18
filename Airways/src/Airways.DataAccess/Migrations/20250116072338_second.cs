using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airways.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reys_AirwaysUser_UserId",
                table: "Reys");

            migrationBuilder.DropIndex(
                name: "IX_Reys_UserId",
                table: "Reys");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reys");

            migrationBuilder.AddColumn<Guid>(
                name: "ReysId",
                table: "AirwaysUser",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AirwaysUser_ReysId",
                table: "AirwaysUser",
                column: "ReysId");

            migrationBuilder.AddForeignKey(
                name: "FK_AirwaysUser_Reys_ReysId",
                table: "AirwaysUser",
                column: "ReysId",
                principalTable: "Reys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AirwaysUser_Reys_ReysId",
                table: "AirwaysUser");

            migrationBuilder.DropIndex(
                name: "IX_AirwaysUser_ReysId",
                table: "AirwaysUser");

            migrationBuilder.DropColumn(
                name: "ReysId",
                table: "AirwaysUser");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Reys",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reys_UserId",
                table: "Reys",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reys_AirwaysUser_UserId",
                table: "Reys",
                column: "UserId",
                principalTable: "AirwaysUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
