using Microsoft.AspNetCore.Identity;
using Session1112Identity.data;
using Session1112Identity.Models;
using Session1112Identity.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HRContext>();

// Step 1
builder.Services.AddIdentity<ApplicationUsers, IdentityRole>().
    AddEntityFrameworkStores<HRContext>();

builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
});

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Account/Login1";
    config.ExpireTimeSpan = TimeSpan.FromDays(2);
});

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

// step 2

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
