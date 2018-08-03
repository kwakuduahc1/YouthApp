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
        public async Task<IEnumerable> List() => await new ApplicationDbContext(dco).Transactions.OrderBy(x => x.TransactionDate).Take(20).ToListAsync();

        [HttpGet]
        public async Task<IActionResult> Find(int id)
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