using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Helpers
{
    public class CookieHelper
    {
        IHttpContextAccessor _httpContextAccessor;


        public CookieHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //public void writeCookie(string cookieName, string cookieValue, int? expireTime)
        //{
        //    CookieOptions option = new CookieOptions();

        //    if (expireTime.HasValue)
        //    {
        //        option.Expires = DateTime.Now.AddYears(expireTime.Value);
        //        option.IsEssential = true;
        //    }
        //    else
        //    {
        //        option.Expires = DateTime.Now.AddYears(5);
        //        option.IsEssential = true;
        //    }

        //    Response.Cookies.Append(cookieName, cookieValue, option);
        //}

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

    }
}
