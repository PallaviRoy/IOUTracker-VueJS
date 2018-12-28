using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackYourIOU.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LoanAmount = table.Column<double>(nullable: false),
                    NameOfBorrower = table.Column<string>(nullable: true),
                    LoanedDate = table.Column<DateTime>(nullable: false),
                    RepaymentDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loan");
        }
    }
}
