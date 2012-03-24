using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.TwiML.Mvc;
using Twilio.TwiML;

namespace MvcMusicStore.Controllers
{
    public class CallCenterController : TwilioController
    {
        //
        // GET: /CallCenter/

        public ActionResult Index()
        {
            var response = new TwilioResponse();
            response.Pause(5);
            response.Say("Thanks for calling the Music Store");            
            return TwiML(response);






        }
    }
}
