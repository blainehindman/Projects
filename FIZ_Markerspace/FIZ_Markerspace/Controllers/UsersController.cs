﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIZ_Markerspace.Models;

namespace FIZ_Markerspace.Controllers
{
    public class UsersController : Controller
    {
        private fiz_markerspaceEntities db = new fiz_markerspaceEntities();

        // GET: Users
        public ActionResult View_Users()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult User_Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create_User()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create_User(string AUTH_WSU_ID, string AUTH_PASSWORD, string WSU_ID, string RFID_TAG, string FIRST_NAME, string LAST_NAME, int ROLE, int EXP_LEVEL, string PASSWORD, string CREATION_DATE, string EST_GRAD_DATE)
        {
            //Authentication User Data
            User auth_user = db.Users.SingleOrDefault(user => user.wsu_id == AUTH_WSU_ID);
            //Check if WSU ID and RFID exits
            User check_exist_wsuid = db.Users.SingleOrDefault(user => user.wsu_id == WSU_ID);
            User check_exist_rfid = db.Users.SingleOrDefault(user => user.rfid_tag == RFID_TAG);

            //check exisitance
            if (check_exist_wsuid != null)
            {
                var return_data = new { result = false, message = "This WSU ID already exists!" };
                return Json(return_data, JsonRequestBehavior.AllowGet);
            }
            if (check_exist_rfid != null)
            {
                var return_data = new { result = false, message = "This RFID already exists!" };
                return Json(return_data, JsonRequestBehavior.AllowGet);
            }

            //set password to null if student
            if(ROLE == 1)
            {
                PASSWORD = null;
            }

            if ((auth_user != null && auth_user.password == AUTH_PASSWORD))
            {
                User user = new User();

                if(auth_user.role >= ROLE)
                {
                    user.user_id = Guid.NewGuid();
                    user.wsu_id = WSU_ID;
                    user.rfid_tag = RFID_TAG;
                    user.first_name = FIRST_NAME;
                    user.last_name = LAST_NAME;
                    user.role = ROLE;
                    user.exp_level = EXP_LEVEL;
                    user.password = PASSWORD;
                    user.creation_date = CREATION_DATE;
                    user.est_grad_date = EST_GRAD_DATE;

                    db.Users.Add(user);
                    db.SaveChanges();


                    var return_data = new { result = true, message = "You added " + FIRST_NAME + " " + LAST_NAME + "!" };
                    return Json(return_data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var return_data = new { result = false, message = "You do not have permission to add this user!" };
                    return Json(return_data, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                var return_data = new { result = false, message = "Your authentication credentials failed!" };
                return Json(return_data, JsonRequestBehavior.AllowGet);
            }

        }

        // GET: Users/Edit/5
        public ActionResult Edit_User(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Edit_User(Guid USER_ID, string WSU_ID, string RFID_TAG, string FIRST_NAME, string LAST_NAME, int ROLE, int EXP_LEVEL, string PASSWORD, string CREATION_DATE, string EST_GRAD_DATE)
        {
            User user = db.Users.Find(USER_ID);
            user.wsu_id = WSU_ID;
            user.rfid_tag = RFID_TAG;
            user.first_name = FIRST_NAME;
            user.last_name = LAST_NAME;
            user.role = ROLE;
            user.exp_level = EXP_LEVEL;
            user.password = PASSWORD;
            user.creation_date = CREATION_DATE;
            user.est_grad_date = EST_GRAD_DATE;

            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();

            return Json(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete_User(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete_User")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("View_Users");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}