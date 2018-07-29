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
    [AutoValidateAntiforgeryToken]
    public class PaymentsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public PaymentsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> Student(Guid id) => await new ApplicationDbContext(dco).Payments.Where(x => x.StudentsID == id).OrderByDescending(x => x.DatePaid).ToListAsync();

        [HttpPost]
        public async Task<IActionResult> Create([Bind("StudentsID","Amount", "Receiver"),FromBody]Payments payment)
        {
            if(!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                payment.DatePaid = DateTime.Now;
                db.Add(payment);
                await db.SaveChangesAsync();
            }
            return Created($"/Payments/Payment?id={payment.PaymentsID}", payment);
        }
    }
}