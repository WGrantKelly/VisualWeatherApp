﻿using System.Diagnostics;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using WeatherApp;
using WeatherApp.Models;

namespace MvcMovie.Controllers
{
    public class WeatherController : Controller
    {
        // 
        // GET: /Weather/ 

   
        public ActionResult Index()
        {
            if (IsMobile.isMobileBrowser())
            {
                return View("MobileIndex");
            }
            else
            {
                return View();
            }
        }
        // 
        // GET: /Weather/Welcome/ 
        [HttpPost]
        public ActionResult Forecast(WeatherApp.Models.ForecastModel model)
        {
            //if (ModelState.IsValid)
            //{
                Program prog = new Program();
                string location = model.Location;
                string url = prog.retrieveXML(location);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(url);

                //get string form for reference 
                WebClient web = new WebClient();
                string stringForm = web.DownloadString(url);
                //Console.WriteLine(stringForm);
                ForecastModel forecast = prog.findAllAttributes(xmlDoc, location);

            //}
            if (Request.Browser.IsMobileDevice)
            {
                return View("MobileForecast", forecast);
            }
            else
            {
                return View(forecast);
            }
        }
    }
}
