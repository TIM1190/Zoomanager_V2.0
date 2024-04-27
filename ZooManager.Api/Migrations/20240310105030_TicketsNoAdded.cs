using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class TicketsNoAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "No",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "No",
                table: "Tickets");
        }
    }
}
