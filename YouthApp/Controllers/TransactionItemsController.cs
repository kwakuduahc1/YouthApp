using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouthApp.Context;
using YouthApp.Models;

namespace YouthApp.Controllers
{
    public class TransactionItemsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public TransactionItemsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> List() => await new ApplicationDbContext(dco).TransactionItems.OrderBy(x => x.TransactionItem).Take(20).ToListAsync();

        [HttpGet]
        public async Task<IActionResult> Find(short id)
        {
            var tran = await new ApplicationDbContext(dco).TransactionItems.FindAsync(id);
            if (tran == null)
                return NotFound(new { message = "Search did not return any results" });
            return Ok(tran);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]TransactionItems transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (await db.TransactionItems.AnyAsync(x => x.TransactionItem == transaction.TransactionItem))
                    return BadRequest(new { Message = "Item already exists" });
                db.Add(transaction);
                await db.SaveChangesAsync();
            }
            return Created($"/Transactions/{transaction.TransactionItemsID}", transaction);
        }


        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]TransactionItems tran)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.TransactionItems.AnyAsync(x => x.TransactionItemsID == tran.TransactionItemsID))
                    return BadRequest(new { message = "Item does not exist" });
                db.Entry(tran).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            return Created($"/Classes/{tran.TransactionItemsID}", tran);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]TransactionItems tran)
        {
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.Transactions.AnyAsync(x => x.TransactionItemsID == tran.TransactionItemsID))
                    return BadRequest(new { message = "Item does not exist" });
                db.Entry(tran).State = EntityState.Deleted;
                await db.SaveChangesAsync();
            }
            return Ok(tran);
        }
    }

}