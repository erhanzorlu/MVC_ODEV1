using MVC_ODEV1.DesignPatterns.SingletonPattern;
using MVC_ODEV1.Models.ContextClasses;
using MVC_ODEV1.Models.Entities;
using MVC_ODEV1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ODEV1.Controllers
{
    public class HouseKeeperController : Controller
    {
        MyContext db;
        public HouseKeeperController()
        {
            db = DBTool._DBInstance;
        }
        public ActionResult Index()
        {
            List<HouseKeeperVM> house = db.HouseKeepers.Select(x => new HouseKeeperVM
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).ToList();

            return View(house);
        }
        public ActionResult AddHouseKeeper()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHouseKeeper(HouseKeeperVM vm)
        {
            HouseKeeper houseKeeper = new HouseKeeper()
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
            };
            db.HouseKeepers.Add(houseKeeper);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateHouseKeeper(int id)
        {
            HouseKeeperVM HouseVM = db.HouseKeepers.Where(x => x.ID == id).Select(x => new HouseKeeperVM
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName

            }).FirstOrDefault();

            return View(HouseVM);
        }

        [HttpPost]
        public ActionResult UpdateHouseKeeper(HouseKeeperVM vm)
        {
            HouseKeeper veri = db.HouseKeepers.Find(vm.ID);
            veri.FirstName = vm.FirstName;
            veri.LastName = vm.LastName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHouseKeeper(int id)
        {
            db.HouseKeepers.Remove(db.HouseKeepers.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}