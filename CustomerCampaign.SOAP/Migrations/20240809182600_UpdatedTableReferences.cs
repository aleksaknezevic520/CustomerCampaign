using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerCampaign.SOAP.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTableReferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rewards_AgentId",
                table: "Rewards");

            migrationBuilder.DropIndex(
                name: "IX_Rewards_CustomerId",
                table: "Rewards");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Customers",
                newName: "RwardId");

            migrationBuilder.AlterColumn<string>(
                name: "SSN",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsLoyal",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Agents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RewardId = table.Column<int>(type: "int", nullable: true),
                    DiscountedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_Rewards_RewardId",
                        column: x => x.RewardId,
                        principalTable: "Rewards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseItem_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_AgentId_CustomerId_CreatedDate",
                table: "Rewards",
                columns: new[] { "AgentId", "CustomerId", "CreatedDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_CustomerId",
                table: "Rewards",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SSN",
                table: "Customers",
                column: "SSN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_Email",
                table: "Agents",
                column: "Email",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CustomerId",
                table: "Purchase",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_RewardId",
                table: "Purchase",
                column: "RewardId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItem_PurchaseId",
                table: "PurchaseItem",
                column: "PurchaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseItem");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Rewards_AgentId_CustomerId_CreatedDate",
                table: "Rewards");

            migrationBuilder.DropIndex(
                name: "IX_Rewards_CustomerId",
                table: "Rewards");

            migrationBuilder.DropIndex(
                name: "IX_Customers_SSN",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Agents_Email",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_State",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_Zip",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "IsLoyal",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Agents");

            migrationBuilder.RenameColumn(
                name: "RwardId",
                table: "Customers",
                newName: "Age");

            migrationBuilder.AlterColumn<string>(
                name: "SSN",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_AgentId",
                table: "Rewards",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_CustomerId",
                table: "Rewards",
                column: "CustomerId");
        }
    }
}
