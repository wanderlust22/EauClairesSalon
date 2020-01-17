using Microsoft.AspNetCore.Mvc;
using Salon.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Salon.Controllers
{
    public class ClientController : Controller
    {
        private readonly SalonContext _db;

        public ClientController(SalonContext db)
        {
            _db = db;
        }

        public ActionResult Create(int id)
        {
            Stylist theStylist = _db.Stylist.FirstOrDefault(stylist => stylist.StylistId == id);
            ViewBag.theStylist = theStylist;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            _db.Client.Add(client);
            _db.SaveChanges();
            return RedirectToAction("Details", "Stylist", new { id = client.StylistId});
        }

        public ActionResult Details(int id)
        {
            Client model = _db.Client.FirstOrDefault(client => client.ClientId == id);
            return View(model);
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