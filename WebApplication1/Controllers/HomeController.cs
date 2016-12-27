using System;
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
                        if (line.Contains("appversion"));
                        {
                            var startIdx = line.IndexOf("<span id=\'appversion\'>");
                            var endIdx = line.IndexOf("</");
                            var version = line.Substring(startIdx + 1, endIdx - startIdx - 1);
                            this.ViewBag.appversion = version;

                            startIdx = line.IndexOf("<span id=\'buildversion\'>");
                            endIdx = line.LastIndexOf("</");
                            var build = line.Substring(startIdx + 1, endIdx - startIdx - 1);
                            this.ViewBag.buildversion = build;
                            break;
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
