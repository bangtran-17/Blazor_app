using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddEAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EAccount",
                table: "EMPLOYEE",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EAccount",
                table: "EMPLOYEE");
        }
    }
}
