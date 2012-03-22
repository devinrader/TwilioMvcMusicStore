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
            response.Play("http://twiliomvcmusicstore.apphb.com/Content/audio/greeting.mp3");
            response.Redirect("http://twiliomvcmusicstore.apphb.com/Call/MainMenu");
            return TwiML(response);
        }

        public ActionResult MainMenu()
        {
            var response = new TwilioResponse();
            response.BeginGather(new { actionUrl = "http://twiliomvcmusicstore.apphb.com/Call/MainMenu", method = "POST" });
            response.Say("To get the status of an order press one");
            response.Say("To place an order press two");
            response.Say("To speak to a customer service representative press three");
            response.EndGather();

           response.Redirect("http://twiliomvcmusicstore.apphb.com/Call/MainMenu");
            
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
            response.BeginGather(new { actionUrl = "http://twiliomvcmusicstore.apphb.com/Call/OrderLookup", method = "POST" });
            response.Say("Please enter your order number");
            response.EndGather();

            response.Redirect("http://twiliomvcmusicstore.apphb.com/Call/MainMenu");

            return TwiML(response);
        }

        [HttpPost]
        public ActionResult OrderLookup(string Digits) {

            var response = new TwilioResponse();

            var order = db.Orders.Find( int.Parse(Digits) );
            if (order != null)
            {
                response.Say(string.Format("The status of order {0} is {1}.", Digits, order.Status));
            }
            else {
                response.Say(string.Format("An order with the ID {0} could not be found.", Digits));
            }

            response.Redirect("http://twiliomvcmusicstore.apphb.com/Call/MainMenu");

            return TwiML(response);
        }

        //public ActionResult PlaceAnOrder() { }

        public ActionResult CustomerService() {
            var response = new TwilioResponse();
            response.Say("Hold on while we connect you");
            response.Dial(ConfigurationManager.AppSettings["CallCenterPhoneNumber"]);

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
