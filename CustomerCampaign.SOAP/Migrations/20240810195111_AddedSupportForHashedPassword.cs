using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerCampaign.SOAP.Migrations
{
    /// <inheritdoc />
    public partial class AddedSupportForHashedPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Agents",
                newName: "Salt");

            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "Agents");

            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "Agents",
                newName: "Password");
        }
    }
}
