using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.TwiML.Mvc;
using Twilio.TwiML;
using MvcMusicStore.Models;
using System.Configuration;

namespace MvcMusicStore.Controllers
{
    public class CallController : TwilioController
    {
        private MusicStoreEntities db = new MusicStoreEntities();
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
                case "1": 
                    return RedirectToAction("OrderLookup"); 
                case "2": 
                    return RedirectToAction("PlaceAnOrder"); 
                case "3": 
                    return RedirectToAction("CustomerService");
                default:
                    return RedirectToAction("MainMenu");
            }            
        }

        public ActionResult OrderLookup() {
            var response = new TwilioResponse();
            response.BeginGather(new { actionUrl="", method="POST"});
            response.Say("Enter your order number");
            response.EndGather();

            return TwiML(response);
        }

        [HttpPost]
        public ActionResult OrderLookup(string Digits) {

            var response = new TwilioResponse();

            var order = db.Orders.Find(Digits);
            if (order != null)
            {
                response.Say(string.Format("The status of order {0} is {1}.", Digits, order.Status));
            }
            else {
                response.Say(string.Format("An order with the ID {0} could not be found.", Digits));
            }

            return TwiML(response);
        }

        //public ActionResult PlaceAnOrder() { }

        public ActionResult CustomerService() {
            var response = new TwilioResponse();
            response.Say("Hold on while we connect you");
            response.Dial("555-555-5555");

            return TwiML(response);
        }

        public ActionResult Click2Call()
        {
            var response = new TwilioResponse();
            response.Dial(ConfigurationManager.AppSettings["CallCenterPhoneNumber"]);

            return TwiML(response);
        }

    }
}
