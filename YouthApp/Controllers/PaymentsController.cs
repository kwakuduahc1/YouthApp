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
    public class PaymentsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public PaymentsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> Student(long id) => await new ApplicationDbContext(dco).Payments.Where(x => x.StudentsID == id).OrderByDescending(x => x.DatePaid).ToListAsync();

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Payments payment)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                var std = await db.Students.FindAsync(payment.StudentsID);
                if (std == null)
                    return BadRequest(new { Message = "Payment could not be accepted as the student could not be found" });
                //payment.DatePaid = DateTime.Now;
                db.Add(payment);
                var rev = await db.Revenues.Where(x => x.Source == "IGF").FirstOrDefaultAsync();
                db.Transactions.Add(new Transactions
                {
                    RevenuesID = rev.RevenuesID,
                    Amount = payment.Amount,
                    TransactionDate = DateTime.Now,
                    TransactionsTypesID = (byte)TranTypes.Revenue,
                    TransactionItemsID = 7,
                    Purpose = $"School fees payment by :{std.Surname} {std.OtherNames ?? ""}. GCR :{payment.GCR}"
                });
                await db.SaveChangesAsync();
            }
            return Created($"/Payments/Payment?id={payment.PaymentsID}", payment);
        }
    }
}