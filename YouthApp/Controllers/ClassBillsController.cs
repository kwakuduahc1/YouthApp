using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouthApp.Context;
using YouthApp.Models;

namespace bStudioSchoolManager.Controllers
{
    public class ClassBillsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public ClassBillsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> Bill(int classid, short year) => await new ApplicationDbContext(dco).ClassBills.Where(x => x.ClassesID == classid && x.DatePrepared.Year == year).Select(x => new { x.BillItemsID, x.ClassBillsID, x.Amount, x.BillItems.BillItem, x.YearGroup, x.DatePrepared, x.ClassesID }).ToListAsync();

        [HttpGet]
        public async Task<IEnumerable> ClassBill(int classid, byte term)
        {
            var std_bills = new List<StudentBill>();
            using (var db = new ApplicationDbContext(dco))
            {
                var list = await db.Students.Where(x => x.ClassesID == classid).Include(x => x.Classes).ThenInclude(x => x.Programs).ToListAsync();
                var bill = await db.ClassBills.Where(x => x.ClassesID == classid).ToListAsync();
                Bill fees = new Bill { Amount = bill.Sum(x => x.Amount), Item = "Fees" };
                foreach (var std in list)
                {
                    var temp = new StudentBill { IndexNumber = std.UniqueID, Name = $"{std.Surname} {std.OtherNames ?? ""}", Program = std.Classes.Programs.ProgramName, Bills = new List<Bill>() };
                    temp.Bills.Add(fees);
                    var ind_bill = await db.IndividualBills.Where(x => x.StudentsID == std.StudentsID && !x.IsPaid).Select(x => new Bill { Item = x.Description, Amount = x.Amount }).ToListAsync();
                    if (ind_bill.Any())
                        temp.Bills.AddRange(ind_bill);
                    var payments = await db.Payments.Where(x => x.StudentsID == std.StudentsID).GroupBy(x => x.StudentsID, (k, v) => new Bill
                    {
                        Item = "Payments",
                        Amount = v.Sum(t => t.Amount) * -1
                    }).ToListAsync();
                    if (payments.Any())
                        temp.Bills.AddRange(payments);
                    std_bills.Add(temp);
                }
            }
            return std_bills;
        }

        [HttpGet]
        public async Task<IEnumerable> Debtors(int cid)
        {
            return await new ApplicationDbContext(dco).Students.Where(x => x.ClassesID == cid)
                .Select(x => new
                {
                    x.UniqueID,
                    x.Classes.Programs.ProgramName,
                    x.Classes.ClassName,
                    x.StudentsID,
                    x.Surname,
                    x.OtherNames,
                    Arrears = x.Classes.ClassBills.Sum(t => t.Amount) - x.Payments.Sum(t => t.Amount)
                }).Where(x => x.Arrears > 0).ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]List<BillsVm> bills)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            var item = bills.First();
            using (var db = new ApplicationDbContext(dco))
            {
                if (await db.ClassBills.AnyAsync(x => x.YearGroup == item.YearGroup))
                    return BadRequest(new { message = $"Bill already exits for the year group" });
                var classes = await db.Classes.Where(x => x.AddYear == item.YearGroup).ToListAsync();
                bills.ForEach(x =>
                {
                    classes.ForEach(t => db.ClassBills.Add(new ClassBills
                    {
                        Amount = x.Amount,
                        BillItemsID = x.BillItemsID,
                        ClassesID = t.ClassesID,
                        DatePrepared = DateTime.Now,
                        YearGroup = x.YearGroup,
                        TermsID = x.TermsID
                    }));
                });
                await db.SaveChangesAsync();
            }
            return Created($"/ClassBills/Bill?class={item.YearGroup}", bills);
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit([Bind("MainClassName","IsActive","Concurrency","MainClassesID"), FromBody]BillItems item)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
        //    using (var db = new ApplicationDbContext(dco))
        //    {
        //        if (!await db.BillItems.AnyAsync(x => x.BillItemsID == item.BillItemsID))
        //            return BadRequest(new { message = "Class does not exist" });
        //        db.Entry(item).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //    }
        //    return Created($"/Classes/{item.BillItemsID}", item);
        //}
    }

    class StudentBill
    {
        public string Name { get; set; }

        public string IndexNumber { get; set; }

        public string Program { get; set; }

        public List<Bill> Bills { get; set; }
    }

    public class Bill
    {
        public double Amount { get; set; }

        public string Item { get; set; }
    }
}
