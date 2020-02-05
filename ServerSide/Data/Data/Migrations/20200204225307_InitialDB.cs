using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FacebookId = table.Column<long>(nullable: true),
                    PictureUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditBorrows",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    PayDate = table.Column<DateTime>(nullable: false),
                    Pay = table.Column<decimal>(nullable: false),
                    WithdrawsDate = table.Column<DateTime>(nullable: false),
                    Withdraws = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditBorrows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCurrents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    PayDate = table.Column<DateTime>(nullable: false),
                    Pay = table.Column<decimal>(nullable: false),
                    WithdrawsDate = table.Column<DateTime>(nullable: false),
                    Withdraws = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCurrents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DebitBorrows",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    PayDate = table.Column<DateTime>(nullable: false),
                    Pay = table.Column<decimal>(nullable: false),
                    WithdrawsDate = table.Column<DateTime>(nullable: false),
                    Withdraws = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitBorrows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DebitCurrents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    PayDate = table.Column<DateTime>(nullable: false),
                    Pay = table.Column<decimal>(nullable: false),
                    WithdrawsDate = table.Column<DateTime>(nullable: false),
                    Withdraws = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitCurrents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    CarPlate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    OwnerName = table.Column<string>(nullable: true),
                    OwnerMobile = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reapers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    HeadName = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(nullable: false),
                    LastTonPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reapers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Safes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Incoming = table.Column<decimal>(nullable: false),
                    Outcoming = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Safes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    PayDate = table.Column<DateTime>(nullable: false),
                    Pay = table.Column<decimal>(nullable: false),
                    WithdrawsDate = table.Column<DateTime>(nullable: false),
                    Withdraws = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Selectors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    PayDate = table.Column<DateTime>(nullable: false),
                    Pay = table.Column<decimal>(nullable: false),
                    WithdrawsDate = table.Column<DateTime>(nullable: false),
                    Withdraws = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    OwnerName = table.Column<string>(nullable: true),
                    OwnerMobile = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityId = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Locale = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReaperDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    TonPrice = table.Column<decimal>(nullable: false),
                    PaidUp = table.Column<decimal>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: false),
                    ReaperId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReaperDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReaperDetails_Reapers_ReaperId",
                        column: x => x.ReaperId,
                        principalTable: "Reapers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CartNumber = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    FarmId = table.Column<long>(nullable: false),
                    DriverId = table.Column<long>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    KiloDiscount = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    KiloPrice = table.Column<decimal>(nullable: false),
                    MoneyDiscount = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    StationId = table.Column<long>(nullable: false),
                    PaidUp = table.Column<decimal>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: false),
                    RecieptNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incomes_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incomes_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incomes_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outcomes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CartNumber = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    StationId = table.Column<long>(nullable: false),
                    DriverId = table.Column<long>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    KiloDiscount = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    KiloPrice = table.Column<decimal>(nullable: false),
                    MoneyDiscount = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    FarmId = table.Column<long>(nullable: false),
                    PaidUp = table.Column<decimal>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: false),
                    RecieptNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outcomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outcomes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Outcomes_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Outcomes_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Outcomes_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    FarmId = table.Column<long>(nullable: false),
                    FarmOwnerName = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true),
                    DriverId = table.Column<long>(nullable: false),
                    CarPlate = table.Column<string>(nullable: true),
                    SupplierQuantity = table.Column<decimal>(nullable: false),
                    Pardon = table.Column<decimal>(nullable: false),
                    TotalAfterPardon = table.Column<decimal>(nullable: false),
                    SupplierPrice = table.Column<decimal>(nullable: false),
                    SupplierAmount = table.Column<decimal>(nullable: false),
                    Nolon = table.Column<decimal>(nullable: false),
                    ReaperId = table.Column<long>(nullable: false),
                    ReaperHead = table.Column<string>(nullable: true),
                    ReapersPay = table.Column<decimal>(nullable: false),
                    SelectorId = table.Column<long>(nullable: false),
                    SelectorsPay = table.Column<decimal>(nullable: false),
                    FarmExpense = table.Column<decimal>(nullable: false),
                    SupplierTotal = table.Column<decimal>(nullable: false),
                    StationId = table.Column<long>(nullable: false),
                    StationOwnerName = table.Column<string>(nullable: true),
                    CartNumber = table.Column<string>(nullable: true),
                    ClientQuantity = table.Column<decimal>(nullable: false),
                    ClientDiscount = table.Column<decimal>(nullable: false),
                    TotalAfterDiscount = table.Column<decimal>(nullable: false),
                    ClientPrice = table.Column<decimal>(nullable: false),
                    ClientTotal = table.Column<decimal>(nullable: false),
                    Sum = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Reapers_ReaperId",
                        column: x => x.ReaperId,
                        principalTable: "Reapers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DriverId = table.Column<long>(nullable: false),
                    FarmId = table.Column<long>(nullable: false),
                    StationId = table.Column<long>(nullable: false),
                    Nawlon = table.Column<decimal>(nullable: false),
                    Custody = table.Column<decimal>(nullable: false),
                    Withdraws = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfers_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transfers_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transfers_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                filter: "[NormalizedName] IS NOT NULL");

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
                table: "AspNetUserRoles",
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
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdentityId",
                table: "Customers",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_CategoryId",
                table: "Incomes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_DriverId",
                table: "Incomes",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_FarmId",
                table: "Incomes",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_StationId",
                table: "Incomes",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Outcomes_CategoryId",
                table: "Outcomes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Outcomes_DriverId",
                table: "Outcomes",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Outcomes_FarmId",
                table: "Outcomes",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Outcomes_StationId",
                table: "Outcomes",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReaperDetails_ReaperId",
                table: "ReaperDetails",
                column: "ReaperId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DriverId",
                table: "Transactions",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FarmId",
                table: "Transactions",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ReaperId",
                table: "Transactions",
                column: "ReaperId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StationId",
                table: "Transactions",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_DriverId",
                table: "Transfers",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_FarmId",
                table: "Transfers",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_StationId",
                table: "Transfers",
                column: "StationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CreditBorrows");

            migrationBuilder.DropTable(
                name: "CreditCurrents");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DebitBorrows");

            migrationBuilder.DropTable(
                name: "DebitCurrents");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Outcomes");

            migrationBuilder.DropTable(
                name: "ReaperDetails");

            migrationBuilder.DropTable(
                name: "Safes");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "Selectors");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Reapers");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
