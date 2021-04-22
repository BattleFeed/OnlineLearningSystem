using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineLearningSystem.Data;
using OnlineLearningSystem.Models;
using OnlineLearningSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserContext _context;

        public HomeController(ILogger<HomeController> logger, UserContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Ranking()
        {
            var userList = new List<UserViewModel>();
            var users = _context.Users.OrderByDescending(u => u.Score).Take(50);
            foreach (var user in users)
            {
                userList.Add(new UserViewModel { Username = user.UserName, Score = user.Score});
            }
            
            var rankVM = new RankingViewModel { Users = userList };
            return View(rankVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
