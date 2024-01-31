using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotelHubApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatemeterreading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "MeterReadings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "MeterReadings",
                type: "float",
                nullable: true);
        }
    }
}
