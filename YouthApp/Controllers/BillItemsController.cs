using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouthApp.Context;
using YouthApp.Models;

namespace bStudioSchoolManager.Controllers
{
    public class BillItemsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public BillItemsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> List() => await new ApplicationDbContext(dco).BillItems.ToListAsync();

        [HttpGet]
        public async Task<IActionResult> Find(int id)
        {
            var mClass = await new ApplicationDbContext(dco).BillItems.FindAsync(id);
            if (mClass == null)
                return NotFound(new { message = "Search did not return any results" });
            return Ok(mClass);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("BillItem"),FromBody]BillItems item)
        {
            if(!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (await db.BillItems.AnyAsync(x => x.BillItem == item.BillItem))
                    return BadRequest(new { message = $"{item.BillItem} already exits" });
                db.Add(item);
                await db.SaveChangesAsync();
            }
            return Created($"/Classes/{item.BillItemsID}", item);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]BillItems item)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.BillItems.AnyAsync(x => x.BillItemsID == item.BillItemsID))
                    return BadRequest(new { message = "Class does not exist" });
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            return Created($"/Classes/{item.BillItemsID}", item);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]BillItems item)
        {
            using (var db = new ApplicationDbContext(dco))
            {
                var _item = await db.BillItems.FindAsync(item.BillItemsID);
                if (_item == null)
                    return BadRequest(new { Message = "Item not found" });
                db.Entry(_item).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return Ok(item);
            }
        }
    }
}
