using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab4.Models;
using Microsoft.AspNetCore.Http;

namespace lab4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Controls()
        {
            return View();
        }

        public IActionResult TextBox()
        {
            if (Request.Method == "POST")
            {
                ViewData["textBoxValue"] = Request.Form["value"];
            }
            return View();
        }

        public IActionResult TextArea()
        {
            if (Request.Method == "POST")
            {
                ViewData["textAreaValue"] = Request.Form["value"];
            }
            return View();
        }

        public IActionResult CheckBox()
        {
            if (Request.Method == "POST")
            {
                if (Request.Form["value"] == "True")
                {
                    ViewData["textBoxValue"] = Request.Form["value"];
                }
                else
                {
                    ViewData["textBoxValue"] = "False";
                }
            }
            return View();
        }

        public IActionResult Radio()
        {
            if (Request.Method == "POST")
            {
                ViewData["radioValue"] = Request.Form["value"];
            }
            return View();
        }

        public IActionResult DropDownList()
        {
            if (Request.Method == "POST")
            {
                ViewData["dropDownListValue"] = Request.Form["value"];
            }
            return View();
        }

        public IActionResult ListBox()
        {
            if (Request.Method == "POST")
            {
                ViewData["ListBoxValue"] = Request.Form["value"];
            }
            return View();
        }

        public IActionResult PasswordReset()
        {
            if (Request.Method == "POST")
            {
                ViewData["isCodeNeed"] = "Yes";
            }
            return View();
        }

        public IActionResult SignUp()
        {
            if (Request.Method == "POST" && Request.Form.ContainsKey("firstName"))
            {
                ViewData["firstStageIsComplete"] = "Yes";
                HttpContext.Session.SetString("firstName", Request.Form["firstName"]);
                HttpContext.Session.SetString("lastName", Request.Form["lastName"]);
                HttpContext.Session.SetString("day", Request.Form["day"]);
                HttpContext.Session.SetString("month", Request.Form["month"]);
                HttpContext.Session.SetString("year", Request.Form["year"]);
                HttpContext.Session.SetString("gender", Request.Form["gender"]);
            }
            else if (Request.Method == "POST" && Request.Form.ContainsKey("email"))
            {
                ViewData["secondStageIsComplete"] = "Yes";
                ViewData["firstName"] = HttpContext.Session.GetString("firstName");
                ViewData["lastName"] = HttpContext.Session.GetString("lastName");
                ViewData["day"] = HttpContext.Session.GetString("day");
                ViewData["month"] = HttpContext.Session.GetString("month");
                ViewData["year"] = HttpContext.Session.GetString("year");
                ViewData["gender"] = HttpContext.Session.GetString("gender");
                ViewData["email"] = Request.Form["email"];
                if (Request.Form["password"] == Request.Form["confirmPassword"])
                {
                    ViewData["password"] = Request.Form["password"]; //HERE
                }
                else
                {
                    ViewData["password"] = "passwords dont match";
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
