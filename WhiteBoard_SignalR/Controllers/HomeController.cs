using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WhiteBoard_SignalR.Controllers
{
    public class HomeController : Controller
    {
        string url = "";
        public IActionResult Index(string p)
        {
            ViewData["IsNewGroup"] = false;
            if (string.IsNullOrWhiteSpace(p))
            {


                Guid g = Guid.NewGuid();
                p = Convert.ToBase64String(g.ToByteArray());
                p = p.Replace("=", "");
                p = p.Replace("+", "");
                ViewData["IsNewGroup"] = true;
                //  ViewData["url"] = Request.Url.AbsoluteUri.ToString() + "?p=" + p;
                url = "https://localhost:44366/";
                ViewData["url"] = url + "?p=" + p;

            }
            else
            {
                //  ViewData["url"] = Request.Url.AbsoluteUri.ToString();
                ViewData["url"] = url + "?p=" + p;
            }

            ViewData["GroupName"] = p;
            ViewBag.GroupName = p;

            return View();
        }
    }
}
