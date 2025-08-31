using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;
using PortfolioApp.Web.Context;
using PortfolioApp.Web.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped<PortfolioContext>();

builder.Services.AddDbContext<PortfolioContext>();
builder.Services.AddControllersWithViews(opt => 
    opt.Filters.Add(new AuthorizeFilter())
);

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturumun 30 dakika sonra sona ermesi
    options.Cookie.HttpOnly = true; // Oturum çerezinin sadece HTTP isteklerinde eriþilebilir olmasý
    options.Cookie.IsEssential = true; // Oturum çerezinin GDPR gibi düzenlemelere göre gerekli olduðunu belirtir

});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "PortfolioAppAuthCookie";
        options.LoginPath = "/Auth/Login"; // Yetkilendirme gerektiren sayfalara yetkisiz eriþim olduðunda yönlendirilecek sayfa
        options.LogoutPath = "/Auth/Logout"; // Çýkýþ iþlemi için kullanýlacak yol
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Oturumun 30 dakika sonra sona ermesi
        options.SlidingExpiration = true; // Oturum süresini her istekte yenile sayfa deðiþtikçe 30 dk lýk sðre yenilenir
    });

builder.Services.AddDistributedMemoryCache(); // Bu satýr olmaz ise HttpContext.Session.SetString("UserName", user.UserName); þeklinde session'a data eklenemez!

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication(); // Kimlik doðrulama middleware'ini ekle
app.UseAuthorization();
// use authentication ve authorization sýralamasý önemli önce kimlik doðrulama sonra yetkilendirme
// ikisi arasýndaki fark: kimlik doðrulama (authentication) kullanýcýnýn kim olduðunu doðrularken,
// yetkilendirme (authorization) kullanýcýnýn hangi kaynaklara eriþebileceðini belirler.

app.MapStaticAssets();

app.UseSession(); // Oturum yönetimi middleware'ini ekle

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
