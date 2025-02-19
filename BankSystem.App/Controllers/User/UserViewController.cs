using Microsoft.AspNetCore.Mvc;

namespace BankSystem.App.Controllers.User
{
    public class UserViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
