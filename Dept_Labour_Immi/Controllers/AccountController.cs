using Dept_Labour_Immi.Data;
using Dept_Labour_Immi.Helper;
using Dept_Labour_Immi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Dept_Labour_Immi.Dto;
using Microsoft.AspNetCore.Authorization;
using Dept_Labour_Immi.Enum;

namespace Dept_Labour_Immi.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contxt;
        private readonly IConfiguration _config;

        public AccountController(ApplicationDbContext context, IHttpContextAccessor contxt, IConfiguration config)
        {
            _context = context;
            _contxt = contxt;
            _config = config;
        }

        public int count = 0;

        [Authorize(Roles = ConstantValues.User_Admin)]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                await HttpContext.SignOutAsync();
                return RedirectToAction("Login", "Account");

            }
            return View(await _context.Users.ToListAsync());
        }

        //[Authorize(Roles = ConstantValues.User_Admin)]
        public async Task<IActionResult> Create(int? id)
        {
            if (HttpContext.Session.GetString("FirstUser")==ConstantValues.FirstUser)
            {
                ViewBag.AdminCount = 0;
                ViewBag.OfficerCount = 0;
                ViewBag.EntryCount = 0;
                HttpContext.Session.SetString("FirstUser", "");
                return View();
            }

            if (!User.IsInRole(ConstantValues.User_Admin))
                return RedirectToAction("Denied", "Account");

            ViewBag.AdminCount = await _context.Users.Where(x => x.Role == "Admin").CountAsync();
            ViewBag.OfficerCount = await _context.Users.Where(x => x.Role == "Officer").CountAsync();
            ViewBag.EntryCount = await _context.Users.Where(x => x.Role == "Entry").CountAsync();

            if (id == null || id == 0)
            {
                ViewBag.btnName = "Add New User";
                return View();
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            ViewBag.btnName = "Edit User";
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User users)
        {
            if (users.Id < 0)
                users.Id = 0;
            else
            {
                User alreadyHave = await _context.Users.FirstOrDefaultAsync(x => x.UserName == users.UserName);

                if (alreadyHave != null)
                {
                    ViewBag.AlreadyHave = alreadyHave.UserName + " is already have";
                    return View(users);
                }
            }

            PasswordHelper.CreatePasswordHash(users.Password, out byte[] hash, out byte[] salt);
            users.PasswordHash = hash;
            users.PasswordSalt = salt;

            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            if (_context.Users.Count() == 1)
                return RedirectToAction("Success");
            return RedirectToAction("Index");


        }

        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.AdminCount = await _context.Users.Where(x => x.Role == "Admin").CountAsync();
            ViewBag.OfficerCount = await _context.Users.Where(x => x.Role == "Officer").CountAsync();
            ViewBag.EntryCount = await _context.Users.Where(x => x.Role == "Entry").CountAsync();

            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [Authorize(Roles = ConstantValues.User_Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User user)
        {
            if (user.Password != null)
            {
                PasswordHelper.CreatePasswordHash(user.Password, out byte[] hash, out byte[] salt);
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = ConstantValues.User_Admin)]
        public async Task<IActionResult> Detail(int? id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpGet(ConstantValues.Login)]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var count = await _context.Users.CountAsync();
            if (count == 0)
            {
                ViewBag.UserCount = "QWRtaW5AMjAyMgvWssB";
                return View();
            }
                
            var userName = HttpContext.Session.GetString("UserName");
            var passwrod = HttpContext.Session.GetString("Password");
            if (userName != null && passwrod != null && userName != "" && passwrod != "")
            {
                ViewBag.USERNAME = userName;
                ViewBag.PASSWORD = passwrod;
                ViewBag.Yes = 1;
            }
            else
            {
                ViewBag.Yes = 0;
            }
            return View();
        }

        [HttpPost(ConstantValues.Login)]
        public async Task<IActionResult> Login(UserDto dto, string returnUrl)
        {
            var count = await _context.Users.CountAsync();
            if (count == 0)
            {
                ViewBag.UserCount = "QWRtaW5AMjAyMgvWssB";
                return View();
            }
            var getUser = await _context.Users.SingleOrDefaultAsync(u => u.UserName == dto.UserName);
            if (getUser != null)
            {
                if (PasswordHelper.VerifyPasswordHash(dto.Password, getUser.PasswordHash, getUser.PasswordSalt))
                {
                    var claims = new List<Claim>();

                    claims.Add(new Claim("username", getUser.UserName));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, getUser.UserName));
                    claims.Add(new Claim(ClaimTypes.Name, getUser.UserName));
                    claims.Add(new Claim(ClaimTypes.Role, getUser.Role));
                    var ClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var ClaimsPriciple = new ClaimsPrincipal(ClaimsIdentity);

                    if (dto.RememberMe)
                    {
                       // HttpContext.Session.SetString("UserName", dto.UserName);
                        HttpContext.Session.SetString("Password", dto.Password);
                    }
                    else
                    {
                        HttpContext.Session.SetString("UserName", "");
                        HttpContext.Session.SetString("Password", "");
                        //HttpContext.Session.Clear();
                    }
                    HttpContext.Session.SetString("UserName", dto.UserName);
                    HttpContext.Session.SetString("Role", getUser.Role);
                    await HttpContext.SignInAsync(ClaimsPriciple);
                    return RedirectToAction("Index", "Home");
                    // return Redirect(returnUrl);
                }
            }
            TempData["Error"] = "Error. User Name or Password is invalid";
            return View();
        }

        [Authorize(Roles = ConstantValues.User_Admin)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(st => st.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult Success()
        {
            return View();
        }

        [HttpGet("denied")]
        public IActionResult Denied()
        {
            return View();
        }

        public IActionResult ProveAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProveAdmin(string password)
        {
            var hash = _config.GetSection("AppSettings:encodePassword").Value;
            if(PasswordHelper.ProveAdminVerify(password, hash))
            {
                HttpContext.Session.SetString("FirstUser", "al");
                return RedirectToAction("Create", "Account");
            }
               
            ViewBag.Error = "Incorrect Password";
            return View();
        }
    }
}
