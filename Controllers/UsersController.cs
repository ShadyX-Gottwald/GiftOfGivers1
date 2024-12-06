using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiftOfGivers1.Controllers;
public class UsersController : Controller {
    // GET: UsersController
    public ActionResult Index() {
        return View();
    }

    
}
