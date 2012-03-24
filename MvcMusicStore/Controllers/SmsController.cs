using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.TwiML.Mvc;

namespace MvcMusicStore.Controllers
{
    public class SmsController : Controller
    {
        MvcMusicStore.Models.MusicStoreEntities db = new Models.MusicStoreEntities();
        //
        // GET: /Sms/

        public ActionResult Index()
        {
            return View();
        }

    }
}
