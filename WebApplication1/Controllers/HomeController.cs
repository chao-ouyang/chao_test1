﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public ActionResult Index()
        {
            try
            {
                this.Logger.Info("FunctionName=HomeController.Index()");

                var path = Server.MapPath("~") + @"\README.md";
                using (var reader = System.IO.File.OpenText(path))
                {
                    while (reader.EndOfStream == false)
                    {
                        var line = reader.ReadLine();
                        if (line.Contains("appversion"))
                        {
                            var startIdx = line.IndexOf("<span id=\'appversion\'>") + 22;
                            var endIdx = line.IndexOf("</");
                            var version = line.Substring(startIdx, endIdx - startIdx);
                            this.ViewBag.appversion = version;
                        }

                        if (line.Contains("buildversion"))
                        {
                            var startIdx = line.IndexOf("<span id=\'buildversion\'>") + 24;
                            var endIdx = line.LastIndexOf("</");
                            var build = line.Substring(startIdx, endIdx - startIdx);
                            this.ViewBag.buildversion = build;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Logger.Error(ex);
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
