using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bStudioSchoolManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouthApp.Context;
using YouthApp.Models;

namespace YouthApp.Controllers
{
    public class HelpersController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public HelpersController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> TransactionTypes() => await new ApplicationDbContext(dco).TransactionsTypes.ToListAsync();

        [HttpGet]
        public async Task<IEnumerable<Terms>> Terms() => await new ApplicationDbContext(dco).Terms.ToListAsync();

        [HttpGet]
        public async Task<IEnumerable> Payments()
        {
            using (var db = new ApplicationDbContext(dco))
            {
                var list = await db.ClassBills.Where(x => x.DatePrepared.Year == DateTime.Now.Year).GroupBy(x => new { x.BillItems.BillItem, x.BillItemsID }, (k, v) => new
                {
                    k.BillItem,
                    k.BillItemsID,
                    Amount = v.Sum(t => t.Amount)
                }).Select(x => new { x.BillItem, x.BillItemsID, x.Amount })
                .ToListAsync();
                var total = list.Sum(x => x.Amount);
                var payments = await db.Payments.Where(x => x.DatePaid.Year == DateTime.Now.Year).SumAsync(x => x.Amount);
                var list2 = list.Select(x => new { x.BillItem, x.BillItemsID, x.Amount, Percent = (x.Amount / total) });
                return list2.Select(x => new { x.BillItem, x.BillItemsID, x.Amount, x.Percent, Payments = x.Percent * payments });
            }

        }

        [HttpGet]
        public async Task<IEnumerable> Debtors()
        {
            var model = new List<Debtors>();
            using (var db = new ApplicationDbContext(dco))
            {
                var stds = await db.Students.Include(x => x.Classes).Where(x => x.Classes.IsActive).ToListAsync();
                foreach (var std in stds)
                {
                    var bill = await db.ClassBills.Where(x => x.ClassesID == std.ClassesID).SumAsync(t => t.Amount);
                    var payments = await db.Payments.Where(x => x.StudentsID == std.StudentsID).SumAsync(t => t.Amount);
                    if (payments < bill)
                        model.Add(new Debtors { StudentsID = std.StudentsID, Arrears = bill - payments, Name = $"{std.Surname} {std.OtherNames}", ClassName = std.Classes.ClassName });
                }
            }
            return model.OrderByDescending(x => x.Arrears).Take(15);
        }
    }
}