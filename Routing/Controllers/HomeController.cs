using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Routing.DAL;

namespace Routing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult ListStops()
        {
            List<newEquipment> list;
            using (ModelEntity db = new ModelEntity())
            {
                list = db.newEquipment.ToList();
            }
            return View(list);
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult ListServiceHistory()
        {
            List<TrackServiceHistory> list;
            using (ModelEntity db = new ModelEntity())
            {
                list = db.TrackServiceHistory.ToList();
            }
            return View(list);
        }

        public ActionResult ServiceHistory(int id)
        {
            TrackServiceHistory track;
            using (ModelEntity db = new ModelEntity())
            {
                track = db.TrackServiceHistory.FirstOrDefault(t=>t.intServiceHistoryId == id);
            }

            if (track is null)
            {
                return View("Error");
            }
            
            return View(track);
        }
        [HttpPost]
        public ActionResult CreateStop(int id)
        {
            newEquipment equipment;
            using (ModelEntity db = new ModelEntity())
            {
                equipment = db.newEquipment.FirstOrDefault(t => t.intEquipmentID == id);
                equipment.bitActive = false;
                db.Entry(equipment).State = EntityState.Modified;

                TrackServiceHistory track = new TrackServiceHistory()
                {
                    intEquipmentID = id,
                    dRepairDate = DateTime.Now,
                    intlLaborHours = 5
                };
                db.TrackServiceHistory.Add(track);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return RedirectToRoute("Error");
                }
            }

            return View("ListServiceHistory");
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}