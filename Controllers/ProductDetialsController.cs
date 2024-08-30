using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationStore.Models.Contexts;
using WebApplicationStore.Models.ViewModels; 


namespace WebApplicationStore.Controllers
{
    public class ProductDetialsController : Controller
    {
        private readonly officia1_StoreContext _context;

        public ProductDetialsController(ILogger<HomeController> logger, officia1_StoreContext context)
        {
            _context = context;
            //_logger = logger;
        }

        // GET: ProductDetialsController
        public ActionResult Index(int id)
        {
            ProductDetails productDetailsViewModel = new ProductDetails();

            var productlist = _context.ViewSiteProductDetails;
            var productColorlist = _context.ViewSiteProductDetailsColors;
            var productSizelist = _context.ViewSiteProductDetailsSizes;
            var productSimilarSizelist = _context.ViewSiteProductDetailsSimilarProductInSizes;
            var productSendPrices = _context.ViewSiteProductDetailsSendPrices;


            productDetailsViewModel.product = productlist.Where(x => x.Id == id).ToList().FirstOrDefault();
            productDetailsViewModel.productDetails_Colors = productColorlist.Where(x => x.ProductChargePropertiesId == id).ToList();
            productDetailsViewModel.productDetailsSize = productSizelist.Where(x => x.ProductChargePropertiesId == id).ToList();
            productDetailsViewModel.similarProductInSize = productSimilarSizelist.Where(x => x.ProductChargePropertiesId == id).ToList();
            productDetailsViewModel.productSendPrice = productSendPrices.Where(x => x.ProductId == productDetailsViewModel.product.Id).ToList();

            //int a = 5;
            return View(productDetailsViewModel);

        }


        // GET: ProductDetialsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Payment(int id)
        {
            // بازیابی لیست کشورها
            var countries = _context.BdCountries.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Title
            }).ToList();

            ViewBag.Countries = countries;



            //  لیست 
            var sendProductsPrice = _context.BdSendProductsPrices.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Price + "-" + c.StateId + "-" + c.ProductId + "-" + c.Title
            }).ToList();
            ViewBag.SendProductsPrices = sendProductsPrice;

            return View();
        }
        // اکشن برای دریافت استان‌ها بر اساس کشور انتخاب شده
        public IActionResult GetStates(int countryId)
        {
            var states = _context.BdStates
                .Where(s => s.CountryId == countryId)
                .Select(s => new { s.Id, s.Title })
                .ToList();

            return Json(states);
        }

        // اکشن برای دریافت شهرها بر اساس استان انتخاب شده
        public IActionResult GetCities(int stateId)
        {
            var cities = _context.BdCities
                .Where(c => c.StateId == stateId)
                .Select(c => new { c.Id, c.Title })
                .ToList();

            return Json(cities);
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
