using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Salon.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

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
    }
    
}
