using System;
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
    public class MachinesController : Controller
    {
        private fiz_markerspaceEntities db = new fiz_markerspaceEntities();

        // GET: Machines
        public ActionResult View_Machines()
        {
            return View(db.Machines.ToList());
        }

        // GET: Machines/Details/5
        public ActionResult Machine_Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machine machine = db.Machines.Find(id);
            if (machine == null)
            {
                return HttpNotFound();
            }
            return View(machine);
        }

        // GET: Machines/Create
        public ActionResult Create_Machine()
        {
            return View();
        }

        // POST: Machines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create_Machine(string AUTH_WSU_ID, string AUTH_PASSWORD, string MACHINE_NAME, string ROOM_NAME, double SERVICE_LEVEL, double CURRENT_THRESHOLD, int ROLE_ACCESS)
        {
            User auth_user = db.Users.SingleOrDefault(user => user.wsu_id == AUTH_WSU_ID);
            //Check if Machine exits
            Machine check_exist_machinename = db.Machines.SingleOrDefault(machine => machine.machine_name == MACHINE_NAME);

            //check exisitance
            if (check_exist_machinename != null)
            {
                var return_data = new { result = false, message = "This Machine Name already exists!" };
                return Json(return_data, JsonRequestBehavior.AllowGet);
            }

            if ((auth_user != null && auth_user.password == AUTH_PASSWORD))
            {
                Machine machine = new Machine();

                machine.machine_id = Guid.NewGuid();
                machine.room_id = Guid.NewGuid();
                machine.machine_name = MACHINE_NAME;
                machine.room_name = ROOM_NAME;
                machine.status = 0;
                machine.service_level = SERVICE_LEVEL;
                machine.usage_time = 0;
                machine.total_usage_time = 0;
                machine.service_flag = 0;
                machine.current_threshold = CURRENT_THRESHOLD;
                machine.role_access = ROLE_ACCESS;
                machine.hardware_service_flag = 0;

                db.Machines.Add(machine);
                db.SaveChanges();

                var return_data = new { result = true, message = "You added " + MACHINE_NAME + " " + "!" };
                return Json(return_data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var return_data = new { result = false, message = "Your authentication credentials failed!" };
                return Json(return_data, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Machines/Edit/5
        public ActionResult Edit_Machine(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machine machine = db.Machines.Find(id);
            if (machine == null)
            {
                return HttpNotFound();
            }
            return View(machine);
        }

        // POST: Machines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Machine([Bind(Include = "machine_id,room_id,machine_name,room_name,status,service_level,usage_time,total_usage_time,service_flag,current_threshold,role_access,hardware_service_flag")] Machine machine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(machine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(machine);
        }

        // GET: Machines/Delete/5
        public ActionResult Delete_Machine(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machine machine = db.Machines.Find(id);
            if (machine == null)
            {
                return HttpNotFound();
            }
            return View(machine);
        }

        // POST: Machines/Delete/5
        [HttpPost, ActionName("Delete_Machine")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Machine machine = db.Machines.Find(id);
            db.Machines.Remove(machine);
            db.SaveChanges();
            return RedirectToAction("View_Machines");
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
