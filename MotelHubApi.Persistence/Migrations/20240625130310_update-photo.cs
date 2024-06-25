using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotelHubApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatephoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Areas_AreaId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Contracts_ContractId",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "Photos",
                newName: "WorkOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_AreaId",
                table: "Photos",
                newName: "IX_Photos_WorkOrderId");

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "CustomerSignature",
                table: "Contracts",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_BillId",
                table: "Photos",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Bills_BillId",
                table: "Photos",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Contracts_ContractId",
                table: "Photos",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_WorkOrders_WorkOrderId",
                table: "Photos",
                column: "WorkOrderId",
                principalTable: "WorkOrders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Bills_BillId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Contracts_ContractId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_WorkOrders_WorkOrderId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_BillId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "CustomerSignature",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "WorkOrderId",
                table: "Photos",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_WorkOrderId",
                table: "Photos",
                newName: "IX_Photos_AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Areas_AreaId",
                table: "Photos",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Contracts_ContractId",
                table: "Photos",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
