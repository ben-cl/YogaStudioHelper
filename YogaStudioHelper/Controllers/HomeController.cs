﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Database;

namespace YogaStudioHelper.Controllers
{
    public class HomeController : Controller
    {
        DBMaster db = new DBMaster();
        [HttpGet]
        public ActionResult Homepage()
        {
            return View();
        }

    }
}