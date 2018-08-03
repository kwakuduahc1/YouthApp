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
        public async Task<IEnumerable> Debtors(int cid)
        {
            var model = new List<Debtors>();
            using (var db = new ApplicationDbContext(dco))
            {
                var stds = await db.Students.Where(x => x.ClassesID == cid).ToListAsync();
                foreach (var std in stds)
                {
                    var bill = await db.ClassBills.Where(x => x.ClassesID == std.ClassesID).SumAsync(t => t.Amount);
                    var payments = await db.Payments.Where(x => x.StudentsID == std.StudentsID).SumAsync(t => t.Amount);
                    if (payments < bill)
                        model.Add(new Debtors { StudentsID = std.StudentsID, Arrears = bill - payments, Name = $"{std.Surname} {std.OtherNames}" });
                }
            }
            return model;
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

    class Debtors
    {
        public long StudentsID { get; set; }

        public double Arrears { get; set; }

        public string Name { get; set; }

        public string ClassName { get; set; }
    }
}
