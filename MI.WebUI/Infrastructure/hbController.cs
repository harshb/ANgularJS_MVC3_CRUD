using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Script.Serialization;
using MI.Web.Infrastructure;
using System.Dynamic;

namespace hb
{

    public  class hbController : Controller
    {

       //squeese jason from a post without having to write models
        //if we dont use this we will have to write models to cast each JSON request
        public  dynamic SqueezeJson()
        {
            var bodyText = "";
            using (var stream = Request.InputStream)
            {
                stream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(stream))
                    bodyText = reader.ReadToEnd();
            }
            if (string.IsNullOrEmpty(bodyText)) return null;
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] { new ExpandoObjectConverter() });

            return serializer.Deserialize(bodyText, typeof(ExpandoObject));
        }

        //pass in a List<dynamic>() and get a jason result back
        public ActionResult VidpubJSON(dynamic content)
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] { new ExpandoObjectConverter() });
            var json = serializer.Serialize(content);
            Response.ContentType = "application/json";
            return Content(json);
        }

    }
}
