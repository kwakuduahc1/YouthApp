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
            //builder.Entity<Terms>(x=>x.has)
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Students> Students { get; set; }

        public virtual DbSet<BillItems> BillItems { get; set; }

        public virtual DbSet<ClassBills> ClassBills { get; set; }

        public virtual DbSet<Terms> Terms { get; set; }

        public virtual DbSet<Payments> Payments { get; set; }

        public virtual DbSet<IndividualBills> IndividualBills { get; set; }

        public virtual DbSet<Classes> Classes { get; set; }
    }

    public class ApplicationUser:IdentityUser
    {
    }
}
