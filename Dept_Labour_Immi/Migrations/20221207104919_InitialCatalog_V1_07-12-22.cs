using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dept_Labour_Immi.Migrations
{
    public partial class InitialCatalog_V1_071222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LicenseEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BOD_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agencies", x => x.Id);
                });

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
                name: "countries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DOEs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DOE_NO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOE_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOEs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "serviceforThaiWorkers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PinkCardServiceCount = table.Column<int>(type: "int", nullable: true),
                    CICardServiceCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceforThaiWorkers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bODs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NRC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgencyID = table.Column<int>(type: "int", nullable: true),
                    RegionID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bODs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_bODs_agencies_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "agencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "penalties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Todate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    penaltyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgencyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_penalties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_penalties_agencies_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "thaiCompanies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgencyID = table.Column<int>(type: "int", nullable: true),
                    CompanyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thaiCompanies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_thaiCompanies_agencies_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "agencies",
                        principalColumn: "Id");
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
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                name: "internationalSendings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    AgencyID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfWorker = table.Column<int>(type: "int", nullable: false),
                    ServiceThaiWorkerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_internationalSendings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_internationalSendings_agencies_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_internationalSendings_countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_internationalSendings_serviceforThaiWorkers_ServiceThaiWorkerID",
                        column: x => x.ServiceThaiWorkerID,
                        principalTable: "serviceforThaiWorkers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "blacklists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Todate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    penaltyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgencyID = table.Column<int>(type: "int", nullable: true),
                    ThaiCompanyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blacklists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blacklists_agencies_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "agencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_blacklists_thaiCompanies_ThaiCompanyID",
                        column: x => x.ThaiCompanyID,
                        principalTable: "thaiCompanies",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "operation_1s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apply_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Document_Complete_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgencyID = table.Column<int>(type: "int", nullable: false),
                    ThaiCompanyID = table.Column<int>(type: "int", nullable: true),
                    DOEID = table.Column<int>(type: "int", nullable: false),
                    WorkType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaleWorkers = table.Column<int>(type: "int", nullable: false),
                    FemaleWorkers = table.Column<int>(type: "int", nullable: false),
                    TotalWorkers = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOEDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operation_1s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_operation_1s_agencies_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_operation_1s_DOEs_DOEID",
                        column: x => x.DOEID,
                        principalTable: "DOEs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_operation_1s_thaiCompanies_ThaiCompanyID",
                        column: x => x.ThaiCompanyID,
                        principalTable: "thaiCompanies",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "operation_2s",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apply_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contract_Request_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgencyID = table.Column<int>(type: "int", nullable: true),
                    ThaiCompanyID = table.Column<int>(type: "int", nullable: true),
                    DOEID = table.Column<int>(type: "int", nullable: false),
                    WorkType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Request_Male_Worker = table.Column<int>(type: "int", nullable: true),
                    Request_Female_Worker = table.Column<int>(type: "int", nullable: true),
                    Request_Total_Workers = table.Column<int>(type: "int", nullable: true),
                    Contract_Granted_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Permit_Male_Worker = table.Column<int>(type: "int", nullable: true),
                    Permit_Female_Worker = table.Column<int>(type: "int", nullable: true),
                    Permit_Total_Worker = table.Column<int>(type: "int", nullable: false),
                    Actual_Contract_Male_Worker = table.Column<int>(type: "int", nullable: false),
                    Actual_Contract_Female_Worker = table.Column<int>(type: "int", nullable: false),
                    Actual_Contract_Total_Worker = table.Column<int>(type: "int", nullable: true),
                    Remain_Male_Worker = table.Column<int>(type: "int", nullable: false),
                    Remain_Female_Worker = table.Column<int>(type: "int", nullable: false),
                    Remain_Total_Worker = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operation_2s", x => x.ID);
                    table.ForeignKey(
                        name: "FK_operation_2s_agencies_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "agencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_operation_2s_DOEs_DOEID",
                        column: x => x.DOEID,
                        principalTable: "DOEs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_operation_2s_thaiCompanies_ThaiCompanyID",
                        column: x => x.ThaiCompanyID,
                        principalTable: "thaiCompanies",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "thaiSendings",
                columns: table => new
                {
                    ThaiSendingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyID = table.Column<int>(type: "int", nullable: false),
                    ThaiCompanyID = table.Column<int>(type: "int", nullable: true),
                    CountOfThaiCompany = table.Column<int>(type: "int", nullable: false),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractSigningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OWICDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YangonDepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MWDAwaitingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureFromMWDDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestMaleWorker = table.Column<int>(type: "int", nullable: false),
                    RequestFemaleWorker = table.Column<int>(type: "int", nullable: false),
                    RequestTotalWorkers = table.Column<int>(type: "int", nullable: false),
                    PermitMaleWorker = table.Column<int>(type: "int", nullable: false),
                    PermitFemaleWorker = table.Column<int>(type: "int", nullable: false),
                    PermitTotalWorker = table.Column<int>(type: "int", nullable: false),
                    InchargePersonFromAgency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thaiSendings", x => x.ThaiSendingId);
                    table.ForeignKey(
                        name: "FK_thaiSendings_agencies_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_thaiSendings_thaiCompanies_ThaiCompanyID",
                        column: x => x.ThaiCompanyID,
                        principalTable: "thaiCompanies",
                        principalColumn: "ID");
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
                name: "IX_blacklists_AgencyID",
                table: "blacklists",
                column: "AgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_blacklists_ThaiCompanyID",
                table: "blacklists",
                column: "ThaiCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_bODs_AgencyID",
                table: "bODs",
                column: "AgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_internationalSendings_AgencyID",
                table: "internationalSendings",
                column: "AgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_internationalSendings_CountryID",
                table: "internationalSendings",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_internationalSendings_ServiceThaiWorkerID",
                table: "internationalSendings",
                column: "ServiceThaiWorkerID");

            migrationBuilder.CreateIndex(
                name: "IX_operation_1s_AgencyID",
                table: "operation_1s",
                column: "AgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_operation_1s_DOEID",
                table: "operation_1s",
                column: "DOEID");

            migrationBuilder.CreateIndex(
                name: "IX_operation_1s_ThaiCompanyID",
                table: "operation_1s",
                column: "ThaiCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_operation_2s_AgencyID",
                table: "operation_2s",
                column: "AgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_operation_2s_DOEID",
                table: "operation_2s",
                column: "DOEID");

            migrationBuilder.CreateIndex(
                name: "IX_operation_2s_ThaiCompanyID",
                table: "operation_2s",
                column: "ThaiCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_penalties_AgencyID",
                table: "penalties",
                column: "AgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_thaiCompanies_AgencyID",
                table: "thaiCompanies",
                column: "AgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_thaiSendings_AgencyID",
                table: "thaiSendings",
                column: "AgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_thaiSendings_ThaiCompanyID",
                table: "thaiSendings",
                column: "ThaiCompanyID");
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
                name: "blacklists");

            migrationBuilder.DropTable(
                name: "bODs");

            migrationBuilder.DropTable(
                name: "internationalSendings");

            migrationBuilder.DropTable(
                name: "operation_1s");

            migrationBuilder.DropTable(
                name: "operation_2s");

            migrationBuilder.DropTable(
                name: "penalties");

            migrationBuilder.DropTable(
                name: "thaiSendings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "serviceforThaiWorkers");

            migrationBuilder.DropTable(
                name: "DOEs");

            migrationBuilder.DropTable(
                name: "thaiCompanies");

            migrationBuilder.DropTable(
                name: "agencies");
        }
    }
}
