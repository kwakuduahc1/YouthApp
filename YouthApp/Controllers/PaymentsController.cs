using System;
using System.Collections;
using System.Collections.Generic;
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
                var rev = await db.Revenues.Where(x => x.Source == "IGF").FirstOrDefaultAsync();
                var tran = new Transactions
                {
                    RevenuesID = rev.RevenuesID,
                    Amount = payment.Amount,
                    TransactionDate = DateTime.Now,
                    TransactionsTypesID = (byte)TranTypes.Revenue,
                    TransactionItemsID = 7,
                    Purpose = $"School fees payment by :{std.Surname} {std.OtherNames ?? ""}. GCR :{payment.GCR}",
                    Payments = new List<Payments>() { payment }
                };
                //payment.DatePaid = DateTime.Now;
               // tran.Payments.Add(payment);
                db.Add(tran);
                // payment.TransactionsID = tran.TransactionsID;
                //await db.AddAsync(payment);
                await db.SaveChangesAsync();
            }
            return Created($"/Payments/Payment?id={payment.PaymentsID}", new { payment.TransactionsID, payment.StudentsID, payment.Receiver, payment.PaymentsID, payment.GCR, payment.DatePaid, payment.Amount });
        }
    }
}