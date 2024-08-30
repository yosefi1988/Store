 
// Controllers/UserController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationStore.Models.Contexts;
using WebApplicationStore.Models.ViewModels;

namespace WebApplicationStore.Controllers
{
    public class UserController : Controller
    {
        private readonly officia1_StoreContext _context;

        public UserController(officia1_StoreContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.Countries = _context.BdCountries.ToList();
            return View();
        }

        public JsonResult GetStates(int countryId)
        {
            var states = _context.BdStates.Where(s => s.CountryId == countryId).ToList();
            return Json(states);
        }

        public JsonResult GetCities(int stateId)
        {
            var cities = _context.BdCities.Where(c => c.StateId == stateId).ToList();
            return Json(cities);
        }

        [HttpPost]
        public IActionResult Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // اطلاعات کاربر را ذخیره کنید
                // مثلاً با استفاده از یک مدل دیگری که برای ذخیره‌سازی در پایگاه داده است
                return RedirectToAction("Success");
            }

            // در صورت وجود خطا، کشورها را دوباره ارسال کنید
            ViewBag.Countries = _context.BdCountries.ToList();
            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }

}