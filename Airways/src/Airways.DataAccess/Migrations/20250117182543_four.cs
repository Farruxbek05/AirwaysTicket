using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airways.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class four : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AirwaysUser_UserId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Classes_ClassId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Payments_PaymentId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ClassId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AdditionalCharge",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ClassType",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "MaxCharge",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ReservationExpiresOn",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "OrderTime",
                table: "Tickets",
                newName: "ScheduledDepartureTime");

            migrationBuilder.AlterColumn<string>(
                name: "SeatNumber",
                table: "Tickets",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentId",
                table: "Tickets",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "ArrivalCity",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepartureCity",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassengerName",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Payments_PaymentId",
                table: "Tickets",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Payments_PaymentId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ArrivalCity",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DepartureCity",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PassengerName",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "ScheduledDepartureTime",
                table: "Tickets",
                newName: "OrderTime");

            migrationBuilder.AlterColumn<int>(
                name: "SeatNumber",
                table: "Tickets",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentId",
                table: "Tickets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AdditionalCharge",
                table: "Tickets",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "ClassId",
                table: "Tickets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "ClassType",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxCharge",
                table: "Tickets",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationExpiresOn",
                table: "Tickets",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Tickets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ClassId",
                table: "Tickets",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AirwaysUser_UserId",
                table: "Tickets",
                column: "UserId",
                principalTable: "AirwaysUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Classes_ClassId",
                table: "Tickets",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Payments_PaymentId",
                table: "Tickets",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
