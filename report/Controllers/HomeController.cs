using Microsoft.AspNetCore.Mvc;
using report.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace report.Controllers
{



    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/tickets", "tickets.txt");
            var lines = System.IO.File.ReadAllLines(path);

            var tickets = lines.Select(line => new Ticket { Content = line }).ToList();

            return View(tickets);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}