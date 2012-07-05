using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using System.Web.Script.Serialization;
using MI.Web.Infrastructure;
using System.IO;
using hb;

namespace MI.WebUI.Controllers
{
    public class AngularController : hbController
    {
       static  dynamic   phones = new List<dynamic>();


       public AngularController()
       {
           if (phones.Count ==0)
           {
               fake_repository();
           }
       }

        public ActionResult Index()
        {
            return View();
        }

      
    

        [HttpPost]
        public ActionResult SavePhone()
        {

            var model = SqueezeJson();

            //update phone
            dynamic updatedphones = new List<dynamic>();

            foreach (var phone in phones)
            {
                if (phone.id.ToString() != model.id.ToString())
                {
                    updatedphones.Add(phone);
                }
            }

            updatedphones.Add(model);

            phones = updatedphones;
            
            return VidpubJSON(model);
        }


        [HttpPost]
        public ActionResult NewPhone()
        {

            var model = SqueezeJson();
            phones.Add(model);


            return VidpubJSON(model);
        }
        [HttpGet]
        public ActionResult GetPhoneDetail(string id)
        {

           dynamic phone = new ExpandoObject();

           
            phone.age = 0;
            phone.id = "motorola-xoom-with-wi-fi";
            phone.imageUrl = @"img/phones/motorola-xoom-with-wi-fi.0.jpg";
            phone.name = "Motorola XOOM\u2122 with Wi-Fi";
            phone.snippet = "The Next, Next Generation\r\n\r\nExperience the future with Motorola XOOM with Wi-Fi, the world's first tablet powered by Android 3.0 (Honeycomb).";

            return VidpubJSON(phone);

           // return Json(new { name = "abc", snippet = "something" }, JsonRequestBehavior.AllowGet);
        }
    
    
        [HttpGet]
        public ActionResult GetPhones()
        {
          

        
            return VidpubJSON(phones);
        }


        public void fake_repository()
        {
            phones.Add(new ExpandoObject());
            phones[0].age = 0;
            phones[0].id = "motorola-xoom-with-wi-fi";
            phones[0].imageUrl = @"img/phones/motorola-xoom-with-wi-fi.0.jpg";
            phones[0].name = "Motorola XOOM\u2122 with Wi-Fi";
            phones[0].snippet = "The Next, Next Generation\r\n\r\nExperience the future with Motorola XOOM with Wi-Fi, the world's first tablet powered by Android 3.0 (Honeycomb).";


            phones.Add(new ExpandoObject());
            phones[1].age = 1;
            phones[1].id = "motorola-xoom";
            phones[1].imageUrl = @"img/phones/motorola-xoom.0.jpg";
            phones[1].name = "MOTOROLA XOOM\u2122";
            phones[1].snippet = "The Next, Next Generation\n\nExperience the future with MOTOROLA XOOM, the world's first tablet powered by Android 3.0 (Honeycomb)";

            phones.Add(new ExpandoObject());
            phones[2].age = 2;
            phones[2].id = "motorola-atrix-4g";
            phones[2].imageUrl = @"img/phones/motorola-atrix-4g.0.jpg";
            phones[2].name = "MOTOROLA ATRIX\u2122 4G";
            phones[2].snippet = "MOTOROLA ATRIX 4G the world's most powerful smartphone.";
        }

    }
}
