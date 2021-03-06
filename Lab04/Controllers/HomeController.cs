﻿using Lab04.Models;
using Lab04.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab04.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcommingCourse = _dbContext.Courses
                           .Include(c => c.Lecturer)
                           .Include(c => c.Category)
                           .Where(c => c.DateTime > DateTime.Now);

            return View(upcommingCourse);
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