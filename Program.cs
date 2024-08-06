


using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplicationStore.Models;
using WebApplicationStore.Models.Contexts;
using WebApplicationStore.Repositories;

var builder = WebApplication.CreateBuilder(args);

string sqlServerConnectionString = builder.Configuration.GetConnectionString("RemoteSqlServerDatabaseConnectionString");

builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(sqlServerConnectionString));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            //options.Password.req
            //options.Password.RequiredLength = 5;

            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;
            //options.SignIn
            
            //options.Lockout
            options.User.RequireUniqueEmail = false;
            options.User.AllowedUserNameCharacters = "0123456789";
        }
    ).AddEntityFrameworkStores<AppDbContext>()
    //.AddDefaultUI()
    .AddDefaultTokenProviders()
    .AddErrorDescriber<PersianIdentityErrorDescriber>();

builder.Services.AddScoped<IMessageSender, MessageSender>();
builder.Services.AddDbContextPool<officia1_StoreContext>(options => options.UseSqlServer(sqlServerConnectionString));


builder.Services.AddRazorPages();
 

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

var app = builder.Build();
 


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();


app.Run();
