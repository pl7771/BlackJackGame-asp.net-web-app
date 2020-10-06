using BlackJackGame.Models;
using Microsoft.AspNetCore.Mvc;
using SnakeEyesGame.Extensions;


namespace BlackJackGame.Controllers
{
    public class HomeController : Controller
    {
        private BlackJack _bj;
        public IActionResult Index()
        {
            _bj = new BlackJack();
            HttpContext.Session.SetObject("BJ", _bj);
            return View(_bj);
        }

        public IActionResult NextCard()
        {
            _bj = HttpContext.Session.GetObject<BlackJack>("BJ");
            _bj.GivePlayerAnotherCard();
            HttpContext.Session.SetObject("BJ", _bj);
            return View("Index", _bj);
        }

        public IActionResult Pass()
        {
            _bj = HttpContext.Session.GetObject<BlackJack>("BJ");
            _bj.PassToDealer();
            HttpContext.Session.SetObject("BJ", _bj);
            return View("Index", _bj);
        }
    }
}
