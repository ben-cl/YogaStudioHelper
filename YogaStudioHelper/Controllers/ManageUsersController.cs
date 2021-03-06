﻿using System;
using Database;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YogaStudioHelper.Controllers
{
    public class ManageUsersController : Controller
    {
        DBMaster db = new DBMaster();
        // GET: ManageUsers
        public ActionResult ManageUsers()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FindUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindUser(FormCollection collection)
        {
            string email = collection["Email"];
            IEnumerable<Yoga_User> userList = db.getUserByEmail(email);
            
            if (userList.Count() == 0)
            {
                ViewBag.FindClassMessage = "No users with an email containing " + email + " was found";
                return View();
            }
            else
            {
                TempData["userList"] = userList;
                return RedirectToAction("FindUserList");
            }
            
           
        }

        public ActionResult FindUserList()
        {
            if (TempData["userList"] != null)
            {
                IEnumerable<Yoga_User> c = TempData["userList"] as IEnumerable<Yoga_User>;
                return View(c);
            }
            else
            {
                IEnumerable<Yoga_User> c = TempData["List"] as IEnumerable<Yoga_User>;

                return View(c);
            }
        }

        [HttpGet]
        public ActionResult FindUserAdvanced()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindUserAdvanced(FormCollection collection)
        {
            string role = collection["role"];
            string email = collection["Email"];
            string fname =  collection["FirstName"];
            string lname = collection["LastName"];
            string phone = collection["Phone"];

            IEnumerable<Yoga_User> list = db.getUserAdvancedSearch(role, fname, lname, email, phone);

            if (list.Count() == 0)
            {
                ViewBag.FindClassMessage = "No users were found";
                return View();
            }
            else
            {
                TempData["userList"] = list;
                return RedirectToAction("FindUserListAdvanced");
            }
            
        }

        public ActionResult FindUserListAdvanced()
        {
            if (TempData["userList"] != null)
            {
                IEnumerable<Yoga_User> c = TempData["userList"] as IEnumerable<Yoga_User>;
                return View(c);
            }
            else
            {
                IEnumerable<Yoga_User> c = TempData["List"] as IEnumerable<Yoga_User>;

                return View(c);
            }
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        public ActionResult UserList()
        {
            return View();
        }

        public ActionResult EditUser()
        {
            return View();
        }

    }
}