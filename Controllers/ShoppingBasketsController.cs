using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplicationStore.Controllers.BusinessLayout;
using WebApplicationStore.Controllers.Classroom;
using WebApplicationStore.Models.Contexts;
using WebApplicationStore.Models.StoreDbModels;
using WebApplicationStore.Models.ViewModels;
using WebApplicationStore.Models.ViewModels.CustomModels;

namespace WebApplicationStore.Controllers
{
    public class ShoppingBasketsController : Controller
    {
        private readonly officia1_StoreContext _context;
        UsersUtils _xxxx;
        private readonly UserManager<ApplicationUser> _userManager;

        public ShoppingBasketsController(UserManager<ApplicationUser> userManager, ILogger<HomeController> logger, officia1_StoreContext context, UsersUtils xxxx)
        {
            _context = context;
            //_logger = logger;
            _xxxx = xxxx;
            _userManager = userManager;
        }

        // GET: ShoppingBasketsController
        public ActionResult Index(int basketId)
        {
            //Query String = userId
            //int userIddb = _xxxx.CheckUserId(userId);
            var user = _userManager.GetUserAsync(User);
            if (user.Result != null)
            {

                int userIddb = _xxxx.CheckUserId(user.Result.UserName);

                ShoppingBasketDetails shopingBasket = new ShoppingBasketDetails();

                if (userIddb != 0)
                {
                    //var baskets = _context.ViewUserBaskets;
                    //var basketsOrginalList = baskets
                    //    .Where(x => x.UserId == userIddb)
                    //    .ToList();

                    //for (int i = 0; i < basketsOrginalList.Count; i++)
                    //{
                    //    ViewUserBasketCustom newCustomItem = new ViewUserBasketCustom();
                    //    newCustomItem = new ViewUserBasketCustom()
                    //    {
                    //        Id = basketsOrginalList[i].Id,
                    //        UserId = basketsOrginalList[i].UserId,
                    //        BasketStatus = basketsOrginalList[i].BasketStatus,
                    //        BasketStatusId = basketsOrginalList[i].BasketStatusId,
                    //        ShoppingBasketId = basketsOrginalList[i].ShoppingBasketId
                    //    };

                    //    if (basketsOrginalList[i].Id == basketId)
                    //    {
                    //        newCustomItem.isSelected = true;
                    //    }

                    //    if (shopingBasket.baskets == null)
                    //        shopingBasket.baskets = new List<ViewUserBasketCustom>();
                    //    shopingBasket.baskets.Add(newCustomItem);
                    //}

                    var basketsOrginalList = _context.ViewUserBaskets
                                            .Where(x => x.UserId == userIddb)
                                            .Select(basket => new ViewUserBasketCustom
                                            {
                                                Id = basket.Id,
                                                UserId = basket.UserId,
                                                BasketStatus = basket.BasketStatus,
                                                BasketStatusId = basket.BasketStatusId,
                                                ShoppingBasketId = basket.ShoppingBasketId,
                                                isSelected = basket.Id == basketId
                                            }).ToList();

                    shopingBasket.baskets = basketsOrginalList;
                }
                else
                {
                    shopingBasket.baskets = new List<ViewUserBasketCustom>();
                }

                if (basketId != 0)
                {
                    var basketObjects = _context.ViewUserBasketsObjects;
                    shopingBasket.basketObjects = basketObjects
                        .Where(x => x.ShoppingBasketId == basketId)
                        .ToList();
                }
                else
                {
                    shopingBasket.basketObjects = new List<Models.StoreDbModels.ViewUserBasketsObject>();
                }

                //int a = 5;
                return View(shopingBasket);
            }
            return BadRequest();
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
