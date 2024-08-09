using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerCampaign.SOAP.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCustomerRewardRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RwardId",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RwardId",
                table: "Customers",
                type: "int",
                nullable: true);
        }
    }
}
