using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Server.Migrations
{
    /// <inheritdoc />
    public partial class addRid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ROOMBOOKED");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ROOMTYPE",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "R_Area",
                table: "ROOMTYPE",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RT_SmokeFriendly",
                table: "ROOMTYPE",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
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
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RT_DES",
                table: "ROOMTYPE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RT_Cost",
                table: "ROOMTYPE",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaidDate",
                table: "PAYMENT",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "B_Cost",
                table: "BOOKING",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rid",
                table: "BOOKING",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StripeSessionId",
                table: "BOOKING",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoomImg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RoomImg__3214EC076EFE77A3", x => x.Id);
                    table.ForeignKey(
                        name: "FK__RoomImg__RoomId__160F4887",
                        column: x => x.RoomId,
                        principalTable: "ROOMTYPE",
                        principalColumn: "RT_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOOKING_Rid",
                table: "BOOKING",
                column: "Rid");

            migrationBuilder.CreateIndex(
                name: "IX_RoomImg_RoomId",
                table: "RoomImg",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK__BOOKING__Rid__01142BA1",
                table: "BOOKING",
                column: "Rid",
                principalTable: "ROOM",
                principalColumn: "R_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__BOOKING__Rid__01142BA1",
                table: "BOOKING");

            migrationBuilder.DropTable(
                name: "RoomImg");

            migrationBuilder.DropIndex(
                name: "IX_BOOKING_Rid",
                table: "BOOKING");

            migrationBuilder.DropColumn(
                name: "PaidDate",
                table: "PAYMENT");

            migrationBuilder.DropColumn(
                name: "B_Cost",
                table: "BOOKING");

            migrationBuilder.DropColumn(
                name: "Rid",
                table: "BOOKING");

            migrationBuilder.DropColumn(
                name: "StripeSessionId",
                table: "BOOKING");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ROOMTYPE",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "R_Area",
                table: "ROOMTYPE",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "RT_SmokeFriendly",
                table: "ROOMTYPE",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "RT_NAME",
                table: "ROOMTYPE",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "RT_DES",
                table: "ROOMTYPE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "RT_Cost",
                table: "ROOMTYPE",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "ROOMBOOKED",
                columns: table => new
                {
                    RId = table.Column<int>(type: "int", nullable: false),
                    BId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ROOMBOOK__AAA740774ECA924A", x => new { x.RId, x.BId });
                    table.ForeignKey(
                        name: "FK__ROOMBOOKED__B_ID__797309D9",
                        column: x => x.BId,
                        principalTable: "BOOKING",
                        principalColumn: "B_ID");
                    table.ForeignKey(
                        name: "FK__ROOMBOOKED__R_ID__787EE5A0",
                        column: x => x.RId,
                        principalTable: "ROOM",
                        principalColumn: "R_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ROOMBOOKED_BId",
                table: "ROOMBOOKED",
                column: "BId");
        }
    }
}
