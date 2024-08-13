using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationStore.Models.Contexts;
using WebApplicationStore.Models.ViewModels;

namespace WebApplicationStore.Controllers
{
    public class ProductDetialsController : Controller
    {
        private readonly officia1_StoreContext _context;

        // GET: ProductDetialsController
        public ActionResult Index()
        {
            Home homeViewModel = new Home();
            var listHome = _context.ViewHomes.ToList();

            homeViewModel.listMain = listHome;

            int a = 5;
            return View(homeViewModel);
        }

        // GET: ProductDetialsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductDetialsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductDetialsController/Create
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

        // GET: ProductDetialsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductDetialsController/Edit/5
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

        // GET: ProductDetialsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductDetialsController/Delete/5
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
