// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplicationStore.Controllers.BusinessLayout;
using WebApplicationStore.Controllers.Classroom;
using WebApplicationStore.Models.Contexts;
using WebApplicationStore.Models.StoreDbModels;
using WebApplicationStore.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplicationStore.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMessageSender _messageSender;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly officia1_StoreContext _context;
        private UsersUtils _usersUtils;

        public RegisterModel(
            IMessageSender messageSender,
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            officia1_StoreContext context,
            UsersUtils usersUtils)
        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _logger = logger; 
            _messageSender = messageSender;
            _context = context;
            _usersUtils = usersUtils;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            ///// <summary>
            /////     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            /////     directly from your code. This API may change or be removed in future releases.
            ///// </summary>
            //[Required]
            //[EmailAddress]
            //[Display(Name = "Email")]
            //public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "شماره موبایل الزامی است")] 
            [Display(Name = "شماره موبایل")]
            //[Remote("IsUserNameUsed", "Validations", ErrorMessage = "UserName already exists", HttpMethod = "post",AdditionalFields ="_requestVerificationToken")]
            public string Mobile { get; set; }


            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "رمز عبور")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "تکرار رمز عبور")]
            [Compare("Password", ErrorMessage = "رمز عبور وارد شده مطابقت ندارد")]
            public string ConfirmPassword { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsUserNameUsed(string mobile = null)
        {
            var user = await _userManager.FindByEmailAsync(mobile);
            //if (user == null) return Json(true);
            if (user == null) return new JsonResult(true);
            return new JsonResult(false);
        }
         
        public async Task OnGetAsync(string returnUrl = null)
        {
            //ReturnUrl = returnUrl;
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();


            if (_signInManager.IsSignedIn(User))
                Response.Redirect("./Logout");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (_signInManager.IsSignedIn(User))
                RedirectToPage("./Logout");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var applicationUserObj = CreateAspNetUser();

                //classroom
                var applicationUserTmp = new ApplicationUser()
                {
                    Email = "",
                    PasswordHash = "",
                    Age = 20
                };
                applicationUserObj.Age = 21;

                await _userStore.SetUserNameAsync(applicationUserObj, Input.Mobile, CancellationToken.None);
                //await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(applicationUserObj, Input.Password);
                 
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var requestRoles = new List<string>() { string.Empty };
                    requestRoles.Add("کاربر عادی");
                    await _userManager.AddToRoleAsync(applicationUserObj, "NORMAL");
                    var userId = await _userManager.GetUserIdAsync(applicationUserObj);


                    prepareUserData(userId, Input.Mobile);


                    // emailConfirmation
                    var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUserObj);
                    //forget password
                    //var emailConfirmationToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                    //var emailmessage = Url.Action("Action", "Controller", new { username = user.UserName, token = emailConfirmationToken }, Request.Scheme);
                    //await _messageSender.SendEmailAsync(Input.Mobile, "subject", emailmessage,false);
                    sendEmail();
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //}
                    //else
                    //{
                        await _signInManager.SignInAsync(applicationUserObj, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    //}
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private void prepareUserData(string userGUID, string mobile)
        {
            SdUser user = new SdUser();
            user.Mobile = mobile;
            user.Password = mobile.Substring(mobile.Length -4 , 4);
            user.AspNetUserId = userGUID;
            user.JoinDate = DateTime.Now;
            _context.SdUsers.Add(user);
            _context.SaveChanges();

            List<SdShoppingBasket> aaaa = new List<SdShoppingBasket>(); 
            aaaa.Add(new SdShoppingBasket()
            {
                UserId = user.Id,
                StatusId = 1,
                CreatedOn = DateTime.Now
            });
            aaaa.Add(new SdShoppingBasket()
            {
                UserId = user.Id,
                StatusId = 2,
                CreatedOn = DateTime.Now
            });
            aaaa.Add(new SdShoppingBasket()
            {
                UserId = user.Id,
                StatusId = 3,
                CreatedOn = DateTime.Now
            }); 
            _context.SdShoppingBaskets.AddRange(aaaa);
            _context.SaveChanges();
        }

        private void sendEmail()
        {
             
        }
        private void confirmEmail0()
        {

        }
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string username , string token)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(token))
            {
                return NotFound();
            }
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) { return NotFound(); }

            //ConfirmEmail
            var result  = await _userManager.ConfirmEmailAsync(user, token);

            //ResetPasswordA
            //var result = await _userManager.ResetPasswordAsync(user, token,newPassword);

            return Content(result.Succeeded ? "Confirmed" : "not Confirmed");
        }

        private ApplicationUser CreateAspNetUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
