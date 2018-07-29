using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouthApp.Context;
using YouthApp.Models;

namespace bStudioSchoolManager.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class ClassesController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public ClassesController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> List() => await new ApplicationDbContext(dco).Classes.ToListAsync();

        [HttpGet]
        public async Task<IActionResult> Find(int id)
        {
            var mClass = await new ApplicationDbContext(dco).Classes.FindAsync(id);
            if (mClass == null)
                return NotFound(new { message = "Search did not return any results" });
            return Ok(mClass);
        }

        [HttpGet]
        public async Task<IEnumerable> Subs(int id) => await new ApplicationDbContext(dco)
            .Students
            .Where(x => x.ClassesID == id)
            .GroupBy(x => x.SubClass, k => new
            {
                k
            })
            .ToListAsync();

        [HttpPost]
        public async Task<IActionResult> Create([Bind("MainClassName"),FromBody]Classes classes)
        {
            if(!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (await db.Classes.AnyAsync(x => x.ClassName == classes.ClassName))
                    return BadRequest(new { message = "Class name already exits" });
                classes.IsActive = true;
                db.Add(classes);
                await db.SaveChangesAsync();
            }
            return Created($"/Classes/{classes.ClassesID}", classes);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("MainClassName","IsActive","Concurrency","MainClassesID"), FromBody]Classes classes)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.Classes.AnyAsync(x => x.ClassesID == classes.ClassesID))
                    return BadRequest(new { message = "Class does not exist" });
                db.Entry(classes).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            return Created($"/Classes/{classes.ClassesID}", classes);
        }


    }
}
