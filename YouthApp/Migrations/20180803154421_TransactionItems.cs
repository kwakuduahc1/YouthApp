using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YouthApp.Migrations
{
    public partial class TransactionItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "TransactionItemsID",
                table: "Transactions",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateTable(
                name: "TransactionItems",
                columns: table => new
                {
                    TransactionItemsID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransactionItem = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionItems", x => x.TransactionItemsID);
                });

            migrationBuilder.InsertData(
                table: "Revenues",
                columns: new[] { "RevenuesID", "AccountName", "AccountNumber", "Bank", "Source" },
                values: new object[,]
                {
                    { (short)1, "NYLSTC", "558964523", "Agricultural Development Bank", "GOG" },
                    { (short)2, "NYLSTC", "09876547", "Tisungtaba", "IGF" }
                });

            migrationBuilder.InsertData(
                table: "TransactionItems",
                columns: new[] { "TransactionItemsID", "TransactionItem" },
                values: new object[,]
                {
                    { (short)1, "T&T" },
                    { (short)2, "Fuel" },
                    { (short)3, "Bank Charges" },
                    { (short)4, "Maintenance" },
                    { (short)5, "Staff Allowances" },
                    { (short)6, "Stationery" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionItemsID",
                table: "Transactions",
                column: "TransactionItemsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionItems_TransactionItemsID",
                table: "Transactions",
                column: "TransactionItemsID",
                principalTable: "TransactionItems",
                principalColumn: "TransactionItemsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionItems_TransactionItemsID",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionItems");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransactionItemsID",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "Revenues",
                keyColumn: "RevenuesID",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "Revenues",
                keyColumn: "RevenuesID",
                keyValue: (short)2);

            migrationBuilder.DropColumn(
                name: "TransactionItemsID",
                table: "Transactions");
        }
    }
}
