using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Interfaces;
using Dept_Labour_Immi.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.AddControllers().AddJsonOptions(x =>
//                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions .PropertyNamingPolicy = null;});

builder.Services.AddControllersWithViews();

//al
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(10);
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // for session

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/login";
        option.AccessDeniedPath = "/denied";
    }); //al

builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(IBOD), typeof(BODRepo)); // new added -- mwl
builder.Services.AddScoped(typeof(IDOE), typeof(DOERepo));
builder.Services.AddScoped(typeof(IThaiCompany), typeof(ThaiCompanyRepo));
builder.Services.AddScoped(typeof(IOperation_1), typeof(Operation_1Repo));
builder.Services.AddScoped(typeof(IAgencies), typeof(AgenciesRepo));
builder.Services.AddScoped(typeof(IBlacklist), typeof(BlacklistRepo));
builder.Services.AddScoped(typeof(IOperation_2), typeof(Operation_2Repo));
builder.Services.AddScoped(typeof(IPenalty), typeof(PenaltyRepo));
builder.Services.AddScoped(typeof(IServiceforThaiWorker), typeof(ServiceforThaiWorkerRepo));
builder.Services.AddScoped(typeof(ICountry), typeof(CountryRepo));
builder.Services.AddScoped(typeof(IThaiSending),typeof(ThaiSendingRepo));
builder.Services.AddScoped(typeof(IInternationalSending), typeof(InternationalSendingRepo));

//builder.Services.Configure<IdentityOptions>(options =>
//{
//    // Password settings.
//    options.Password.RequireDigit = false;
//    options.Password.RequireLowercase = false;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireUppercase = false;
//    options.Password.RequiredLength = 4;
//    options.Password.RequiredUniqueChars = 0;

//    options.User.RequireUniqueEmail = false;

//});

var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
//app.MapRazorPages();

app.Run();
