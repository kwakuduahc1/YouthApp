using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YouthApp.Migrations
{
    public partial class Terms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillItems",
                columns: table => new
                {
                    BillItemsID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BillItem = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillItems", x => x.BillItemsID);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassesID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassName = table.Column<string>(maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassesID);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    TermsID = table.Column<byte>(nullable: false),
                    Term = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.TermsID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentsID = table.Column<Guid>(nullable: false),
                    UniqueID = table.Column<string>(maxLength: 20, nullable: true),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    ClassesID = table.Column<int>(nullable: false),
                    OtherNames = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateRegistered = table.Column<DateTime>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentsID);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassesID",
                        column: x => x.ClassesID,
                        principalTable: "Classes",
                        principalColumn: "ClassesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassBills",
                columns: table => new
                {
                    ClassBillsID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BillItemsID = table.Column<int>(nullable: false),
                    ClassesID = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    TermsID = table.Column<byte>(nullable: false),
                    Year = table.Column<string>(nullable: false),
                    DatePrepared = table.Column<DateTime>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassBills", x => x.ClassBillsID);
                    table.ForeignKey(
                        name: "FK_ClassBills_BillItems_BillItemsID",
                        column: x => x.BillItemsID,
                        principalTable: "BillItems",
                        principalColumn: "BillItemsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassBills_Classes_ClassesID",
                        column: x => x.ClassesID,
                        principalTable: "Classes",
                        principalColumn: "ClassesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassBills_Terms_TermsID",
                        column: x => x.TermsID,
                        principalTable: "Terms",
                        principalColumn: "TermsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualBills",
                columns: table => new
                {
                    IndividualBillsID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentsID = table.Column<Guid>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    TermsID = table.Column<byte>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualBills", x => x.IndividualBillsID);
                    table.ForeignKey(
                        name: "FK_IndividualBills_Students_StudentsID",
                        column: x => x.StudentsID,
                        principalTable: "Students",
                        principalColumn: "StudentsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentsID = table.Column<Guid>(nullable: false),
                    StudentsID = table.Column<Guid>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    DatePaid = table.Column<DateTime>(nullable: false),
                    Receiver = table.Column<string>(maxLength: 50, nullable: true),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentsID);
                    table.ForeignKey(
                        name: "FK_Payments_Students_StudentsID",
                        column: x => x.StudentsID,
                        principalTable: "Students",
                        principalColumn: "StudentsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsInfo",
                columns: table => new
                {
                    StudentsID = table.Column<Guid>(nullable: false),
                    Mother = table.Column<string>(maxLength: 100, nullable: false),
                    Father = table.Column<string>(maxLength: 100, nullable: false),
                    PlaceOfBirth = table.Column<string>(maxLength: 100, nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsInfo", x => x.StudentsID);
                    table.ForeignKey(
                        name: "FK_StudentsInfo_Students_StudentsID",
                        column: x => x.StudentsID,
                        principalTable: "Students",
                        principalColumn: "StudentsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BillItems",
                columns: new[] { "BillItemsID", "BillItem", "Concurrency", "Description" },
                values: new object[] { 1, "Feeding", null, null });

            migrationBuilder.InsertData(
                table: "BillItems",
                columns: new[] { "BillItemsID", "BillItem", "Concurrency", "Description" },
                values: new object[] { 2, "PTA Dues", null, null });

            migrationBuilder.InsertData(
                table: "BillItems",
                columns: new[] { "BillItemsID", "BillItem", "Concurrency", "Description" },
                values: new object[] { 3, "Boarding fees", null, null });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "ClassName", "Concurrency", "IsActive" },
                values: new object[] { 1, "Tech 2017", null, true });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "ClassName", "Concurrency", "IsActive" },
                values: new object[] { 2, "Tech 2018", null, true });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "ClassName", "Concurrency", "IsActive" },
                values: new object[] { 3, "Tech 2019", null, true });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)1, "Year 1 term 1", 1.1f });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)2, "Year 1 term 2", 1.2f });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)3, "Year 1 term 3", 1.3f });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)4, "Year 2 term 1", 2.1f });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)5, "Year 2 term 2", 2.2f });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)6, "Year 2 term 3", 2.3f });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)7, "Year 3 term 1", 3.1f });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)8, "Year 3 term 2", 3.2f });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)9, "Year 3 term 3", 3.3f });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassBills_BillItemsID",
                table: "ClassBills",
                column: "BillItemsID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassBills_ClassesID",
                table: "ClassBills",
                column: "ClassesID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassBills_TermsID",
                table: "ClassBills",
                column: "TermsID");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualBills_StudentsID",
                table: "IndividualBills",
                column: "StudentsID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_StudentsID",
                table: "Payments",
                column: "StudentsID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassesID",
                table: "Students",
                column: "ClassesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClassBills");

            migrationBuilder.DropTable(
                name: "IndividualBills");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "StudentsInfo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BillItems");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
