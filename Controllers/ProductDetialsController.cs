using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Configuration;
using RestSharp;
using System.Diagnostics.Metrics;
using System.Text;
using WebApplicationStore.Controllers.BusinessLayout;
using WebApplicationStore.Controllers.Classroom;
using WebApplicationStore.Models.Contexts;
using WebApplicationStore.Models.StoreDbModels;
using WebApplicationStore.Models.ViewModels;
using WebApplicationStore.Models.ViewModels.CustomModels;
using zarinpalasp.netcorerest.Models;

namespace WebApplicationStore.Controllers
{
    public class ProductDetialsController : Controller
    {
        private readonly officia1_StoreContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        UsersUtils _xxxx;


        public ProductDetialsController(UserManager<ApplicationUser> userManager, UsersUtils xxxx, ILogger<HomeController> logger, officia1_StoreContext context)
        {
            _context = context;
            //_logger = logger;
            _userManager = userManager;
            _xxxx = xxxx;
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


        public ActionResult Payment(int UserId , int ShoppingBasketId)
        {
            var user = _userManager.GetUserAsync(User);
            int userIddb = _xxxx.CheckUserId(user.Result.UserName);
 
            //tax + amount 
            var basketObjects = _context.ViewUserBasketsObjects
                .Where(x => x.ShoppingBasketId == ShoppingBasketId)
                .ToList();



            var SendProductsPrices = _context.BdSendProductsPrices
                .Where(x => basketObjects.Select(b => b.ProductId).Contains(x.ProductId)
                        )
                .ToList();

            var sD_Addresses = _context.SdAddresses
                .Include(s => s.City)
                .Include(s => s.User)
                .Where(x => x.UserId == userIddb)
                .Select(c => new SelectListItemCustom
                {
                    Value = c.Id.ToString(),
                    Text = c.Address,
                    Meta = c.CityId.ToString()
                })
                .ToList();

            if (SendProductsPrices.Count > 0)
            {
                // 4 ta join beshan
                ///BD_Cities + address
                ///BD_SendProductsPrice
                ///SD_Product
                //نتیجه میشه آدرس و نحوه ارسال محصول به استان های خاص 
            }


            //  send price 
            //var sendProductsPrice = _context.BdSendProductsPrices.Select(c => new SelectListItem
            //{
            //    Value = c.Id.ToString(),
            //    Text = c.Price + "-" + c.StateId + "-" + c.ProductId + "-" + c.Title
            //}).ToList();
            //ViewBag.SendProductsPrices = sendProductsPrice;


            // بازگشت به ویو در صورت خطا
            var model = new PaymentModelView
            {
                UserId = UserId,
                SelectedBasketId = ShoppingBasketId,
                sdAddressDropdown = sD_Addresses,
                ListBasketsObjects = basketObjects,
                //countryDropdown = countryDropdown,
                //stateDropdown = stateDropdown,
                //cityDropdown = cityDropdown,
                ////                SelectedCity = "-1" ,
                //SelectedCountryId = -1,
                //sdAddress = new SdAddress()
            };

            return View(model);
        }

        [HttpPost]
        public JsonResult SubmitDiscountCode(string DiscountCode)
        {
            var message = "کد تخفیف نا معتبر است"; 

            //var codeDetails = _context.SdCoupons.Where(x => x.Code.Equals(DiscountCode)).ToList().FirstOrDefault();
            var codeDetails = _context.SdCoupons.FirstOrDefault(x => x.Code.Equals(DiscountCode));

            if (codeDetails == null)
                return Json(new { message = message });

            string jsonResult = JsonConvert.SerializeObject(codeDetails);
            return Json(new { message = jsonResult });
 
        }


        [HttpPost]
        public JsonResult SubmitSendTypeCode(string CityId)
        {
            var message = "شهر نا معتبر است";

            var sendProductsPrice = _context.BdSendBoxPrices
                    .Where(x => x.StateId == _context.BdCities
                        .Where(c => c.Id == int.Parse(CityId))
                        .Select(c => c.StateId)
                        .FirstOrDefault()) 
                    .Select(c => new SelectListItemCustom
                    {
                        Value = c.Id.ToString(),
                        Text = c.Price + "-" + c.StateId + " - " + c.Title,
                        Meta = c.Price.ToString()
                    })
                    .ToList();


            if (sendProductsPrice == null)
                return Json(new { message = message });

            string jsonResult = JsonConvert.SerializeObject(sendProductsPrice);
            return Json(new { message = jsonResult });
        }





        private readonly ILogger<HomeController> _logger;
        string merchant = "e8a913e8-f089-11e6-8dec-005056a205be";
        string amount = "11000";
        string authority;
        string description = "خرید تستی ";
        string callbackurl = "https://localhost:7148/ProductDetials/VerifyByHttpClient";
         
        private static Dictionary<String, AuthorityInfo> authorities = new Dictionary<String, AuthorityInfo>();

        public class AuthorityInfo
        {
            public int BasketIdx { get; set; }
            public DateTime AddedTime { get; set; }
            public SdTransaction Transaction { get; set; }

            public AuthorityInfo(int basketIdx, SdTransaction transaction)
            {
                BasketIdx = basketIdx;
                AddedTime = DateTime.Now;
                Transaction = transaction;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult VerifyPayment()
        {

            // string authorityverify;

            try
            {
                VerifyParameters parameters = new VerifyParameters();


                if (HttpContext.Request.Query["Authority"] != "")
                {
                    authority = HttpContext.Request.Query["Authority"];
                }

                parameters.authority = authority;
                parameters.amount = amount;
                parameters.merchant_id = merchant;


                var client = new RestClient(URLs.verifyUrl);
                RestSharp.Method method = RestSharp.Method.Post;
                var request = new RestRequest("", method);

                request.AddHeader("accept", "application/json");

                request.AddHeader("content-type", "application/json");
                request.AddJsonBody(parameters);

                var response = client.ExecuteAsync(request);


                JObject jodata = JObject.Parse(response.Result.Content);

                string data = jodata["data"].ToString();

                JObject jo = JObject.Parse(response.Result.Content);

                string errors = jo["errors"].ToString();

                if (data != "[]")
                {
                    string refid = jodata["data"]["ref_id"].ToString();

                    ViewBag.code = refid;

                    return View();
                }
                else if (errors != "[]")
                {

                    string errorscode = jo["errors"]["code"].ToString();

                    return BadRequest($"error code {errorscode}");

                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return NotFound();
        }

        public async Task<IActionResult> PaymenBytHttpClient(string[] ids)
        {
            string SelectedBasketIdx = ids[0].Substring(0,ids[0].Length-1);
            string cityId = ids[1].Substring(0, ids[1].Length - 1);
            string addressId = ids[2].Substring(0, ids[2].Length - 1);
            string sendTypeId = ids[3].Substring(0, ids[3].Length - 1);
            string totalSum = ids[4].Substring(0, ids[4].Length - 1);
            string UserIdx = ids[5].Substring(0, ids[5].Length - 1);
            string DiscountCodeIDx = ids[6].Substring(0, ids[6].Length - 1);

            var userBaskets = _context.SdShoppingBaskets
                .Where(x => x.UserId == int.Parse(UserIdx) && x.Id == int.Parse(SelectedBasketIdx))
                .ToList();

            if (userBaskets.Count == 0)
                return Forbid();


            var userAddresses = _context.SdAddresses
                .Where(x => x.UserId == int.Parse(UserIdx) && 
                                x.Id == int.Parse(addressId) &&
                                x.CityId == int.Parse(cityId))
                .ToList();

            if (userAddresses.Count == 0)
                return Forbid();

            // یافتن StateId بدون تبدیل به لیست
            var stateId = _context.BdCities
                .Where(x => x.Id == int.Parse(cityId))
                .Select(x => x.StateId)
                .FirstOrDefault();

            // اگر stateId معتبر است، ادامه دهید
            BdSendBoxPrice sendType;
            if (stateId != null)
            {
                // دریافت stateSendTypes بدون تبدیل به لیست اضافی
                var stateSendTypes = _context.BdSendBoxPrices
                    .Where(x => x.Id == int.Parse(sendTypeId) &&
                                x.StateId == stateId)
                    .ToList();

                if (stateSendTypes.Count == 0)
                    return Forbid();

                sendType = stateSendTypes.FirstOrDefault();
            }
            else
            {
                return Forbid();
            }

            int sumInBackend = 0;
            int discountAmount = 0;
            int SumBasketDiscountAmount = 0;
            int SumShoppingBasketPrice = 0;
            int SumTaxAmount = 0;

            /////////////////////////   Baskets Objects    ////////////////////////////
            var userBasketsObjects = _context.ViewUserBasketsObjects
                .Where(x => x.UserId == int.Parse(UserIdx) && x.ShoppingBasketId == Int32.Parse(SelectedBasketIdx))
                .ToList();
            foreach (var item in userBasketsObjects)
            {
                sumInBackend = sumInBackend + (int)item.TotalPriceWithTax;
                SumShoppingBasketPrice = (int)SumShoppingBasketPrice + ((int)item.Count * (int)item.Price);
                SumTaxAmount = SumTaxAmount + ((int)item.TaxPercentage * ((int)item.Count * (int)item.Price)/100);
                SumBasketDiscountAmount = SumBasketDiscountAmount + (int)item.Discount;
            }

            //////////////////////////     Send Type      //////////////////////////////
            sumInBackend = sumInBackend + (int)sendType.Price;

            //////////////////////////        Coupon       /////////////////////////////
            
            if (DiscountCodeIDx.Length > 0)
            {
                var coupons = _context.SdCoupons
                    .Where(x => x.Id == int.Parse(DiscountCodeIDx))
                    .ToList();

                if (coupons.Count == 1)
                {
                    //sumInBackend = sumInBackend - (int)coupons.FirstOrDefault().MaxRialValue;
                    discountAmount = (sumInBackend * (int)coupons.FirstOrDefault().CouponPercent) / 100;
                    if (discountAmount > (int)coupons.FirstOrDefault().MaxRialValue)
                        discountAmount = (int)coupons.FirstOrDefault().MaxRialValue;
                    sumInBackend = sumInBackend - discountAmount;
                    if (sumInBackend < 0)
                        sumInBackend = 0;
                }
            }

            if (sumInBackend == int.Parse(totalSum))
            {
                amount = totalSum;
                try
                {
                    using (var client = new HttpClient())
                    {
                        zarinpalasp.netcorerest.Models.RequestParameters parameters = new zarinpalasp.netcorerest.Models.RequestParameters(merchant, amount, description, callbackurl, "", "");

                        var json = JsonConvert.SerializeObject(parameters);

                        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PostAsync(URLs.requestUrl, content);

                        string responseBody = await response.Content.ReadAsStringAsync();

                        JObject jo = JObject.Parse(responseBody);
                        string errorscode = jo["errors"].ToString();

                        JObject jodata = JObject.Parse(responseBody);
                        string dataauth = jodata["data"].ToString();
                        if (dataauth != "[]")
                        {
                            authority = jodata["data"]["authority"].ToString();
                            SdTransaction x = new SdTransaction();
                            x.ShoppingBasketId = int.Parse(SelectedBasketIdx);
                            x.SumTaxAmount = SumTaxAmount;
                            if(DiscountCodeIDx.Length >= 1)
                                x.DiscountCodeId = int.Parse(DiscountCodeIDx) ;

                            x.DiscountAmount = discountAmount;
                            x.SendAmount = (int)sendType.Price;
                            x.SumShoppingBasketPrice = SumShoppingBasketPrice;
                            x.SumShoppingBasketDiscount = SumBasketDiscountAmount;
                            x.AmountForPay = int.Parse(amount);
                            x.PaymentStatusId = 1;  //پرداخت نشده
                            x.PaymentTrackingNo = authority;
                            x.PaymentDate = DateTime.Now;

                            authorities.Add(authority, new AuthorityInfo(int.Parse(SelectedBasketIdx), x));


                            string gatewayUrl = URLs.gateWayUrl + authority;
                            return Redirect(gatewayUrl);
                        }
                        else
                        {
                            return BadRequest("error " + errorscode);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult VerifyByHttpClient(string Authority, string Status)
        {
            if (Status.Equals("OK"))
            {
                if (authorities.ContainsKey(Authority))
                {
                    var authorityInfo = authorities[Authority];
                    //Console.WriteLine($"BasketIdx: {authorityInfo.BasketIdx}, Added at: {authorityInfo.AddedTime}");

                    changeStatueOfShoppingBasket(authorityInfo.BasketIdx,1);

                    authorityInfo.Transaction.PaymentStatusId = 2;
                    _context.SdTransactions.Add(authorityInfo.Transaction);
                    _context.SaveChanges();
                    authorities.Remove(Authority);
                }
            }

            if (Status.Equals("NOK"))
            {
                if (authorities.ContainsKey(Authority))
                {
                    var authorityInfo = authorities[Authority];
                    //Console.WriteLine($"BasketIdx: {authorityInfo.BasketIdx}, Added at: {authorityInfo.AddedTime}");

                    changeStatueOfShoppingBasket(authorityInfo.BasketIdx,0);
                    _context.SdTransactions.Add(authorityInfo.Transaction);
                    _context.SaveChanges();
                    authorities.Remove(Authority);
                }
            }

            #region try

            //try
            //{

            //    VerifyParameters parameters = new VerifyParameters();


            //    if (HttpContext.Request.Query["Authority"] != "")
            //    {
            //        authority = HttpContext.Request.Query["Authority"];
            //    }

            //    parameters.authority = authority;

            //    parameters.amount = amount;

            //    parameters.merchant_id = merchant;


            //    using (HttpClient client = new HttpClient())
            //    {

            //        var json = JsonConvert.SerializeObject(parameters);

            //        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            //        HttpResponseMessage response = await client.PostAsync(URLs.verifyUrl, content);

            //        string responseBody = await response.Content.ReadAsStringAsync();

            //        JObject jodata = JObject.Parse(responseBody);

            //        string data = jodata["data"].ToString();

            //        JObject jo = JObject.Parse(responseBody);

            //        string errors = jo["errors"].ToString();

            //        if (data != "[]")
            //        {
            //            string refid = jodata["data"]["ref_id"].ToString();

            //            ViewBag.code = refid;

            //            return View();
            //        }
            //        else if (errors != "[]")
            //        {

            //            string errorscode = jo["errors"]["code"].ToString();

            //            return BadRequest($"error code {errorscode}");

            //        }
            //    }



            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            #endregion

            return Redirect("~/");
        }

        private void changeStatueOfShoppingBasket(int BasketIdx, int ok)
        {
            var CurrentBasket = _context.SdShoppingBaskets
                .Where(x => x.Id == BasketIdx)
                .FirstOrDefault();
            if (CurrentBasket != null)
            {
                if (ok == 1)
                {
                    //5
                    //در حال پردازش 
                    if (CurrentBasket != null)
                    {
                        CurrentBasket.StatusId = 5;
                    }
                }
                else
                {
                    //4
                    //در انتظار پرداخت  
                    CurrentBasket.StatusId = 4;
                }
                _context.SaveChanges();
            }
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
