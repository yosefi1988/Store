using Elasticsearch.Net;
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

        public AddressesController(ILogger<HomeController> logger, officia1_StoreContext context, UsersUtils xxxx)
        {
            _context = context;
            _logger = logger;
            _xxxx = xxxx;
        }

        // GET: Addresses
        public ActionResult Index()
        {
            var sD_Addresses = _context.SdAddresses
                .Include(s => s.City)
                .Include(s => s.User).ToList(); 

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

        //// GET: Addresses/Edit/5
        //public ActionResult Edit(int? id)
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
        //    ViewBag.CityID = new SelectList(db.BD_Cities, "ID", "Title", sD_Addresses.CityID);
        //    ViewBag.UserID = new SelectList(db.SD_Users, "ID", "Name", sD_Addresses.UserID);
        //    return View(sD_Addresses);
        //}

        //// POST: Addresses/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,UserID,CityID,Address,IsDefault,FullName,MobileNo")] SD_Addresses sD_Addresses)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(sD_Addresses).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CityID = new SelectList(db.BD_Cities, "ID", "Title", sD_Addresses.CityID);
        //    ViewBag.UserID = new SelectList(db.SD_Users, "ID", "Name", sD_Addresses.UserID);
        //    return View(sD_Addresses);
        //}

        //// GET: Addresses/Delete/5
        //public ActionResult Delete(int? id)
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

        //// POST: Addresses/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    SD_Addresses sD_Addresses = db.SD_Addresses.Find(id);
        //    db.SD_Addresses.Remove(sD_Addresses);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
