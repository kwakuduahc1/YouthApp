using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouthApp.Context;
using YouthApp.Models;

namespace YouthApp.Controllers
{
    public class HomeController : Controller
    {
        readonly DbContextOptions<ApplicationDbContext> dco;

        public HomeController(DbContextOptions<ApplicationDbContext> dbContextOptions) => dco = dbContextOptions;

        public IActionResult Index()
        {
            Task.Run(async () => await new ApplicationDbContext(dco).Database.EnsureCreatedAsync());
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
