﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsFeedApplication.Controllers
{
    public class NewsFeedController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
