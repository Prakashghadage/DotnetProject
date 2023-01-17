using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestMvcApp.Models;
using BLL;
using DAL;
using BOL;
namespace TestMvcApp.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }
  

   public IActionResult Index()
    {
        return View();
    }

    
     public IActionResult Authentication( int id,string uname,string psw)
    {
        Console.WriteLine(uname);
        
           if(uname=="prakashghadage025@gmail.com" && psw=="Sveri@123")
           {
            return RedirectToAction("homeindex");
           }
         return View();
    }
     

      public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
      public IActionResult Register(int id,string name,string city)
    {
        Middle student=new Middle();
        student.RegisterUser(id,name,city);
          Console.WriteLine("Register data");
          return RedirectToAction("/Home");
    }

     public IActionResult Homeindex()
    {
        return View();
    }






}