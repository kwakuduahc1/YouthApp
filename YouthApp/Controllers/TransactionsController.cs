using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouthApp.Context;
using YouthApp.Models;

namespace YouthApp.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public TransactionsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> List() => await new ApplicationDbContext(dco).Transactions.Select(x => new { x.Amount, x.IsStudent, x.Purpose, x.Revenues.Bank, x.TransactionDate, x.TransactionsID, x.Revenues.Source, x.TransactionsTypes.TransactionType, x.TransactionItems.TransactionItem }).OrderByDescending(x => x.TransactionDate).Take(20).ToListAsync();

        [HttpGet]
        public async Task<IEnumerable> Search(string qry) => await new ApplicationDbContext(dco).Transactions.Where(x => EF.Functions.Like(x.Purpose, $"%{qry}%")).Select(x => new { x.Amount, x.IsStudent, x.Purpose, x.Revenues.Bank, x.TransactionDate, x.TransactionsID, x.Revenues.Source, x.TransactionsTypes.TransactionType, x.TransactionItems.TransactionItem }).OrderBy(x => x.TransactionDate).Take(20).ToListAsync();

        [HttpGet]
        public async Task<IActionResult> Find(long id)
        {
            var tran = await new ApplicationDbContext(dco).Transactions.FindAsync(id);
            if (tran == null)
                return NotFound(new { message = "Search did not return any results" });
            return Ok(tran);
        }

        [HttpPost]
        public async Task<IActionResult> Receive([FromBody]Transactions transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                transaction.TransactionDate = DateTime.Now;
                transaction.TransactionsTypesID = (byte)TranTypes.Revenue;
                db.Add(transaction);
                await db.SaveChangesAsync();
            }
            return Created($"/Transactions/{transaction.TransactionsID}", transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Issue([FromBody]Transactions transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                transaction.Amount = transaction.Amount * -1;
                transaction.TransactionsTypesID = (byte)TranTypes.Expenditure;
                transaction.TransactionDate = DateTime.Now;
                db.Add(transaction);
                await db.SaveChangesAsync();
            }
            return Created($"/Transactions/{transaction.TransactionsID}", transaction);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]Transactions tran)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.Transactions.AnyAsync(x => x.TransactionsID == tran.TransactionsID))
                    return BadRequest(new { message = "Item does not exist" });
                db.Entry(tran).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            return Created($"/Classes/{tran.TransactionsID}", tran);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]Transactions tran)
        {
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.Transactions.AnyAsync(x => x.TransactionsID == tran.TransactionsID))
                    return BadRequest(new { message = "Item does not exist" });
                db.Entry(tran).State = EntityState.Deleted;
                await db.SaveChangesAsync();
            }
            return Ok(tran);
        }
    }
}