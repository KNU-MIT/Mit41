using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class _1326 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Purchases_BookId",
                table: "Purchases",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Books_BookId",
                table: "Purchases",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Books_BookId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_BookId",
                table: "Purchases");
        }
    }
}
