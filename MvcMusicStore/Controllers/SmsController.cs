using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.TwiML.Mvc;
using Twilio.TwiML;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class SmsController : TwilioController
    {
        private MusicStoreEntities db = new MusicStoreEntities();
        //
        // GET: /Sms/

        public ActionResult Index(string Body)
        {
            string[] parts = Body.Split(' ' );
            if (parts.Count() != 2)
            {
                return new EmptyResult();
            }

            switch (parts[0])
            {
                case "status" :

                    var response = new TwilioResponse();
                    var order = db.Orders.Find(parts[1]);
                    if (order != null)
                    {
                        response.Sms(string.Format("The status of order '{0}' is: {1}", parts[1], order.Status));                        
                    }
                    else 
                    {
                        response.Sms(string.Format("No order with the id '{0}' could be located", parts[1]));
                    }

                    return TwiML(response);

                //add other sms commands here

                default :
                    return new EmptyResult();
            }

        }

    }
}
