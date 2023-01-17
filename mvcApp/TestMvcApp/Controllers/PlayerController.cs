using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestMvcApp.Models;
using BLL;
using DAL;
using BOL;
namespace TestMvcApp.Controllers;

public class PlayerController : Controller
{
    private readonly ILogger<PlayerController> _logger;

    public PlayerController(ILogger<PlayerController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Middle obj = new Middle();
        List<Players> getall = obj.getAllList();
        this.ViewData["index"] = getall;
        return View();
    }

    public IActionResult Display(int id)
    {
        Players players = new Players();
        Middle obj = new Middle();
        players = obj.GetPlayersdb(id);
        this.ViewData["display"] = players;
        return View();
    }
    public IActionResult Insert()
    {
        Players obj = new Players();
        return View(obj);
    }

    [HttpPost]
    public IActionResult Insert(Players obj)
    {
        Middle player = new Middle();
        bool status = player.Insertdata(obj);
        if (status == true)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    
     public IActionResult Update(int id)
    {
        Players obj = new Players();
        return View(obj);
    }
     [HttpPost]
    public IActionResult Update(Players player)
    {

        Middle midobj = new Middle();
        bool obj = midobj.Updatedata(player);
        if (obj == true)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    
       public IActionResult Delete()
    {
        Players obj = new Players();
        return View(obj);
    }
    [HttpPost]
       public IActionResult Delete(int id)
    {
        Players obj = new Players();
        Middle obj1=new Middle();
         bool status=obj1.Deletedata(id);
          if (status == true)
        {
            return RedirectToAction("Index");
        }
        return View(obj);
    }
    

}
