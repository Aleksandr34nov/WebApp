using BuissnesLayer;
using DataLayer;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ASContext _context;
        private DataManager _dataMan;
        private readonly ILogger<HomeController> _logger;

        public HomeController(DataManager dataManager)
        {
            //_context = context;
            _dataMan = dataManager;
        }

        public IActionResult Index()
        {
            List<Album> _albs = _dataMan.Albums.GetAllAlbums(true).ToList();
            return View(_albs);
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
