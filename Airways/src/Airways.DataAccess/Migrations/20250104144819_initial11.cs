using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airways.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AirwaysUser",
                newName: "Salt");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "AirwaysUser",
                newName: "Role");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AirwaysUser",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AirwaysUser",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassportId",
                table: "AirwaysUser",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AirwaysUser",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AirwaysUser");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AirwaysUser");

            migrationBuilder.DropColumn(
                name: "PassportId",
                table: "AirwaysUser");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AirwaysUser");

            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "AirwaysUser",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "AirwaysUser",
                newName: "PhoneNumber");
        }
    }
}
