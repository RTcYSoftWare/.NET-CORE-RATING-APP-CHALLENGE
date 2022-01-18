using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RatingApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Controllers
{
    public class UserController : Controller
    {
        RatingAppDBContext _context;
        IHttpContextAccessor _httpContextAccessor;


        public UserController(RatingAppDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            string userGuid = readCookie("user");

            var user = _context.Users.Where(x => x.GUID.ToString() == userGuid).FirstOrDefault();

            if (user != null)
            {
                return RedirectToRoute("home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();

            writeCookie("user", user.GUID.ToString(), 100);

            return RedirectToRoute("home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string email, string nameSurname, string password, string phone)
        {
            User user = new User();
            
            Guid guid = Guid.NewGuid();
            
            user.CreatedAt = DateTime.Now;
            user.Email = email;
            user.NameSurname = nameSurname;
            user.Password = password;
            user.Phone = phone;
            user.GUID = guid;
            user.Status = true;

            _context.Users.Add(user);
            _context.SaveChanges();

            writeCookie("user", user.GUID.ToString(), 100);

            return RedirectToRoute("login");
        }

        public IActionResult Logout()
        {
            deleteCookie("user");

            return RedirectToRoute("home");
        }

        public void deleteCookie(string cookieName)
        {
            Response.Cookies.Delete(cookieName);
        }

        public string readCookie(string cookieName)
        {
            string result = "";

            string value = _httpContextAccessor.HttpContext.Request.Cookies[cookieName];

            if (value != null)
            {
                result = value.ToString();
            }

            return result;
        }

        public void writeCookie(string cookieName, string cookieValue, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
            {
                option.Expires = DateTime.Now.AddYears(expireTime.Value);
                option.IsEssential = true;
            }
            else
            {
                option.Expires = DateTime.Now.AddYears(5);
                option.IsEssential = true;
            }

            Response.Cookies.Append(cookieName, cookieValue, option);
        }
    }
}
