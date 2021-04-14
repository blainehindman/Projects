using FIZ_Markerspace.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FIZ_Markerspace.Views
{
    public class RoomsController : Controller
    {
        private fiz_markerspaceEntities db = new fiz_markerspaceEntities();

        // GET: Rooms
        public ActionResult View_Rooms()
        {
            return View(db.Rooms.ToList());
        }

        // GET: Rooms/Details/5
        public ActionResult Room_Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Rooms/Create
        public ActionResult Create_Room()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create_Room(string AUTH_WSU_ID, string AUTH_PASSWORD, string ROOM_NAME)
        {
            User auth_user = db.Users.SingleOrDefault(user => user.wsu_id == AUTH_WSU_ID);
            //Check if Room exits
            Room check_exist_roomname = db.Rooms.SingleOrDefault(room => room.room_name == ROOM_NAME);

            //check exisitance
            if (check_exist_roomname != null)
            {
                var return_data = new { result = false, message = "This Room Name already exists!" };
                return Json(return_data, JsonRequestBehavior.AllowGet);
            }

            if ((auth_user != null && auth_user.password == AUTH_PASSWORD))
            {
                Room room = new Room();

                if (auth_user.role >= 3)
                {
                    room.room_id = Guid.NewGuid();
                    room.room_name = ROOM_NAME;

                    db.Rooms.Add(room);
                    db.SaveChanges();

                    var return_data = new { result = true, message = "You added " + ROOM_NAME + " " + "!" };
                    return Json(return_data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var return_data = new { result = false, message = "You do not have permission to add this room!" };
                    return Json(return_data, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var return_data = new { result = false, message = "Your authentication credentials failed!" };
                return Json(return_data, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Rooms/Edit/5
        public ActionResult Edit_Room(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Edit_Room(Guid ROOM_ID, string ROOM_NAME)
        {
            Room room = db.Rooms.Find(ROOM_ID);
            room.room_id = ROOM_ID;
            room.room_name = ROOM_NAME;

            db.Entry(room).State = EntityState.Modified;
            db.SaveChanges();

            return Json(room);
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete_Room(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete_Room")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
            db.SaveChanges();
            return RedirectToAction("View_Rooms");
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
