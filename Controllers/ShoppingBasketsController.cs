using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationStore.Models.Contexts;
using WebApplicationStore.Models.ViewModels;

namespace WebApplicationStore.Controllers
{
    public class ShoppingBasketsController : Controller
    {
        private readonly officia1_StoreContext _context;

        public ShoppingBasketsController(ILogger<HomeController> logger, officia1_StoreContext context)
        {
            _context = context;
            //_logger = logger;
        }

        // GET: ShoppingBasketsController
        public ActionResult Index(int userId)
        {
            ShopingBasket shopingBasket = new ShopingBasket();

            var baskets = _context.ViewUserBaskets;

            shopingBasket.baskets = baskets
                //.Where(x => x.UserId == userId)
                .ToList();

            //int a = 5;
            return View(shopingBasket);

        }

        // GET: ShoppingBasketsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShoppingBasketsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingBasketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShoppingBasketsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShoppingBasketsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShoppingBasketsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShoppingBasketsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
