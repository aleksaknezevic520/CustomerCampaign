using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerCampaign.SOAP.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUniqueConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Addresses_State",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_Zip",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_State",
                table: "Addresses",
                column: "State",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Zip",
                table: "Addresses",
                column: "Zip",
                unique: true);
        }
    }
}
