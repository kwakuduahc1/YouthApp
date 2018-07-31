using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouthApp.Context;
using YouthApp.Models;

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

        [HttpPost]
        public async Task<IActionResult> AddBill([FromBody]IndividualBills bill)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                bill.DateBilled = DateTime.Now;
                db.Add(bill);
                await db.SaveChangesAsync();
                return Created($"/StudentBills/Statement?id={bill.StudentsID}", bill);
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditBill([FromBody]IndividualBills bill)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.IndividualBills.AnyAsync(x => x.IndividualBillsID == bill.IndividualBillsID))
                    return BadRequest(new { Message = "Bill for student does not exists" });
                db.Entry(bill).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Created($"/StudentBills/Statement?id={bill.StudentsID}", bill);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBill([FromBody]IndividualBills bill)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.IndividualBills.AnyAsync(x => x.IndividualBillsID == bill.IndividualBillsID))
                    return BadRequest(new { Message = "Bill for student does not exists" });
                db.Entry(bill).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return Ok(bill);
            }
        }

        [HttpPut]
        public async Task<IActionResult> ChangeStatus([FromBody]IndividualBills bill)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.IndividualBills.AnyAsync(x => x.IndividualBillsID == bill.IndividualBillsID))
                    return BadRequest(new { Message = "Bill for student does not exists" });
                bill.IsPaid = true;
                db.Entry(bill).Property(t => t.IsPaid).IsModified = true;
                await db.SaveChangesAsync();
                return Created($"/StudentBills/Statement?id={bill.StudentsID}", bill);
            }
        }
    }
}