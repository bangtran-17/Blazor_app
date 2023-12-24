using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Server.Migrations
{
    /// <inheritdoc />
    public partial class addRid1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ROOMTYPE",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValueSql: "(N'')",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RT_SmokeFriendly",
                table: "ROOMTYPE",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "(N'')",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RT_NAME",
                table: "ROOMTYPE",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValueSql: "(N'')",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RT_DES",
                table: "ROOMTYPE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "(N'')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ROOMTYPE",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValueSql: "(N'')");

            migrationBuilder.AlterColumn<string>(
                name: "RT_SmokeFriendly",
                table: "ROOMTYPE",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValueSql: "(N'')");

            migrationBuilder.AlterColumn<string>(
                name: "RT_NAME",
                table: "ROOMTYPE",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValueSql: "(N'')");

            migrationBuilder.AlterColumn<string>(
                name: "RT_DES",
                table: "ROOMTYPE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "(N'')");
        }
    }
}
