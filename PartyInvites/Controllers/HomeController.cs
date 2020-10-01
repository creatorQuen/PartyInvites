using Microsoft.AspNetCore.Mvc;
using System;
using PartyInvites.Models;
using System.Linq;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.StartScreen = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }

        //public ViewResult RsvpForm()
        //{
        //    return View();
        //}

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            // Что сделать: созранить ответ от гостя
            // Все, что необходимо сделать с данными формы, отправленными в запро­се - передать 
            // методу Repository.AddResponse() в качестве аргумента объ­ект GuestResponse, 
            // который был передан методу действия, чтобы ответ мог быть cохранен.

            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                // Обнаружена ошибка проверки достоверности.
                return View();
            }
        }
        
        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
    }
}
