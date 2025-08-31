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
    options.Cookie.HttpOnly = true; // Oturum �erezinin sadece HTTP isteklerinde eri�ilebilir olmas�
    options.Cookie.IsEssential = true; // Oturum �erezinin GDPR gibi d�zenlemelere g�re gerekli oldu�unu belirtir

});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "PortfolioAppAuthCookie";
        options.LoginPath = "/Auth/Login"; // Yetkilendirme gerektiren sayfalara yetkisiz eri�im oldu�unda y�nlendirilecek sayfa
        options.LogoutPath = "/Auth/Logout"; // ��k�� i�lemi i�in kullan�lacak yol
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Oturumun 30 dakika sonra sona ermesi
        options.SlidingExpiration = true; // Oturum s�resini her istekte yenile sayfa de�i�tik�e 30 dk l�k s�re yenilenir
    });

builder.Services.AddDistributedMemoryCache(); // Bu sat�r olmaz ise HttpContext.Session.SetString("UserName", user.UserName); �eklinde session'a data eklenemez!

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

app.UseAuthentication(); // Kimlik do�rulama middleware'ini ekle
app.UseAuthorization();
// use authentication ve authorization s�ralamas� �nemli �nce kimlik do�rulama sonra yetkilendirme
// ikisi aras�ndaki fark: kimlik do�rulama (authentication) kullan�c�n�n kim oldu�unu do�rularken,
// yetkilendirme (authorization) kullan�c�n�n hangi kaynaklara eri�ebilece�ini belirler.

app.MapStaticAssets();

app.UseSession(); // Oturum y�netimi middleware'ini ekle

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
