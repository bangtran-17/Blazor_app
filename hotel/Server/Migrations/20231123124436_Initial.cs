using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENT",
                columns: table => new
                {
                    DE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DE_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DE_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DE_InitialSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DEPARTME__F2DD468775278C67", x => x.DE_ID);
                });

            migrationBuilder.CreateTable(
                name: "DISCOUNT",
                columns: table => new
                {
                    D_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    D_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    D_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_Rate = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DISCOUNT__76B8FF7D48D2F315", x => x.D_ID);
                });

            migrationBuilder.CreateTable(
                name: "GUEST",
                columns: table => new
                {
                    G_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    G_FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    G_LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    G_SDT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    G_Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    G_CCCD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    G_Account = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GUEST__153A8ED2E509F5A5", x => x.G_ID);
                });

            migrationBuilder.CreateTable(
                name: "HOTEL",
                columns: table => new
                {
                    H_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    H_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    H_SDT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    H_Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    H_Website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    H_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    H_TotalRoom = table.Column<int>(type: "int", nullable: true),
                    H_FloorCount = table.Column<int>(type: "int", nullable: true),
                    H_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    H_ZIP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HOTEL__61F3893D4FB0689A", x => x.H_ID);
                });

            migrationBuilder.CreateTable(
                name: "ROOMTYPE",
                columns: table => new
                {
                    RT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RT_DES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RT_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RT_Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RT_SmokeFriendly = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    R_Area = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ROOMTYPE__4056367E2D56CACE", x => x.RT_ID);
                });

            migrationBuilder.CreateTable(
                name: "SERVICES",
                columns: table => new
                {
                    S_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    S_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    S_Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SERVICES__A3DFF16D6E06E772", x => x.S_ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRole_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRole_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    E_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    E_LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    E_Designation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    E_ContactNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    E_Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    E_JoinDate = table.Column<DateTime>(type: "date", nullable: true),
                    E_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DE_ID = table.Column<int>(type: "int", nullable: true),
                    H_ID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EMPLOYEE__D730AF543A07B3C3", x => x.E_ID);
                    table.ForeignKey(
                        name: "FK__EMPLOYEE__DE_ID__6D0D32F4",
                        column: x => x.DE_ID,
                        principalTable: "DEPARTMENT",
                        principalColumn: "DE_ID");
                    table.ForeignKey(
                        name: "FK__EMPLOYEE__H_ID__6E01572D",
                        column: x => x.H_ID,
                        principalTable: "HOTEL",
                        principalColumn: "H_ID");
                });

            migrationBuilder.CreateTable(
                name: "ROOM",
                columns: table => new
                {
                    R_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    R_Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RT_ID = table.Column<int>(type: "int", nullable: true),
                    R_Available = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ROOM__DE152E89CDA1DB90", x => x.R_ID);
                    table.ForeignKey(
                        name: "FK__ROOM__RT_ID__68487DD7",
                        column: x => x.RT_ID,
                        principalTable: "ROOMTYPE",
                        principalColumn: "RT_ID");
                });

            migrationBuilder.CreateTable(
                name: "BOOKING",
                columns: table => new
                {
                    B_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    B_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    B_StayDuration = table.Column<int>(type: "int", nullable: true),
                    B_CheckingDate = table.Column<DateTime>(type: "date", nullable: true),
                    B_CheckoutDate = table.Column<DateTime>(type: "date", nullable: true),
                    B_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    H_ID = table.Column<int>(type: "int", nullable: true),
                    E_ID = table.Column<int>(type: "int", nullable: true),
                    G_ID = table.Column<int>(type: "int", nullable: true),
                    D_ID = table.Column<int>(type: "int", nullable: true),
                    B_Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BOOKING__4B26EFE62E59BE7A", x => x.B_ID);
                    table.ForeignKey(
                        name: "FK__BOOKING__D_ID__75A278F5",
                        column: x => x.D_ID,
                        principalTable: "DISCOUNT",
                        principalColumn: "D_ID");
                    table.ForeignKey(
                        name: "FK__BOOKING__E_ID__73BA3083",
                        column: x => x.E_ID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "E_ID");
                    table.ForeignKey(
                        name: "FK__BOOKING__G_ID__74AE54BC",
                        column: x => x.G_ID,
                        principalTable: "GUEST",
                        principalColumn: "G_ID");
                    table.ForeignKey(
                        name: "FK__BOOKING__H_ID__72C60C4A",
                        column: x => x.H_ID,
                        principalTable: "HOTEL",
                        principalColumn: "H_ID");
                });

            migrationBuilder.CreateTable(
                name: "SALARY",
                columns: table => new
                {
                    Salary_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_ID = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Salary_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SALARY__D64E0E24600A4D58", x => x.Salary_ID);
                    table.ForeignKey(
                        name: "FK__SALARY__E_ID__04E4BC85",
                        column: x => x.E_ID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "E_ID");
                });

            migrationBuilder.CreateTable(
                name: "FEEDBACK",
                columns: table => new
                {
                    F_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F_Date = table.Column<DateTime>(type: "date", nullable: true),
                    F_Rate = table.Column<int>(type: "int", nullable: true),
                    G_ID = table.Column<int>(type: "int", nullable: true),
                    B_ID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FEEDBACK__2C6EC7C379E7FF2F", x => x.F_ID);
                    table.ForeignKey(
                        name: "FK__FEEDBACK__B_ID__08B54D69",
                        column: x => x.B_ID,
                        principalTable: "BOOKING",
                        principalColumn: "B_ID");
                    table.ForeignKey(
                        name: "FK__FEEDBACK__G_ID__07C12930",
                        column: x => x.G_ID,
                        principalTable: "GUEST",
                        principalColumn: "G_ID");
                });

            migrationBuilder.CreateTable(
                name: "PAYMENT",
                columns: table => new
                {
                    P_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P_Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    P_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    P_DatCoc = table.Column<DateTime>(type: "date", nullable: true),
                    P_Amout = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    B_ID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PAYMENT__A3420A77DE9AEC7C", x => x.P_ID);
                    table.ForeignKey(
                        name: "FK__PAYMENT__B_ID__02084FDA",
                        column: x => x.B_ID,
                        principalTable: "BOOKING",
                        principalColumn: "B_ID");
                });

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

            migrationBuilder.CreateTable(
                name: "SERVICESBOOKED",
                columns: table => new
                {
                    S_ID = table.Column<int>(type: "int", nullable: false),
                    B_ID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SERVICES__D76D9F93DCA2E309", x => new { x.S_ID, x.B_ID });
                    table.ForeignKey(
                        name: "FK__SERVICESBO__B_ID__7F2BE32F",
                        column: x => x.B_ID,
                        principalTable: "BOOKING",
                        principalColumn: "B_ID");
                    table.ForeignKey(
                        name: "FK__SERVICESBO__S_ID__7E37BEF6",
                        column: x => x.S_ID,
                        principalTable: "SERVICES",
                        principalColumn: "S_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_BOOKING_D_ID",
                table: "BOOKING",
                column: "D_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BOOKING_E_ID",
                table: "BOOKING",
                column: "E_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BOOKING_G_ID",
                table: "BOOKING",
                column: "G_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BOOKING_H_ID",
                table: "BOOKING",
                column: "H_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_DE_ID",
                table: "EMPLOYEE",
                column: "DE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_H_ID",
                table: "EMPLOYEE",
                column: "H_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FEEDBACK_B_ID",
                table: "FEEDBACK",
                column: "B_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FEEDBACK_G_ID",
                table: "FEEDBACK",
                column: "G_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENT_B_ID",
                table: "PAYMENT",
                column: "B_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ROOM_RT_ID",
                table: "ROOM",
                column: "RT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ROOMBOOKED_BId",
                table: "ROOMBOOKED",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_SALARY_E_ID",
                table: "SALARY",
                column: "E_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICESBOOKED_B_ID",
                table: "SERVICESBOOKED",
                column: "B_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRole");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FEEDBACK");

            migrationBuilder.DropTable(
                name: "PAYMENT");

            migrationBuilder.DropTable(
                name: "ROOMBOOKED");

            migrationBuilder.DropTable(
                name: "SALARY");

            migrationBuilder.DropTable(
                name: "SERVICESBOOKED");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ROOM");

            migrationBuilder.DropTable(
                name: "BOOKING");

            migrationBuilder.DropTable(
                name: "SERVICES");

            migrationBuilder.DropTable(
                name: "ROOMTYPE");

            migrationBuilder.DropTable(
                name: "DISCOUNT");

            migrationBuilder.DropTable(
                name: "EMPLOYEE");

            migrationBuilder.DropTable(
                name: "GUEST");

            migrationBuilder.DropTable(
                name: "DEPARTMENT");

            migrationBuilder.DropTable(
                name: "HOTEL");
        }
    }
}
