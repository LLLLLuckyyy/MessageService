using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageService.Resources.Api.Migrations
{
    public partial class BaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SendModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumberFrom = table.Column<string>(nullable: false),
                    PhoneNumberTo = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    AccountSid = table.Column<string>(nullable: false),
                    AuthToken = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateGetSentFrom = table.Column<DateTime>(nullable: false),
                    CountryGetSentFrom = table.Column<int>(nullable: false),
                    CountryGetSentTo = table.Column<int>(nullable: false),
                    PricePerMessage = table.Column<decimal>(nullable: false),
                    SendModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoModels_SendModels_SendModelId",
                        column: x => x.SendModelId,
                        principalTable: "SendModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InfoModels_SendModelId",
                table: "InfoModels",
                column: "SendModelId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoModels");

            migrationBuilder.DropTable(
                name: "SendModels");
        }
    }
}
