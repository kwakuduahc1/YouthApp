using Microsoft.EntityFrameworkCore.Migrations;

namespace YouthApp.Migrations
{
    public partial class PayTranFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_TransactionsID",
                table: "Payments");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TransactionsID",
                table: "Payments",
                column: "TransactionsID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_TransactionsID",
                table: "Payments");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TransactionsID",
                table: "Payments",
                column: "TransactionsID");
        }
    }
}
