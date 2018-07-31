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
            optionsBuilder.UseSqlite("Data Source=database.db;", (o => o.UseRelationalNulls(true).SuppressForeignKeyEnforcement(false)));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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
            builder.Entity<Classes>(x => x.HasData(
                new Classes { ClassesID = 1, ClassName = "Tech 2017", IsActive = true },
                 new Classes { ClassesID = 2, ClassName = "Tech 2018", IsActive = true },
                  new Classes { ClassesID = 3, ClassName = "Tech 2019", IsActive = true }
                ));
            builder.Entity<BillItems>(x => x.HasData(
                new BillItems { BillItem = "Feeding", BillItemsID = 1 },
                new BillItems { BillItem = "PTA Dues", BillItemsID = 2 },
                new BillItems { BillItem = "Boarding fees", BillItemsID = 3 }
                ));
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Students> Students { get; set; }

        public virtual DbSet<BillItems> BillItems { get; set; }

        public virtual DbSet<ClassBills> ClassBills { get; set; }

        public virtual DbSet<Terms> Terms { get; set; }

        public virtual DbSet<Payments> Payments { get; set; }

        public virtual DbSet<IndividualBills> IndividualBills { get; set; }

        public virtual DbSet<Classes> Classes { get; set; }

        public virtual DbSet<StudentsInfo> StudentsInfo { get; set; }
    }

    public class ApplicationUser : IdentityUser
    {
    }
}
