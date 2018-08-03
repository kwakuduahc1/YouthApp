using Microsoft.EntityFrameworkCore.Migrations;

namespace YouthApp.Migrations
{
    public partial class YarGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassBills_Terms_TermsID",
                table: "ClassBills");

            migrationBuilder.AlterColumn<byte>(
                name: "TermsID",
                table: "ClassBills",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.AddColumn<short>(
                name: "YearGroup",
                table: "ClassBills",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassBills_Terms_TermsID",
                table: "ClassBills",
                column: "TermsID",
                principalTable: "Terms",
                principalColumn: "TermsID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassBills_Terms_TermsID",
                table: "ClassBills");

            migrationBuilder.DropColumn(
                name: "YearGroup",
                table: "ClassBills");

            migrationBuilder.AlterColumn<byte>(
                name: "TermsID",
                table: "ClassBills",
                nullable: false,
                oldClrType: typeof(byte),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassBills_Terms_TermsID",
                table: "ClassBills",
                column: "TermsID",
                principalTable: "Terms",
                principalColumn: "TermsID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
