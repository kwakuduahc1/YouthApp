using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouthApp.Context;
using YouthApp.Models;

namespace bStudioSchoolManager.Controllers
{
    public class ClassesController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public ClassesController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> List() => await new ApplicationDbContext(dco).Classes.Where(x => x.IsActive).OrderBy(x => x.ClassName).ThenBy(x => x.AddYear).ToListAsync();

        [HttpGet]
        public async Task<IActionResult> Find(int id)
        {
            var mClass = await new ApplicationDbContext(dco).Classes.FindAsync(id);
            if (mClass == null)
                return NotFound(new { message = "Search did not return any results" });
            return Ok(mClass);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("MainClassName"), FromBody]Classes classes)
        {
            if (!ModelState.IsValid)
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

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]Classes classes)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.Classes.AnyAsync(x => x.ClassesID == classes.ClassesID))
                    return BadRequest(new { message = "Class does not exist" });
                if (await db.Classes.AnyAsync(x => x.ClassName == classes.ClassName))
                    return BadRequest(new { Message = "Error : No changes were detected or attempt to insert duplicate class name was detected" });
                db.Entry(classes).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            return Created($"/Classes/{classes.ClassesID}", classes);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]Classes classes)
        {
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.Classes.AnyAsync(x => x.ClassesID == classes.ClassesID))
                    return BadRequest(new { message = "Class does not exist" });
                db.Entry(classes).State = EntityState.Deleted;
                await db.SaveChangesAsync();
            }
            return Ok(classes);
        }

        [HttpPut]
        public async Task<IActionResult> Change([FromBody]Classes classes)
        {
            using (var db = new ApplicationDbContext(dco))
            {
                Classes _class = await db.Classes.FindAsync(classes.ClassesID);
                if (_class == null)
                    return BadRequest(new { message = "Class does not exist" });
                _class.IsActive = false;
                db.Entry(_class).Property(x => x.IsActive).IsModified = true;
                await db.SaveChangesAsync();
            }
            return Created($"/Classes/{classes.ClassesID}", classes);
        }
    }
}
