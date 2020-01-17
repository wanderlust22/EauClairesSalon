using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Salon.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Salon.Controllers
{
    public class StylistController : Controller
    {
        private readonly SalonContext _db;

        public StylistController(SalonContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Stylist> allStylists = _db.Stylist.ToList();
            return View(allStylists);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Stylist stylist)
        {
            _db.Stylist.Add(stylist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Stylist theStylist = _db.Stylist.FirstOrDefault(stylist => stylist.StylistId == id);
            List<Client> theirClients = _db.Client.Where(client => client.StylistId == id).ToList();
            ViewBag.theirClients = theirClients;
            return View(theStylist);
        }

        public ActionResult Edit(int id)
        {
            Stylist model = _db.Stylist.FirstOrDefault(stylist => stylist.StylistId == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Stylist theStylist)
        {
            _db.Entry(theStylist).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = theStylist.StylistId});
        }
        
        public ActionResult Delete(int id)
        {
            Stylist model = _db.Stylist.FirstOrDefault(stylist => stylist.StylistId == id);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteForReal(int id)
        {
            Stylist theStylist = _db.Stylist.FirstOrDefault(stylist => stylist.StylistId == id);
            _db.Stylist.Remove(theStylist);
            List<Client> clientList = _db.Client.Where(client => client.StylistId == id).ToList();
            foreach (Client client in clientList)
            {
                _db.Client.Remove(client);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    
}
