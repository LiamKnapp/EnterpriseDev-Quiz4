using Microsoft.AspNetCore.Mvc;
using Quiz4.Models;
using System.Diagnostics;
using Quiz4.Entities;
using Microsoft.EntityFrameworkCore;

namespace Quiz4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BpdbContext _bpdbContext;

        public HomeController(ILogger<HomeController> logger, BpdbContext bpdbContext)
        {
            _logger = logger;
            _bpdbContext = bpdbContext;
        }


        public IActionResult Index()
        {
            // Fetch all BP measurements and ordered by measurement date (most recent first)
            var allBpMeasurements = _bpdbContext.Bpmeasurements
                .Include(bp => bp.MeasurementPosition)
                .OrderByDescending(bp => bp.MeasurementDate)
                .ToList();

            // Pass the measurements to the view
            return View("Index", allBpMeasurements);
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
