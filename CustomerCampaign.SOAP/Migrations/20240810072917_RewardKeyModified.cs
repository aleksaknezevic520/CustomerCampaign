using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerCampaign.SOAP.Migrations
{
    /// <inheritdoc />
    public partial class RewardKeyModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Rewards_RewardId",
                table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rewards",
                table: "Rewards");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_RewardId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Rewards");

            migrationBuilder.AddColumn<int>(
                name: "RewardAgentId",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RewardCustomerId",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rewards",
                table: "Rewards",
                columns: new[] { "AgentId", "CustomerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_RewardAgentId_RewardCustomerId",
                table: "Purchase",
                columns: new[] { "RewardAgentId", "RewardCustomerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Rewards_RewardAgentId_RewardCustomerId",
                table: "Purchase",
                columns: new[] { "RewardAgentId", "RewardCustomerId" },
                principalTable: "Rewards",
                principalColumns: new[] { "AgentId", "CustomerId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Rewards_RewardAgentId_RewardCustomerId",
                table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rewards",
                table: "Rewards");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_RewardAgentId_RewardCustomerId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "RewardAgentId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "RewardCustomerId",
                table: "Purchase");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Rewards",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rewards",
                table: "Rewards",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_RewardId",
                table: "Purchase",
                column: "RewardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Rewards_RewardId",
                table: "Purchase",
                column: "RewardId",
                principalTable: "Rewards",
                principalColumn: "Id");
        }
    }
}
