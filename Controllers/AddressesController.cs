using Elasticsearch.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Configuration;
using RestSharp;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApplicationStore.Controllers;
using WebApplicationStore.Controllers.BusinessLayout;
using WebApplicationStore.Controllers.Classroom;
using WebApplicationStore.Models.Contexts;
using WebApplicationStore.Models.StoreDbModels;
using WebApplicationStore.Models.ViewModels;
using zarinpalasp.netcorerest.Models;


namespace WebApplicationStoreAdmin.Controllers.Product
{
    public class AddressesController : Controller
    {
        private readonly officia1_StoreContext _context;
        private readonly ILogger<HomeController> _logger;
        UsersUtils _xxxx;
        private readonly UserManager<ApplicationUser> _userManager;

        public AddressesController(UserManager<ApplicationUser> userManager, ILogger<HomeController> logger, officia1_StoreContext context, UsersUtils xxxx)
        {
            _context = context;
            _logger = logger;
            _xxxx = xxxx;
            _userManager = userManager;
        }

        // GET: Addressesf
        public ActionResult Index()
        {
            var user = _userManager.GetUserAsync(User);
            int userIddb = _xxxx.CheckUserId(user.Result.UserName);

            var sD_Addresses = _context.SdAddresses
                .Include(s => s.City)
                .Include(s => s.User)
                .Where(s => s.User.Id == userIddb)
                .ToList();

            if (sD_Addresses == null || user == null)
            {
                return NotFound(); // استفاده از NotFound به جای HttpNotFound
            }
            if (userIddb != sD_Addresses.First().UserId)
            {
                return BadRequest();
            }
            return View(sD_Addresses);
        }

        //// GET: Addresses/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SD_Addresses sD_Addresses = db.SD_Addresses.Find(id);
        //    if (sD_Addresses == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(sD_Addresses);
        //}

        // GET: Addresses/Create
        public ActionResult Create()
        {

            IEnumerable<SelectListItem> countryDropdown = _context.BdCountries
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title
                }).ToList();

