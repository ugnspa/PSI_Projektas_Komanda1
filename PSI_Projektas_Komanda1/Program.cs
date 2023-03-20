var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Add session middleware
builder.Services.AddSession(options =>
{
    // Set a timeout for the session
    options.IdleTimeout = TimeSpan.FromSeconds(3600);
});

// Add HttpContextAccessor
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Use session middleware
app.UseSession();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


