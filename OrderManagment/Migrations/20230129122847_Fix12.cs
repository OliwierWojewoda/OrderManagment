using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagment.Migrations
{
    /// <inheritdoc />
    public partial class Fix12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "OverallBrutto",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OverallNetto",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OverallBrutto",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OverallNetto",
                table: "Orders");
        }
    }
}
