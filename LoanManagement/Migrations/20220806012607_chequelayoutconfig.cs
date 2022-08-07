using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class chequelayoutconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChequeLayout",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    Name = table.Column<string>(type: "varchar(500)", nullable: true),
                    Width = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    XDate = table.Column<double>(nullable: false),
                    YDate = table.Column<double>(nullable: false),
                    XAmount = table.Column<double>(nullable: false),
                    YAmount = table.Column<double>(nullable: false),
                    XPayee = table.Column<double>(nullable: false),
                    YPayee = table.Column<double>(nullable: false),
                    XAmountInWordLine1 = table.Column<double>(nullable: false),
                    YAmountInWordLine1 = table.Column<double>(nullable: false),
                    XAmountInWordLine2 = table.Column<double>(nullable: false),
                    YAmountInWordLine2 = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChequeLayout", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChequeLayout",
                schema: "dbo");
        }
    }
}
