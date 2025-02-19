using BankSystem.Service.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.App.Controllers.User;
[Authorize(Roles = "User")]
public class UserViewController(ICardInfoRepsitory cardInfoRepsitory) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var data = await cardInfoRepsitory.GetAllAsync(x => x.FileTypes);
        return View(data);
    }
}
