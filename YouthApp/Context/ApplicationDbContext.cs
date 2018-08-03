using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YouthApp.Models;

namespace YouthApp.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=database.db;", (o => o.UseRelationalNulls(true).SuppressForeignKeyEnforcement(false)));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Programs>(x => x.HasData(
                new Programs { ProgramsID = 1, ProgramName = "Dress Making" },
                new Programs { ProgramsID = 2, ProgramName = "Masonry" },
                new Programs { ProgramsID = 3, ProgramName = "CARPENTRY & JOINERY DEPARTMENT" },
                new Programs { ProgramsID = 4, ProgramName = "COOKERY DEPARTMENT" },
                new Programs { ProgramsID = 5, ProgramName = "AGRICULTURE DEPARTMENT" },
                new Programs { ProgramsID = 6, ProgramName = "HANDWEAVING DEPARTMENT" },
                new Programs { ProgramsID = 7, ProgramName = "ELECTRICAL DEPARTMENT" }
                ));

            builder.Entity<Classes>(x => x.HasData(
                new Classes { ClassesID = 1, ClassName = "DM17", IsActive = true, ProgramsID = 1, AddYear = 2017 },
                new Classes { ClassesID = 2, ClassName = "DM18", IsActive = true, ProgramsID = 1, AddYear = 2018 },
                new Classes { ClassesID = 3, ClassName = "MS17", IsActive = true, ProgramsID = 2, AddYear = 2017 },
                new Classes { ClassesID = 4, ClassName = "MS18", IsActive = true, ProgramsID = 2, AddYear = 2018 },
                new Classes { ClassesID = 5, ClassName = "CJ17", IsActive = true, ProgramsID = 3, AddYear = 2017 },
                new Classes { ClassesID = 6, ClassName = "CJ18", IsActive = true, ProgramsID = 3, AddYear = 2018 },
                new Classes { ClassesID = 7, ClassName = "COOK17", IsActive = true, ProgramsID = 4, AddYear = 2018 },
                new Classes { ClassesID = 8, ClassName = "COOK18", IsActive = true, ProgramsID = 4, AddYear = 2017 },
                new Classes { ClassesID = 9, ClassName = "AG17", IsActive = true, ProgramsID = 5, AddYear = 2018 },
                new Classes { ClassesID = 10, ClassName = "AG18", IsActive = true, ProgramsID = 5, AddYear = 2017 },
                new Classes { ClassesID = 11, ClassName = "HND17", IsActive = true, ProgramsID = 6, AddYear = 2018 },
                new Classes { ClassesID = 12, ClassName = "HND18", IsActive = true, ProgramsID = 6, AddYear = 2017 },
                new Classes { ClassesID = 13, ClassName = "ELEC17", IsActive = true, ProgramsID = 7, AddYear = 2018 },
                new Classes { ClassesID = 14, ClassName = "ELEC18", IsActive = true, ProgramsID = 7, AddYear = 2017 },
                new Classes { ClassesID = 15, ClassName = "AG16", IsActive = true, ProgramsID = 5, AddYear = 2016 }
                ));
            builder.Entity<Terms>(x => x.HasData(
                new Terms { Term = 1.1F, Description = "Year 1 term 1", TermsID = 1 },
                new Terms { Term = 1.2F, Description = "Year 1 term 2", TermsID = 2 },
                new Terms { Term = 1.3F, Description = "Year 1 term 3", TermsID = 3 },
                new Terms { Term = 2.1F, Description = "Year 2 term 1", TermsID = 4 },
                new Terms { Term = 2.2F, Description = "Year 2 term 2", TermsID = 5 },
                new Terms { Term = 2.3F, Description = "Year 2 term 3", TermsID = 6 },
                new Terms { Term = 3.1F, Description = "Year 3 term 1", TermsID = 7 },
                new Terms { Term = 3.2F, Description = "Year 3 term 2", TermsID = 8 },
                new Terms { Term = 3.3F, Description = "Year 3 term 3", TermsID = 9 }));


            builder.Entity<BillItems>(x => x.HasData(
                new BillItems { BillItem = "Feeding", BillItemsID = 1 },
                new BillItems { BillItem = "PTA Dues", BillItemsID = 2 },
                new BillItems { BillItem = "Boarding fees", BillItemsID = 3 }
                ));

            builder.Entity<TransactionsTypes>(x => x.HasData(
                new TransactionsTypes { TransactionsTypesID = 1, TransactionType = "Revenue" },
                new TransactionsTypes { TransactionsTypesID = 2, TransactionType = "Expenditure" }
                ));

            base.OnModelCreating(builder);
        }

        public virtual DbSet<Programs> Programs { get; set; }

        public virtual DbSet<Students> Students { get; set; }

        public virtual DbSet<BillItems> BillItems { get; set; }

        public virtual DbSet<ClassBills> ClassBills { get; set; }

        public virtual DbSet<Terms> Terms { get; set; }

        public virtual DbSet<Payments> Payments { get; set; }

        public virtual DbSet<IndividualBills> IndividualBills { get; set; }

        public virtual DbSet<Classes> Classes { get; set; }

        public virtual DbSet<StudentsInfo> StudentsInfo { get; set; }

        public virtual DbSet<Revenues> Revenues { get; set; }

        public virtual DbSet<Transactions> Transactions { get; set; }

        public virtual DbSet<TransactionsTypes> TransactionsTypes { get; set; }
    }

    public class ApplicationUser : IdentityUser
    {
    }
}