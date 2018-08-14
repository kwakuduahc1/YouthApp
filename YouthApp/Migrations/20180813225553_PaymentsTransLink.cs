using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YouthApp.Migrations
{
    public partial class PaymentsTransLink : Migration
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
                name: "Programs",
                columns: table => new
                {
                    ProgramsID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProgramName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.ProgramsID);
                });

            migrationBuilder.CreateTable(
                name: "Revenues",
                columns: table => new
                {
                    RevenuesID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountName = table.Column<string>(maxLength: 100, nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Source = table.Column<string>(maxLength: 10, nullable: false),
                    Bank = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenues", x => x.RevenuesID);
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
                name: "TransactionItems",
                columns: table => new
                {
                    TransactionItemsID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TransactionItem = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionItems", x => x.TransactionItemsID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionsTypes",
                columns: table => new
                {
                    TransactionsTypesID = table.Column<byte>(nullable: false),
                    TransactionType = table.Column<string>(maxLength: 15, nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionsTypes", x => x.TransactionsTypesID);
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
                name: "Classes",
                columns: table => new
                {
                    ClassesID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProgramsID = table.Column<short>(nullable: false),
                    ClassName = table.Column<string>(maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AddYear = table.Column<short>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassesID);
                    table.ForeignKey(
                        name: "FK_Classes_Programs_ProgramsID",
                        column: x => x.ProgramsID,
                        principalTable: "Programs",
                        principalColumn: "ProgramsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionsID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<double>(nullable: false),
                    IsStudent = table.Column<bool>(nullable: false),
                    Purpose = table.Column<string>(maxLength: 100, nullable: false),
                    RevenuesID = table.Column<short>(nullable: false),
                    TransactionsTypesID = table.Column<byte>(nullable: false),
                    TransactionItemsID = table.Column<short>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionsID);
                    table.ForeignKey(
                        name: "FK_Transactions_Revenues_RevenuesID",
                        column: x => x.RevenuesID,
                        principalTable: "Revenues",
                        principalColumn: "RevenuesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionItems_TransactionItemsID",
                        column: x => x.TransactionItemsID,
                        principalTable: "TransactionItems",
                        principalColumn: "TransactionItemsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionsTypes_TransactionsTypesID",
                        column: x => x.TransactionsTypesID,
                        principalTable: "TransactionsTypes",
                        principalColumn: "TransactionsTypesID",
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
                    TermsID = table.Column<byte>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    YearGroup = table.Column<short>(nullable: false),
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
                name: "Students",
                columns: table => new
                {
                    StudentsID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UniqueID = table.Column<string>(maxLength: 20, nullable: true),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<string>(maxLength: 7, nullable: false),
                    Level = table.Column<string>(maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ClassesID = table.Column<int>(nullable: false),
                    OtherNames = table.Column<string>(maxLength: 50, nullable: true),
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
                name: "IndividualBills",
                columns: table => new
                {
                    IndividualBillsID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentsID = table.Column<long>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    GCR = table.Column<string>(maxLength: 20, nullable: true),
                    DateBilled = table.Column<DateTime>(nullable: false),
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
                    StudentsID = table.Column<long>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    DatePaid = table.Column<DateTime>(nullable: false),
                    Receiver = table.Column<string>(maxLength: 50, nullable: true),
                    GCR = table.Column<string>(maxLength: 20, nullable: false),
                    TransactionsID = table.Column<long>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Payments_Transactions_TransactionsID",
                        column: x => x.TransactionsID,
                        principalTable: "Transactions",
                        principalColumn: "TransactionsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsInfo",
                columns: table => new
                {
                    StudentsID = table.Column<long>(nullable: false),
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
                values: new object[] { 1, "Admission Fee", null, null });

            migrationBuilder.InsertData(
                table: "BillItems",
                columns: new[] { "BillItemsID", "BillItem", "Concurrency", "Description" },
                values: new object[] { 2, "Development", null, null });

            migrationBuilder.InsertData(
                table: "BillItems",
                columns: new[] { "BillItemsID", "BillItem", "Concurrency", "Description" },
                values: new object[] { 3, "Examination Fee : Internal (Per term)", null, null });

            migrationBuilder.InsertData(
                table: "BillItems",
                columns: new[] { "BillItemsID", "BillItem", "Concurrency", "Description" },
                values: new object[] { 4, "Sports fee : (Per term)", null, null });

            migrationBuilder.InsertData(
                table: "BillItems",
                columns: new[] { "BillItemsID", "BillItem", "Concurrency", "Description" },
                values: new object[] { 5, "Utility Charges : (Per term)", null, null });

            migrationBuilder.InsertData(
                table: "BillItems",
                columns: new[] { "BillItemsID", "BillItem", "Concurrency", "Description" },
                values: new object[] { 6, "ID/Exeat Card", null, null });

            migrationBuilder.InsertData(
                table: "BillItems",
                columns: new[] { "BillItemsID", "BillItem", "Concurrency", "Description" },
                values: new object[] { 7, "School Badge", null, null });

            migrationBuilder.InsertData(
                table: "BillItems",
                columns: new[] { "BillItemsID", "BillItem", "Concurrency", "Description" },
                values: new object[] { 8, "First Aid : (Per term)", null, null });

            migrationBuilder.InsertData(
                table: "BillItems",
                columns: new[] { "BillItemsID", "BillItem", "Concurrency", "Description" },
                values: new object[] { 9, "ICT : (Per term)", null, null });

            migrationBuilder.InsertData(
                table: "BillItems",
                columns: new[] { "BillItemsID", "BillItem", "Concurrency", "Description" },
                values: new object[] { 10, "Damages : (Per term)", null, null });

            migrationBuilder.InsertData(
                table: "BillItems",
                columns: new[] { "BillItemsID", "BillItem", "Concurrency", "Description" },
                values: new object[] { 11, "Bed User Fees", null, null });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramsID", "ProgramName" },
                values: new object[] { (short)7, "ELECTRICAL DEPARTMENT" });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramsID", "ProgramName" },
                values: new object[] { (short)6, "HANDWEAVING DEPARTMENT" });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramsID", "ProgramName" },
                values: new object[] { (short)5, "AGRICULTURE DEPARTMENT" });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramsID", "ProgramName" },
                values: new object[] { (short)1, "Dress Making" });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramsID", "ProgramName" },
                values: new object[] { (short)3, "CARPENTRY & JOINERY DEPARTMENT" });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramsID", "ProgramName" },
                values: new object[] { (short)2, "Masonry" });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramsID", "ProgramName" },
                values: new object[] { (short)4, "COOKERY DEPARTMENT" });

            migrationBuilder.InsertData(
                table: "Revenues",
                columns: new[] { "RevenuesID", "AccountName", "AccountNumber", "Bank", "Source" },
                values: new object[] { (short)1, "Youth Leadership Training Institute", "3511120000037491", "Tisutaaba Community Bank", "GOG" });

            migrationBuilder.InsertData(
                table: "Revenues",
                columns: new[] { "RevenuesID", "AccountName", "AccountNumber", "Bank", "Source" },
                values: new object[] { (short)2, "Youth Leadership Institute", "9011130007251", "GCB Bank Limited", "IGF" });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)7, "Year 3 term 1", 3.1f });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)9, "Year 3 term 3", 3.3f });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)8, "Year 3 term 2", 3.2f });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)6, "Year 2 term 3", 2.3f });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)2, "Year 1 term 2", 1.2f });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)4, "Year 2 term 1", 2.1f });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)3, "Year 1 term 3", 1.3f });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)1, "Year 1 term 1", 1.1f });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermsID", "Description", "Term" },
                values: new object[] { (byte)5, "Year 2 term 2", 2.2f });

            migrationBuilder.InsertData(
                table: "TransactionItems",
                columns: new[] { "TransactionItemsID", "TransactionItem" },
                values: new object[] { (short)12, "Salary Advances" });

            migrationBuilder.InsertData(
                table: "TransactionItems",
                columns: new[] { "TransactionItemsID", "TransactionItem" },
                values: new object[] { (short)11, "Administration Grants" });

            migrationBuilder.InsertData(
                table: "TransactionItems",
                columns: new[] { "TransactionItemsID", "TransactionItem" },
                values: new object[] { (short)10, "Feeding Grants" });

            migrationBuilder.InsertData(
                table: "TransactionItems",
                columns: new[] { "TransactionItemsID", "TransactionItem" },
                values: new object[] { (short)9, "NVTI Registration" });

            migrationBuilder.InsertData(
                table: "TransactionItems",
                columns: new[] { "TransactionItemsID", "TransactionItem" },
                values: new object[] { (short)8, "Imprest" });

            migrationBuilder.InsertData(
                table: "TransactionItems",
                columns: new[] { "TransactionItemsID", "TransactionItem" },
                values: new object[] { (short)7, "School Fees" });

            migrationBuilder.InsertData(
                table: "TransactionItems",
                columns: new[] { "TransactionItemsID", "TransactionItem" },
                values: new object[] { (short)5, "Staff Allowances" });

            migrationBuilder.InsertData(
                table: "TransactionItems",
                columns: new[] { "TransactionItemsID", "TransactionItem" },
                values: new object[] { (short)4, "Repairs and Maintenance" });

            migrationBuilder.InsertData(
                table: "TransactionItems",
                columns: new[] { "TransactionItemsID", "TransactionItem" },
                values: new object[] { (short)3, "Bank Charges" });

            migrationBuilder.InsertData(
                table: "TransactionItems",
                columns: new[] { "TransactionItemsID", "TransactionItem" },
                values: new object[] { (short)2, "Fuel" });

            migrationBuilder.InsertData(
                table: "TransactionItems",
                columns: new[] { "TransactionItemsID", "TransactionItem" },
                values: new object[] { (short)1, "T&T" });

            migrationBuilder.InsertData(
                table: "TransactionItems",
                columns: new[] { "TransactionItemsID", "TransactionItem" },
                values: new object[] { (short)6, "Stationery" });

            migrationBuilder.InsertData(
                table: "TransactionsTypes",
                columns: new[] { "TransactionsTypesID", "Concurrency", "TransactionType" },
                values: new object[] { (byte)1, null, "Revenue" });

            migrationBuilder.InsertData(
                table: "TransactionsTypes",
                columns: new[] { "TransactionsTypesID", "Concurrency", "TransactionType" },
                values: new object[] { (byte)2, null, "Expenditure" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "AddYear", "ClassName", "Concurrency", "IsActive", "ProgramsID" },
                values: new object[] { 1, (short)2017, "DM17", null, true, (short)1 });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "AddYear", "ClassName", "Concurrency", "IsActive", "ProgramsID" },
                values: new object[] { 2, (short)2018, "DM18", null, true, (short)1 });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "AddYear", "ClassName", "Concurrency", "IsActive", "ProgramsID" },
                values: new object[] { 3, (short)2017, "MS17", null, true, (short)2 });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "AddYear", "ClassName", "Concurrency", "IsActive", "ProgramsID" },
                values: new object[] { 4, (short)2018, "MS18", null, true, (short)2 });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "AddYear", "ClassName", "Concurrency", "IsActive", "ProgramsID" },
                values: new object[] { 5, (short)2017, "CJ17", null, true, (short)3 });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "AddYear", "ClassName", "Concurrency", "IsActive", "ProgramsID" },
                values: new object[] { 6, (short)2018, "CJ18", null, true, (short)3 });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "AddYear", "ClassName", "Concurrency", "IsActive", "ProgramsID" },
                values: new object[] { 7, (short)2017, "COOK17", null, true, (short)4 });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "AddYear", "ClassName", "Concurrency", "IsActive", "ProgramsID" },
                values: new object[] { 8, (short)2018, "COOK18", null, true, (short)4 });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "AddYear", "ClassName", "Concurrency", "IsActive", "ProgramsID" },
                values: new object[] { 9, (short)2017, "AG17", null, true, (short)5 });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "AddYear", "ClassName", "Concurrency", "IsActive", "ProgramsID" },
                values: new object[] { 10, (short)2018, "AG18", null, true, (short)5 });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "AddYear", "ClassName", "Concurrency", "IsActive", "ProgramsID" },
                values: new object[] { 15, (short)2016, "AG16", null, true, (short)5 });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "AddYear", "ClassName", "Concurrency", "IsActive", "ProgramsID" },
                values: new object[] { 11, (short)2017, "HND17", null, true, (short)6 });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "AddYear", "ClassName", "Concurrency", "IsActive", "ProgramsID" },
                values: new object[] { 12, (short)2018, "HND18", null, true, (short)6 });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "AddYear", "ClassName", "Concurrency", "IsActive", "ProgramsID" },
                values: new object[] { 13, (short)2017, "ELEC17", null, true, (short)7 });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassesID", "AddYear", "ClassName", "Concurrency", "IsActive", "ProgramsID" },
                values: new object[] { 14, (short)2018, "ELEC18", null, true, (short)7 });

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
                name: "IX_Classes_ProgramsID",
                table: "Classes",
                column: "ProgramsID");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualBills_StudentsID",
                table: "IndividualBills",
                column: "StudentsID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_StudentsID",
                table: "Payments",
                column: "StudentsID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TransactionsID",
                table: "Payments",
                column: "TransactionsID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassesID",
                table: "Students",
                column: "ClassesID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_RevenuesID",
                table: "Transactions",
                column: "RevenuesID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionItemsID",
                table: "Transactions",
                column: "TransactionItemsID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionsTypesID",
                table: "Transactions",
                column: "TransactionsTypesID");
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
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Revenues");

            migrationBuilder.DropTable(
                name: "TransactionItems");

            migrationBuilder.DropTable(
                name: "TransactionsTypes");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Programs");
        }
    }
}
