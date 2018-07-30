using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouthApp.Context;
using YouthApp.Models;

namespace bStudioSchoolManager.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class StudentsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;
        private IHostingEnvironment _hostingEnvironment;

        public StudentsController(DbContextOptions<ApplicationDbContext> options, IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
            dco = options;
        }

        [HttpGet]
        public async Task<IEnumerable> List(int id) => await new ApplicationDbContext(dco).Students.Where(x => x.ClassesID == id).OrderByDescending(x => x.UniqueID).ToListAsync();

        [HttpGet]
        public async Task<IActionResult> Find(Guid id)
        {
            var std = await new ApplicationDbContext(dco).Students.FindAsync(id);
            return std == null ? (IActionResult)BadRequest(new { message = "No student was found matching that id" }) : Ok(std);
        }

        [HttpGet]
        public IActionResult GetPicture(string id)
        {
            var uid = GetSaveName(id); try
            {

                DirectoryInfo directory = Directory.CreateDirectory("/Pictures");
                FileStream image = System.IO.File.OpenRead($"{directory}\\{uid}.png");
                return File(image, "image/png");
            }
            catch (FileNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPicture(IFormFile file)
        {
            if (file == null)
            {
                return BadRequest(new { message = "no file was submitted" });
            }
            else if (file.Length <= 0 && file.Length < 1024)
                return BadRequest(new { message = "no file was submitted or file was less than 50kb" });
            else if (file.Length > 100000)
                return BadRequest(new { message = "file must be less than 100kb" });
            else
            {
                DirectoryInfo directory = Directory.CreateDirectory("/Pictures");
                string path = GetSaveName(file.FileName);
                using (var fileStream = new FileStream($"{directory}\\{path}.png", FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return Ok(null);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Students std)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                var stdClass = await db.Classes.FindAsync(std.ClassesID);
                std.UniqueID = await GetNextNumber(stdClass);
                std.DateRegistered = DateTime.Now;
                std.DateOfBirth = std.DateOfBirth.Date;
                db.Add(std);
                await db.SaveChangesAsync();
            }
            return Created($"/Students/Find?id={std.StudentsID}", new { std.Surname, std.OtherNames, std.Concurrency, std.StudentsID, std.UniqueID, std.DateOfBirth });
        }

        async Task<string> GetNextNumber(Classes classes)
        {
            string inx;
            using (var db = new ApplicationDbContext(dco))
            {
                int count = await db.Students.Where(x => x.ClassesID == classes.ClassesID).CountAsync();
                inx = $"NYLTC/{classes.ClassName}/{count + 1}";
                if (await db.Students.AnyAsync(t => t.UniqueID == inx))
                {
                    var counter = 1;
                    while (await db.Students.AnyAsync(x => x.UniqueID == inx))
                    {
                        inx = $"NYLTC/{classes.ClassName}/{counter}";
                        if (!await db.Students.AnyAsync(x => x.UniqueID == inx))
                            break;
                        counter++;
                    }
                }
            }
            return inx;
        }

        string GetSaveName(string id) => id.Replace("/", "");

    }
}