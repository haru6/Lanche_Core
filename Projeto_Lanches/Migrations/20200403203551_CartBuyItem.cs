using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lanches.Migrations
{
    public partial class CartBuyItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartBuyItens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    snackId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    CartBuyId = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartBuyItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartBuyItens_Snacks_snackId",
                        column: x => x.snackId,
                        principalTable: "Snacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartBuyItens_snackId",
                table: "CartBuyItens",
                column: "snackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartBuyItens");
        }
    }
}
