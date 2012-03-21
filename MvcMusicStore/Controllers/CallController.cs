using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.TwiML.Mvc;
using Twilio.TwiML;

namespace MvcMusicStore.Controllers
{
    public class CallController : TwilioController
    {
        //
        // GET: /Call/

        public ActionResult Index()
        {
            var response = new TwilioResponse();
            response.Play("");
            response.Redirect("");
            //say the greeting and redirect
            return TwiML(response);
        }

        public ActionResult MainMenu()
        {
            var response = new TwilioResponse();
            response.BeginGather(new { actionUrl="", method="POST"});
            response.Say("Option 1");
            response.Say("Option 2");
            response.Say("Option 3");
            response.EndGather();

            
            return TwiML(response);
        }

        [HttpPost]
        public ActionResult MainMenu(string Digits)
        {
            switch(Digits)
            {
                case "1": return RedirectToAction("OrderLookup"); break;
                case "2": return RedirectToAction("PlaceAnOrder"); break;
                case "3": return RedirectToAction("CustomerService"); break;
                default:
                    return RedirectToAction("MainMenu");
            }

            
        }

        //public ActionResult OrderLookup() { }

        //public ActionResult PlaceAnOrder() { }

        //public ActionResult CustomerService() { }

    }
}
