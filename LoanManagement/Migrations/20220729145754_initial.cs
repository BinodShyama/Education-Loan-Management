using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Member",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    CustomMemberId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    NationalIdentiryCardNumber = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    BirthofDateBS = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    BirthOfDateAD = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    Nationality = table.Column<string>(nullable: true),
                    CitizenShipNumber = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CitizenIssuedDateBS = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CitizenIssuedDateAD = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    CitizenIssuedDistrict = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PermanentState = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PermanentDistrict = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PermanentMunicipality = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PermanentWardNumber = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    PermanentStreet = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PermanentHouseNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TemporaryState = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TemporaryDistrict = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TemporaryMunicipality = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TemporaryWardNumber = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TemporaryStreet = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TemporaryHouseNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FatherFullName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MotherFullName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    GrandFatherFullName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SpouseFullName = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    GroupId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PermissionGroup = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroup",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Identifier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Identifier = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    MemberId = table.Column<string>(nullable: true),
                    VoucherNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    VoucherDateNep = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    VoucherDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    Particular = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Note = table.Column<string>(nullable: true),
                    VoucherIndex = table.Column<int>(nullable: false),
                    FisicalYearId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
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
                    Status = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    LastActive = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberLoanDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    LoanAccountNo = table.Column<string>(nullable: true),
                    SerialNo = table.Column<int>(nullable: false),
                    LoanGuarantorName = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    LoanGuarantorRelationship = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LoanGuarantorContactNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LoanGuarantorCitizenshipNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LoanGuarantorCitizenshipIssueDistrict = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Degree = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Institution = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    University = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Duration = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    DateOfCommencementNep = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DateOfCommencement = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    LoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoanMaturityDateNep = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LoanMaturityDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    Installment1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Installment2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Installment3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MemberId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberLoanDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberLoanDetail_Member_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "dbo",
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "District",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "dbo",
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                schema: "dbo",
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
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false),
                    PermissionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "dbo",
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    TransactionId = table.Column<string>(nullable: true),
                    Particular = table.Column<string>(nullable: true),
                    DrAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CrAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    FisicalYearId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionDetail_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalSchema: "dbo",
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                schema: "dbo",
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
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanCollection",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    DateNep = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    VoucherNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LoanAc = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MemberId = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    ChequeDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ChequeNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ChequeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    MemberLoanDetailId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanCollection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanCollection_Member_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "dbo",
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanCollection_MemberLoanDetail_MemberLoanDetailId",
                        column: x => x.MemberLoanDetailId,
                        principalSchema: "dbo",
                        principalTable: "MemberLoanDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanDisbrusement",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    VoucherDateNep = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    VoucherDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    VoucherNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LoanAc = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MemberId = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    ChequeDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ChequeNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ChequeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    MemberLoanDetailId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDisbrusement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanDisbrusement_Member_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "dbo",
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanDisbrusement_MemberLoanDetail_MemberLoanDetailId",
                        column: x => x.MemberLoanDetailId,
                        principalSchema: "dbo",
                        principalTable: "MemberLoanDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberLoanInstallment",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    LoanAcNo = table.Column<string>(nullable: true),
                    InstallmentNo = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MemberLoanDetailId = table.Column<string>(nullable: true),
                    Disbrused = table.Column<bool>(nullable: false),
                    DisbrusedDate = table.Column<DateTime>(type: "datetime2(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberLoanInstallment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberLoanInstallment_MemberLoanDetail_MemberLoanDetailId",
                        column: x => x.MemberLoanDetailId,
                        principalSchema: "dbo",
                        principalTable: "MemberLoanDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Municipality",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DistrinctId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipality_District_DistrinctId",
                        column: x => x.DistrinctId,
                        principalSchema: "dbo",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanCollectionDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    LoanCollectionId = table.Column<string>(nullable: true),
                    VoucherNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanCollectionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanCollectionDetail_LoanCollection_LoanCollectionId",
                        column: x => x.LoanCollectionId,
                        principalSchema: "dbo",
                        principalTable: "LoanCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanDisbrusementDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    DisbrusementId = table.Column<string>(nullable: true),
                    VoucherNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    InstallmentId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDisbrusementDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanDisbrusementDetail_LoanDisbrusement_DisbrusementId",
                        column: x => x.DisbrusementId,
                        principalSchema: "dbo",
                        principalTable: "LoanDisbrusement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanDisbrusementDetail_MemberLoanInstallment_InstallmentId",
                        column: x => x.InstallmentId,
                        principalSchema: "dbo",
                        principalTable: "MemberLoanInstallment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Province No. 1" },
                    { 2, "Province No. 2" },
                    { 3, "Bagmati" },
                    { 4, "Gandaki" },
                    { 5, "Lumbini" },
                    { 6, "Karnali" },
                    { 7, "Sudur-Paschim Province" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "Bhojpur", 1 },
                    { 55, "Pyuthan", 5 },
                    { 54, "Palpa", 5 },
                    { 53, "Nawalparasi (Bardaghat Susta Paschim)", 5 },
                    { 52, "Kapilvastu", 5 },
                    { 51, "Gulmi", 5 },
                    { 50, "Dang", 5 },
                    { 49, "Bardiya", 5 },
                    { 48, "Banke", 5 },
                    { 47, "Arghakhanchi", 5 },
                    { 46, "Tanahu", 4 },
                    { 45, "Syangja", 4 },
                    { 44, "Parbat", 4 },
                    { 43, "Nawalparasi (Bardaghat Susta Purva)", 4 },
                    { 42, "Myagdi", 4 },
                    { 41, "Mustang", 4 },
                    { 56, "Rolpa", 5 },
                    { 57, "Purbi Rukum", 5 },
                    { 58, "Rupandehi", 5 },
                    { 59, "Dailekh", 6 },
                    { 75, "Doti", 7 },
                    { 74, "Darchula", 7 },
                    { 73, "Dadeldhura", 7 },
                    { 72, "Bajura", 7 },
                    { 71, "Bajhang", 7 },
                    { 70, "Baitadi", 7 },
                    { 69, "Achham", 7 },
                    { 40, "Manang", 4 },
                    { 68, "Surkhet", 6 },
                    { 66, "Rukum Paschim", 6 },
                    { 65, "Mugu", 6 },
                    { 64, "Kalikot", 6 },
                    { 63, "Jumla", 6 },
                    { 62, "Jajarkot", 6 },
                    { 61, "Humla", 6 },
                    { 60, "Dolpa", 6 },
                    { 67, "Salyan", 6 },
                    { 76, "Kailali", 7 },
                    { 39, "Lamjung", 4 },
                    { 37, "Gorkha", 4 },
                    { 16, "Dhanusa", 2 },
                    { 15, "Bara", 2 },
                    { 14, "Udayapur", 1 },
                    { 13, "Terhathum", 1 },
                    { 12, "Taplejung", 1 },
                    { 11, "Sunsari", 1 },
                    { 10, "Solukhumbu", 1 },
                    { 9, "Sankhuwasabha", 1 },
                    { 8, "Panchthar", 1 },
                    { 7, "Okhaldhunga", 1 },
                    { 6, "Morang", 1 },
                    { 5, "Khotang", 1 },
                    { 4, "Jhapa", 1 },
                    { 3, "Ilam", 1 },
                    { 2, "Dhankuta", 1 },
                    { 17, "Mahottari", 2 },
                    { 18, "Parsa", 2 },
                    { 19, "Rautahat", 2 },
                    { 20, "Saptari", 2 },
                    { 36, "Baglung", 4 },
                    { 35, "Sindhupalchok", 3 },
                    { 34, "Sindhuli", 3 },
                    { 33, "Rasuwa", 3 },
                    { 32, "Ramechhap", 3 },
                    { 31, "Nuwakot", 3 },
                    { 30, "Makawanpur", 3 },
                    { 38, "Kaski", 4 },
                    { 29, "Lalitpur", 3 },
                    { 27, "Kathmandu", 3 },
                    { 26, "Dolakha", 3 },
                    { 25, "Dhading", 3 },
                    { 24, "Chitwan", 3 },
                    { 23, "Bhaktapur", 3 },
                    { 22, "Siraha", 2 },
                    { 21, "Sarlahi", 2 },
                    { 28, "Kavrepalanchok", 3 },
                    { 77, "Kanchanpur", 7 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Municipality",
                columns: new[] { "Id", "DistrinctId", "Name" },
                values: new object[] { 4, 23, "SURYABINAYAK MUNICIPALITY" });

            migrationBuilder.CreateIndex(
                name: "IX_District_ProvinceId",
                schema: "dbo",
                table: "District",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanCollection_MemberId",
                schema: "dbo",
                table: "LoanCollection",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanCollection_MemberLoanDetailId",
                schema: "dbo",
                table: "LoanCollection",
                column: "MemberLoanDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanCollectionDetail_LoanCollectionId",
                schema: "dbo",
                table: "LoanCollectionDetail",
                column: "LoanCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanDisbrusement_MemberId",
                schema: "dbo",
                table: "LoanDisbrusement",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanDisbrusement_MemberLoanDetailId",
                schema: "dbo",
                table: "LoanDisbrusement",
                column: "MemberLoanDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanDisbrusementDetail_DisbrusementId",
                schema: "dbo",
                table: "LoanDisbrusementDetail",
                column: "DisbrusementId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanDisbrusementDetail_InstallmentId",
                schema: "dbo",
                table: "LoanDisbrusementDetail",
                column: "InstallmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberLoanDetail_MemberId",
                schema: "dbo",
                table: "MemberLoanDetail",
                column: "MemberId",
                unique: true,
                filter: "[MemberId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MemberLoanInstallment_MemberLoanDetailId",
                schema: "dbo",
                table: "MemberLoanInstallment",
                column: "MemberLoanDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipality_DistrinctId",
                schema: "dbo",
                table: "Municipality",
                column: "DistrinctId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                schema: "dbo",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                schema: "dbo",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                schema: "dbo",
                table: "RolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetail_TransactionId",
                schema: "dbo",
                table: "TransactionDetail",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                schema: "dbo",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                schema: "dbo",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "dbo",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanCollectionDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LoanDisbrusementDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Municipality",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PermissionGroup",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleClaim",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RolePermission",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TransactionDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserClaim",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserLogin",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserToken",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LoanCollection",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LoanDisbrusement",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MemberLoanInstallment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "District",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MemberLoanDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Province",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Member",
                schema: "dbo");
        }
    }
}
