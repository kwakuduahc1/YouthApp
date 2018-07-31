using Microsoft.EntityFrameworkCore.Migrations;

namespace YouthApp.Migrations
{
    public partial class GCR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GCR",
                table: "IndividualBills",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GCR",
                table: "IndividualBills");
        }
    }
}
