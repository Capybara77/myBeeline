using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using web.Models;

namespace web.Controllers;

public class HomeController : Controller
{
    public DataContext DataDb { get; }

    public HomeController(DataContext data)
    {
        DataDb = data;
    }
        
    public IActionResult Index()
    {
        return LocalRedirect("/index.html");
    }

    public int GetCount()
    {
        return DataDb.Feedbacks.Count();
    }

    [HttpPost]
    public IActionResult Form(Feedback feedback)
    {
        DataDb.Feedbacks.Add(feedback);
        DataDb.SaveChanges();
        return LocalRedirect("/index.html");
    }

    [Route("/data")]
    public IActionResult Data()
    {
        return View(DataDb.Feedbacks.ToList());
    }
}