using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using PSI_Projektas_Komanda1.Models;

using Microsoft.AspNetCore.Localization;
using System.Globalization;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<PayPalConfig>(builder.Configuration.GetSection("PayPal"));

builder.Services.AddDistributedMemoryCache();
// Add session middleware
builder.Services.AddSession(options =>
{
	options.Cookie.Name = "Session";
	// Set a timeout for the session
	options.IdleTimeout = TimeSpan.FromSeconds(3600);
	//options.Cookie.IsEssential = true;
});


// Add HttpContextAccessor
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Use session middleware

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseRouting();
app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

Config.CreateSingletonInstance(app.Configuration);


app.Run();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var supportedCultures = new[]
{
    new CultureInfo("en-US")
};

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});



//builder.Services.Configure<RequestLocalizationOptions>(options =>
//{
//    var supportedCultures = new[] { new CultureInfo("en-US") };
//    options.DefaultRequestCulture = new RequestCulture("en-US");
//    options.SupportedCultures = supportedCultures;
//    options.SupportedUICultures = supportedCultures;
//});

//var supportedCultures = new[] { new CultureInfo("en-US") };
//app.UseRequestLocalization(new RequestLocalizationOptions
//{
//    DefaultRequestCulture = new RequestCulture("en-US"),
//    SupportedCultures = supportedCultures,
//    SupportedUICultures = supportedCultures
//});

