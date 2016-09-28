using ServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceStation.Controllers
{
    public class NewClientController : Controller
    {

        private ServiceStationDBEntities db = new ServiceStationDBEntities();

        //
        // GET: /NewClient/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(NewClient newClient)
        {
            List<Client> clients = db.Clients.Where(c => c.Name.Equals(newClient.Name) && c.Surname.Equals(newClient.Surname)).ToList();
            if (clients.Count != 0)
            {
                return View("Search", clients);
            }
            return View("NoClient");
        }

    }
}
