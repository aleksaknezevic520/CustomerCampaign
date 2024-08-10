using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerCampaign.SOAP.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRewardReferenceFromPurchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Rewards_RewardAgentId_RewardCustomerId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_RewardAgentId_RewardCustomerId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "RewardAgentId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "RewardCustomerId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "RewardId",
                table: "Purchases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RewardAgentId",
                table: "Purchases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RewardCustomerId",
                table: "Purchases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RewardId",
                table: "Purchases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_RewardAgentId_RewardCustomerId",
                table: "Purchases",
                columns: new[] { "RewardAgentId", "RewardCustomerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Rewards_RewardAgentId_RewardCustomerId",
                table: "Purchases",
                columns: new[] { "RewardAgentId", "RewardCustomerId" },
                principalTable: "Rewards",
                principalColumns: new[] { "AgentId", "CustomerId" });
        }
    }
}
