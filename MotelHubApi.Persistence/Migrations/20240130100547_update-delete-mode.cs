using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotelHubApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedeletemode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_AspNetUsers_HostId",
                table: "Contracts");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_AspNetUsers_HostId",
                table: "Contracts",
                column: "HostId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_AspNetUsers_HostId",
                table: "Contracts");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_AspNetUsers_HostId",
                table: "Contracts",
                column: "HostId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
