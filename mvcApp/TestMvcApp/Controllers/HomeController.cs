using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestMvcApp.Models;
using BOL;
using DAL;
using BLL;
namespace TestMvcApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
         Players obj=new Players(); 
         this.ViewData["index"]=obj;   
          return View();
       // return View();
    }
    public IActionResult show()
    {
         Players obj=new Players(); 
        return View(obj);
       
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
