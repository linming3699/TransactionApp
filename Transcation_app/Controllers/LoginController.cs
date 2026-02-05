using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Transcation_app.Dtos;
using Transcation_app.Interfaces;
using Transcation_app.Models;

namespace Transcation_app.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly TransactionDbContext _context;

        public LoginController(TransactionDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDto dto)
        {
            if (ModelState.IsValid)
            {
                var user = (from a in _context.Users
                            where a.Email == dto.Email
                            && a.Password == dto.Password
                            select a).SingleOrDefault();

                if (user == null)
                {
                    ViewBag.Message = "信箱或密碼錯誤";
                    return View(dto);
                }
                else
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, dto.Email),
                    new Claim(ClaimTypes.Name,user.Name),
                    new Claim("UserId",user.Id.ToString())
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(dto);
            }
        }
        public async Task<IActionResult> SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromForm] SignUpDto dto)
        {
            if (ModelState.IsValid)
            {
                var email = (from a in _context.Users
                             where a.Email == dto.Email
                             || a.Name == dto.UserName
                             select a).SingleOrDefault();
                if (email == null)
                {
                    User _user = new User
                    {
                        Name = dto.UserName,
                        Email = dto.Email,
                        Password = dto.Password,
                    };
                    _context.Users.Add(_user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.Message = "信箱或使用者名稱已被註冊";
                    return View(dto);
                }
            }
            else
            {
                return View(dto);
            }
        }
    }
}
