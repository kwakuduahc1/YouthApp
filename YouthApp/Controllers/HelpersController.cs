using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouthApp.Context;
using YouthApp.Models;

namespace YouthApp.Controllers
{
    public class HelpersController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public HelpersController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable<Terms>> Terms() => await new ApplicationDbContext(dco).Terms.ToListAsync();
    }
}