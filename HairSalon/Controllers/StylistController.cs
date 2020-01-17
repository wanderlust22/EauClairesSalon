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
            Client model = _db.Client.FirstOrDefault(client => client.ClientId == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Client theClient)
        {
            _db.Entry(theClient).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Details", "Stylist", new { id = theClient.StylistId});
        }
        
        public ActionResult Delete(int id)
        {
            Client model = _db.Client.FirstOrDefault(client => client.ClientId == id);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteForReal(int id)
        {
            Client theClient = _db.Client.FirstOrDefault(client => client.ClientId == id);
            _db.Client.Remove(theClient);
            _db.SaveChanges();
            return RedirectToAction("Details", "Stylist", new { id = theClient.StylistId});
        }
    }
    
}
