using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouthApp.Context;

namespace bStudioSchoolManager.Controllers
{
    public class StudentBillsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public StudentBillsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IActionResult> Statement(Guid id)
        {
            using (var db = new ApplicationDbContext(dco))
            {
                var std = await db.Students.SingleOrDefaultAsync(x => x.StudentsID == id);
                if (std == null)
                    return NotFound(new { message = "No student id matched" });
                var bill = await db.ClassBills.Where(x => x.ClassesID == std.ClassesID && x.DatePrepared > std.DateRegistered)
                    .GroupBy(x => new { x.Terms }, (k, v) => new
                    {
                        k.Terms,
                        Amount = v.Sum(x => x.Amount)
                    })
                    .ToListAsync();
                var payments = await db.Payments.Where(x => x.StudentsID == std.StudentsID).Select(x => new { x.DatePaid, x.Amount, x.Receiver }).ToListAsync();
                return Ok(new { bill, payments });
            }
        }
    }
}