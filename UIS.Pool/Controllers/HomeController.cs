﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using UIS.Pool.Services;

namespace UIS.Pool.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        [Route]
        [Route("Index")]
        [Route("Leagues")]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Rules()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Suggestions()
        {
            return View();
        }
        [Authorize]
        [Route("Manage-Leagues")]
        [Route("Manage-Results")]
        public ActionResult Index2()
        {
            return View("Index");
        }
    }
}