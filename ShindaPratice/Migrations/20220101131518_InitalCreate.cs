using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShindaPratice.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblActiveItem",
                columns: table => new
                {
                    cItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cItemName = table.Column<string>(nullable: true),
                    cActiveDt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblActiveItem", x => x.cItemID);
                });

            migrationBuilder.CreateTable(
                name: "tblSignup",
                columns: table => new
                {
                    cID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cMobile = table.Column<string>(nullable: true),
                    cName = table.Column<string>(nullable: true),
                    cEmail = table.Column<string>(nullable: true),
                    cCreateDt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSignup", x => x.cID);
                });

            migrationBuilder.CreateTable(
                name: "tblSignupItem",
                columns: table => new
                {
                    cSignupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cItemID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSignupItem", x => x.cSignupID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblActiveItem");

            migrationBuilder.DropTable(
                name: "tblSignup");

            migrationBuilder.DropTable(
                name: "tblSignupItem");
        }
    }
}
