using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceStation.Controllers
{
    public class CarController : Controller
    {
        private ServiceStationDBEntities db = new ServiceStationDBEntities();

        //
        // GET: /Car/

        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.Client);
            return View(cars.ToList());
        }

        //
        // GET: /Car/Details/5

        public ActionResult Details(int id = 0)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        public ActionResult Orders(int id)
        {
            List<Order> orders = db.Orders.Where(o => o.IdCar.Equals(id)).ToList();
            return View(orders);
        }

        //
        // GET: /Car/Create

        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(db.Clients, "IdClient", "Name");
            return View();
        }

        //
        // POST: /Car/Create

        [HttpPost]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(db.Clients, "IdClient", "Name", car.IdClient);
            return View(car);
        }

        //
        // GET: /Car/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.Clients, "IdClient", "Name", car.IdClient);
            return View(car);
        }

        //
        // POST: /Car/Edit/5

        [HttpPost]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.Clients, "IdClient", "Name", car.IdClient);
            return View(car);
        }

        //
        // GET: /Car/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        //
        // POST: /Car/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            List<Order> orders = db.Orders.ToList();
            int count = 0;
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].IdCar.Equals(id))
                {
                    count++;
                }
            }
            if (count == 0)
            {
                db.Cars.Remove(car);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}