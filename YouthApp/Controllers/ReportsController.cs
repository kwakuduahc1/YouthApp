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
    public class ReportsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public ReportsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        public async Task<IEnumerable> Quarterly(byte start, byte end)
        {
            return await new ApplicationDbContext(dco).TransactionItems.Select(x => new
            {
                x.TransactionItem,
                Revenue = x.Transactions.Where(t => t.TransactionDate.Year == DateTime.Now.Year && t.TransactionDate.Month >= start && t.TransactionDate.Month <= end && t.TransactionsTypesID == (short)TranTypes.Revenue).Sum(t => t.Amount),
                Expenditure = x.Transactions.Where(t => t.TransactionDate.Year == DateTime.Now.Year && t.TransactionDate.Month >= start && t.TransactionDate.Month <= end && t.TransactionsTypesID == (short)TranTypes.Expenditure).Sum(t => t.Amount)
            }).ToListAsync();
        }
    }
}