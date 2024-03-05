using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotelHubApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatemodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCustomerConfirmed",
                table: "Contracts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHostConfirmed",
                table: "Contracts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCustomerConfirmed",
                table: "Bills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHostConfirmed",
                table: "Bills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "OtherFee",
                table: "Bills",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCustomerConfirmed",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "IsHostConfirmed",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "IsCustomerConfirmed",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "IsHostConfirmed",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "OtherFee",
                table: "Bills");
        }
    }
}
