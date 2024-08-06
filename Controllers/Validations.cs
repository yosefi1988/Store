using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationStore.Controllers
{
    public class Validations : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult IsUserNameUsed([Bind(Prefix = "Accounts.UserName")] string NameEntered)
        {
            //bool UserNameExists = _context.Accounts.Any(u => u.UserName.Equals(NameEntered));
            //https://stackoverflow.com/questions/63553185/fail-using-remote-validation-mvc-and-razor-pages-net-core-2-2-invalidope
            return new JsonResult(false);  //NOTICE OPPOSITE BOOLEAN
        }
    }
}
