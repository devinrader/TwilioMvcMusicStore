using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace MvcMusicStore.Controllers
{
    public class CallController : Controller
    {
        MvcMusicStore.Models.MusicStoreEntities db = new Models.MusicStoreEntities();
        //
        // GET: /Call/

        public ActionResult Index()
        {
            return View();
        }

    }
}
