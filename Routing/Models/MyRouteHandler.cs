using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;
using System.Xml.Linq;

namespace Routing.Models
{
    public class MyRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new MyHttpHandler(requestContext.RouteData.Values);
        }
    }

    public class MyHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        private RouteValueDictionary _values { get; set; }
        public MyHttpHandler(RouteValueDictionary values)
        {
            _values = values;
        }
        public void ProcessRequest(HttpContext context)
        {
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 30, 59);

            if (DateTime.Now > date)
            {
                XDocument xdoc = new XDocument();
                XElement root = new XElement("root");
                XElement id = new XElement("id", _values["id"]);
                XElement createDate = new XElement("createDate", DateTime.Now);
                root.Add(id);
                root.Add(createDate);
                xdoc.Add(root);
                xdoc.Save($"newStop.xml{_values["id"]}");
            }
            context.Response.Write("");
        }
    }





}