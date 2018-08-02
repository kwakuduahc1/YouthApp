using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouthApp.Context;
using YouthApp.Models;

namespace YouthApp.Controllers
{
    public class RevenuesController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public RevenuesController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> List() => await new ApplicationDbContext(dco).Revenues.Take(20).ToListAsync();

        [HttpGet]
        public async Task<IActionResult> Find(int id)
        {
            var rev = await new ApplicationDbContext(dco).Revenues.FindAsync(id);
            if (rev == null)
                return NotFound(new { message = "Search did not return any results" });
            return Ok(rev);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Revenues item)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (await db.Revenues.AnyAsync(x => x.AccountName == item.AccountName || x.AccountNumber == item.AccountNumber))
                    return BadRequest(new { message = $"{item.AccountName} or ${item.AccountNumber} already exits" });
                db.Add(item);
                await db.SaveChangesAsync();
            }
            return Created($"/Classes/{item.RevenuesID}", item);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]Revenues item)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.Revenues.AnyAsync(x => x.RevenuesID == item.RevenuesID))
                    return BadRequest(new { message = "Class does not exist" });
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            return Created($"/Classes/{item.RevenuesID}", item);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]Revenues item)
        {
            using (var db = new ApplicationDbContext(dco))
            {
                var _item = await db.Revenues.FindAsync(item.RevenuesID);
                if (_item == null)
                    return BadRequest(new { Message = "Item not found" });
                db.Entry(_item).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return Ok(item);
            }
        }

    }
}