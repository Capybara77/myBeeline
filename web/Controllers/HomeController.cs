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
        return LocalRedirect("/data");
    }

    [Route("/data")]
    public IActionResult Data()
    {
        return View(DataDb.Feedbacks.ToList());
    }

    public IActionResult Buy(int id)
    {
        if (id == 1)
            return View((object)"Роутер xiaomi");

        else if (id == 2)
            return View((object)"Роутер TP-Link");

        return NotFound();
    }

    public async Task<IActionResult> SubmitBuy(string name, string email, string pname)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) ||
            string.IsNullOrEmpty(pname))
            return BadRequest();

        string text = $"Здравствуйте, {name}. Ваш заказ - {pname} (1 шт.) успешно оформлен, спасибо за обращение.";
        await Email.SendEmailAsync(email, "Покупка товара на сайте Mybeeline", text);
        return View("success");
    }
}