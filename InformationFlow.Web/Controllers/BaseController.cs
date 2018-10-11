using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InformationFlow.Web.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsCheckPhone(string phone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^[1]+\d{10}") ? true : false;
        }

        protected string RandomNum()
        {
            Random rd = new Random();
            return rd.Next(100000, 1000000).ToString();
        }
    }
}