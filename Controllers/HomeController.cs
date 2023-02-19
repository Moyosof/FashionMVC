using FashionMVC.Data;
using FashionMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FashionMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FashionDbContext _dataContext;

        public HomeController(ILogger<HomeController> logger, FashionDbContext dataContext)
        {
            _logger = logger;
            _dataContext= dataContext;
            
        }

        public IActionResult Index()
        {
            List<Fashion> fashions= _dataContext.Fashions.ToList();
            return View(fashions);
        }

        public IActionResult Add()
        {
            var fashion = new Fashion();
            return View(fashion);
        }

        [HttpPost]
        public async Task<IActionResult> AddFashion([Bind("Id, BrandName, ClothesType, Size")] Fashion fashion)
        {
            if(ModelState.IsValid)
            {
                _dataContext.Add(fashion);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fashion);
        }
        //public async Task<IActionResult> AddFashion(Fashion fashion)
        //{
        //    await _dataContext.Fashions.AddAsync(fashion);
        //    await _dataContext.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

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