using Microsoft.AspNetCore.Mvc;
using Salon.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

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

    }
}