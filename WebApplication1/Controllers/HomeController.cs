﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var path = Server.MapPath("~") + @"\README.md";
            using (var reader = System.IO.File.OpenText(path))
            {
                while (reader.EndOfStream == false)
                {
                    var line = reader.ReadLine();
                    if (line.Contains("appversion"))
                    {
                        var startIdx = line.IndexOf(">");
                        var endIdx = line.IndexOf("</");
                        var version = line.Substring(startIdx + 1, endIdx - startIdx - 1);
                        this.ViewBag.appversion = version;
                        break;
                    }
                }
                
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}