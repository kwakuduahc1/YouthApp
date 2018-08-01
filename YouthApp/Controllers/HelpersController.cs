using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                    Total = v.Sum(t => t.Amount)
                }).Select(x => new { x.BillItem, x.BillItemsID, x.Total })
                .ToListAsync();
                var total = list.Sum(x => x.Total);
                var payments = await db.Payments.Where(x => x.DatePaid.Year == DateTime.Now.Year).SumAsync(x => x.Amount);
                var list2 =  list.Select(x => new { x.BillItem, x.BillItemsID, x.Total, Percent = (x.Total / total) });
                return list2.Select(x => new { x.BillItem, x.BillItemsID, x.Total, x.Percent, Payments = x.Percent * payments });
            }

        }
    }
}