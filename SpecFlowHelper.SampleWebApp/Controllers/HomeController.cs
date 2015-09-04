﻿using System.Threading;
using System.Web.Mvc;

namespace SpecFlowHelper.SampleWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BrowserSteps()
        {
            return View();
        }

        public ActionResult ComboboxSteps()
        {
            return View();
        }

        public ActionResult WindowWithIframes()
        {
            return View();
        }

        public ActionResult IFrameFast()
        {
            return View();
        }

        public ActionResult IFrameSlow1()
        {
            Thread.Sleep(5000);
            return View();
        }

        public ActionResult IFrameSlow2()
        {
            Thread.Sleep(5000);
            return View();
        }
    }
}