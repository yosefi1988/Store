using Elasticsearch.Net;
using Microsoft.AspNetCore.Mvc;
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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApplicationStore.Controllers.BusinessLayout;
using WebApplicationStore.Models.Contexts;
using WebApplicationStore.Models.ViewModels;
using zarinpalasp.netcorerest.Models;

namespace WebApplicationStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string merchant = "e8a913e8-f089-11e6-8dec-005056a205be";
        string amount = "1100";
        string authority;
        string description = "خرید تستی ";
        string callbackurl = "http://localhost:2812/Home/VerifyByHttpClient";
        UsersUtils _xxxx;


        private readonly officia1_StoreContext _context; 

        public HomeController(ILogger<HomeController> logger, officia1_StoreContext context, UsersUtils xxxx)
        {
            _context = context;
            _logger = logger;
            _xxxx = xxxx;

        }

        public IActionResult Index()
        {
            Home homeViewModel = new Home();
            var listHome = _context.ViewSiteHomes.ToList();

            homeViewModel.listMain = listHome;

            int a = 5;
            return View(homeViewModel); 
        }

        public IActionResult AddToBasket(String userId, int _productChargePropertiesId, int basketId)
        {
            Home homeViewModel = new Home();
            var listHome = _context.ViewSiteHomes.ToList();

            homeViewModel.listMain = listHome;

            int xNewcount = _xxxx.AddItemToBasket( userId, _productChargePropertiesId, basketId);

            int a = 5;
            return Index();
        }
        public IActionResult RemoveFromBasket(String userId, int _productChargePropertiesId, int basketId)
        {
            //Home homeViewModel = new Home();
            //var listHome = _context.ViewSiteHomes.ToList();

            //homeViewModel.listMain = listHome;

            int xNewcount = _xxxx.RemoveItemFromBasket(userId, _productChargePropertiesId, basketId);

            int a = 5;
            return Index();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Payment()
        {


            //try
            //{
            //    RequestParameters Parameters = new RequestParameters(merchant, amount, description, callbackurl, "", "");



            //    //be dalil in ke metadata be sorate araye ast va do meghdare mobile va email dar metadata gharar mmigirad
            //    //shoma mitavanid in maghadir ra az kharidar begirid va set konid dar gheir in sorat khali ersal konid

            //    var client = new RestClient(URLs.requestUrl);

            //    Method method = Method.Post;

            //    var request = new RestRequest("", method);

            //    request.AddHeader("accept", "application/json");

            //    request.AddHeader("content-type", "application/json");

            //    request.AddJsonBody(Parameters);

            //    var requestresponse = client.ExecuteAsync(request);

            //    JObject jo = JObject.Parse(requestresponse.Result.Content);

            //    string errorscode = jo["errors"].ToString();

            //    JObject jodata = JObject.Parse(requestresponse.Result.Content);

            //    string dataauth = jodata["data"].ToString();


            //    if (dataauth != "[]")
            //    {


            //        authority = jodata["data"]["authority"].ToString();

            //        string gatewayUrl = URLs.gateWayUrl + authority;

            //        return Redirect(gatewayUrl);

            //    }
            //    else
            //    {


            //        return BadRequest("error " + errorscode);


            //    }


            //}

            //catch (Exception ex)
            //{
            //    //    throw new Exception(ex.Message);


            //}
            return null;
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

        public async Task<IActionResult> PaymenBytHttpClient()
        {

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
            return NotFound();
        }

        public async Task<IActionResult> VerifyByHttpClient()
        {
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


                using (HttpClient client = new HttpClient())
                {

                    var json = JsonConvert.SerializeObject(parameters);

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(URLs.verifyUrl, content);

                    string responseBody = await response.Content.ReadAsStringAsync();

                    JObject jodata = JObject.Parse(responseBody);

                    string data = jodata["data"].ToString();

                    JObject jo = JObject.Parse(responseBody);

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



            }
            catch (Exception ex)
            {

                throw ex;
            }
            return NotFound();
        }



    }
}