            IEnumerable<SelectListItem> stateDropdown = _context.BdStates
                .Where(x => x.CountryId == int.Parse(countryDropdown.First().Value))
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title
                })
                .ToList();

            IEnumerable<SelectListItem> cityDropdown = _context.BdCities
                .Where(x => x.StateId == int.Parse(stateDropdown.First().Value))
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title
                })
                .ToList();

            // بازگشت به ویو در صورت خطا
            var model = new CreateAddressModelView
            {
                countryDropdown = countryDropdown,
                stateDropdown = stateDropdown,
                cityDropdown = cityDropdown,
//                SelectedCity = "-1" ,
                SelectedCountryId = -1,
                sdAddress = new SdAddress()
            };


            return View(model); 
        }
        public IActionResult GetStates(int countryId)
        {
            var states = _context.BdStates
                .Where(s => s.CountryId == countryId)
                .Select(s => new { s.Id, s.Title })
                .ToList();

            return Json(states);
        }
        public IActionResult GetCities(int stateId)
        {
            var cities = _context.BdCities
                .Where(c => c.StateId == stateId)
                .Select(c => new { c.Id, c.Title })
                .ToList();

            return Json(cities);
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAddressModelView model)
        { 

            if (ModelState.IsValid)
            {
                int userIddb = _xxxx.CheckUserId(model.IdentityUserName);
                model.sdAddress.UserId = userIddb;
                _context.SdAddresses.Add(model.sdAddress);


                if ((bool) model.sdAddress.IsDefault)
                {
                    var addresses = _context.SdAddresses.Where(a => a.UserId == userIddb).ToList();
                    if (addresses != null && addresses.Count > 0)
                    {
                        foreach (var address in addresses)
                        {
                            address.IsDefault = false;
                        }
                    }
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        // نمایش نام فیلد
                        var fieldName = state.Key;

                        // نمایش پیام خطا
                        var errorMessage = error.ErrorMessage;
                        var exception = error.Exception; // اگر خطا ناشی از یک استثنا باشد، اینجا موجود است

                        // برای دیباگ یا لاگ می‌توانید از این خطاها استفاده کنید
                        Debug.WriteLine($"Field: {fieldName}, Error: {errorMessage}");
                        Debug.WriteLine($"Field: {fieldName}, Error: {errorMessage}");
                    }
                }

            }


            // بازگشت به ویو در صورت خطا
            IEnumerable<SelectListItem> countryDropdown = _context.BdCountries
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Title
                    }).ToList();
            var model2 = new CreateAddressModelView
            {
                countryDropdown = countryDropdown,
                //SelectedCity = "-1",
                SelectedCountryId = -1,
                sdAddress = new SdAddress()
            };


            return View(model2);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var address = _context.SdAddresses.Find(id);
            var user = _userManager.GetUserAsync(User); 
            if (address == null || user == null)
            {
                return NotFound(); // استفاده از NotFound به جای HttpNotFound
            }

            int userIddb = _xxxx.CheckUserId(user.Result.UserName);
            if (userIddb != address.UserId)
            {
                return BadRequest();
            }
 

            var selectedCity = _context.BdCities
                .Where(x => x.Id == address.CityId)
                .First();

            IEnumerable<SelectListItem> cityDropdown = _context.BdCities
                .Where(x => x.StateId == selectedCity.StateId)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title
                })
                .ToList();
             

            var selectedState = _context.BdStates
                .Where(x => x.Id == selectedCity.StateId)
                .First();

            IEnumerable<SelectListItem> stateDropdown = _context.BdStates
                .Where(x => x.CountryId == selectedState.CountryId)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title
                })
                .ToList();


            var selectedCountry = _context.BdCountries
                .Where(x => x.Id == selectedState.CountryId)
                .First();

            IEnumerable<SelectListItem> countryDropdown = _context.BdCountries
                .Where(x => x.Id == selectedCountry.Id)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title
                }).ToList();


            var model = new CreateAddressModelView
            {
                sdAddress = address,
                countryDropdown = countryDropdown,
                SelectedCountryId = selectedCountry.Id,
                stateDropdown = stateDropdown,
                SelectedStateId = selectedState.Id,
                cityDropdown = cityDropdown
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateAddressModelView model)
        {
            if (ModelState.IsValid)
            { 
                var user = _userManager.GetUserAsync(User);
                int userIddb = _xxxx.CheckUserId(model.IdentityUserName);

                var address = _context.SdAddresses.Find(model.sdAddress.Id);
                if (address == null || user == null)
                {
                    return NotFound(); // استفاده از NotFound به جای HttpNotFound
                }
                if (userIddb != address.UserId)
                {
                    return BadRequest();
                }

                address.CityId = model.sdAddress.CityId;
                address.Address = model.sdAddress.Address;
                address.FullName = model.sdAddress.FullName;
                address.MobileNo = model.sdAddress.MobileNo;
                address.IsDefault = model.sdAddress.IsDefault;

                if ((bool)model.sdAddress.IsDefault)
                {
                    var addresses = _context.SdAddresses.Where(a => a.UserId == address.UserId && a.Id != address.Id).ToList();
                    foreach (var addr in addresses)
                    {
                        addr.IsDefault = false;
                    }
                }

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        // نمایش نام فیلد
                        var fieldName = state.Key;

                        // نمایش پیام خطا
                        var errorMessage = error.ErrorMessage;
                        var exception = error.Exception; // اگر خطا ناشی از یک استثنا باشد، اینجا موجود است

                        // برای دیباگ یا لاگ می‌توانید از این خطاها استفاده کنید
                        Debug.WriteLine($"Field: {fieldName}, Error: {errorMessage}");
                        Debug.WriteLine($"Field: {fieldName}, Error: {errorMessage}");
                    }
                }

            }

            // اگر مدل نامعتبر است، اطلاعات دوباره بارگذاری شود
            //var countries = _context.BdCountries.Select(c => new SelectListItem
            //{
            //    Value = c.Id.ToString(),
            //    Text = c.Title
            //}).ToList();

            //var states = _context.BdStates.Where(s => s.CountryId == model.SelectedCountryId).Select(s => new SelectListItem
            //{
            //    Value = s.Id.ToString(),
            //    Text = s.Title
            //}).ToList();

            //var cities = _context.BdCities.Where(c => c.StateId == model.SelectedStateId).Select(c => new SelectListItem
            //{
            //    Value = c.Id.ToString(),
            //    Text = c.Title
            //}).ToList();

            //model.countryDropdown = countries;
            //model.stateDropdown = states;
            //model.cityDropdown = cities;

            return View();
        }


        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(sD_Addresses).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CityID = new SelectList(db.BD_Cities, "ID", "Title", sD_Addresses.CityID);
        //    ViewBag.UserID = new SelectList(db.SD_Users, "ID", "Name", sD_Addresses.UserID);
        //    return View(sD_Addresses);


        // GET: Addresses/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        { 
            if (id == null)
            {
                return BadRequest();
            }

            var address = _context.SdAddresses.Find(id);
            var user = _userManager.GetUserAsync(User);

            var city = _context.BdCities.Find(address.CityId);
            address.City.Title = city.Title; 
            if (address == null || user == null)
            {
                return NotFound(); // استفاده از NotFound به جای HttpNotFound
            }
            int userIddb = _xxxx.CheckUserId(user.Result.UserName);
            if (userIddb != address.UserId)
            {
                return BadRequest();
            }
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var address = _context.SdAddresses.Find(id);
            var user = _userManager.GetUserAsync(User);
            if (address == null || user == null)
            {
                return NotFound(); // استفاده از NotFound به جای HttpNotFound
            }
            int userIddb = _xxxx.CheckUserId(user.Result.UserName);
            if (userIddb != address.UserId)
            {
                return BadRequest();
            }
            _context.SdAddresses.Remove(address);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
