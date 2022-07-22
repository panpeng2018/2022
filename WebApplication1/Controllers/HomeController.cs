using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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
            return View();
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
        //public void AddData()
        //{
        //    for(var i=0;i<10;i++)
        //    {
        //        Customer ct = new Customer();
        //        ct.CustomerID = list.Count+1;
        //        ct.Score = 0;
        //        list.Add(ct);
        //    }
        //}
        //public static ConcurrentBag<Customer> GetListData()
        //{
        //    return list;
        //}
    }
}