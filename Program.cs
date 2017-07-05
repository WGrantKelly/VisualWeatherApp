using System;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using System.IO;

namespace CSharpPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("lets look at todays weather!");
            Console.WriteLine("enter a city to retrieve the report: ");
            string location = Console.ReadLine();
            String url = retrieveXML(location);        
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            //get string form for reference 
            WebClient web = new WebClient();
            String stringForm = web.DownloadString(url);
            //Console.WriteLine(stringForm);
            findAllAttributes(xmlDoc);
            Console.ReadKey();
            
        }

        private static void findAllAttributes(XmlDocument xmlDoc)
        { 
            XmlNodeList symbols = xmlDoc.GetElementsByTagName("Symbol");
            if(symbols[0]!=null)
            {
                XmlAttributeCollection symb = symbols[0].Attributes;
                printAttributes(symb);
            }
            
            

            XmlNodeList precipitation = xmlDoc.GetElementsByTagName("precipitation");
            if (precipitation != null)
                Console.WriteLine("\n-------------Today's Precipitation Status-------------\n");
            if (precipitation[0] != null)
            {
                XmlAttributeCollection prec = precipitation[0].Attributes;
                printAttributes(prec);
            }
            

            XmlNodeList windDirection = xmlDoc.GetElementsByTagName("windDirection");
            if (windDirection != null)
                Console.WriteLine("\n-------------Wind Direction-------------\n");
            if (windDirection[0] != null)
            {
                XmlAttributeCollection direc = windDirection[0].Attributes;
                printAttributes(direc);
            }

            XmlNodeList windSpeed = xmlDoc.GetElementsByTagName("windSpeed");
            if (windSpeed != null)
                Console.WriteLine("\n-------------Wind Speed-------------\n");
            if (windSpeed[0] != null)
            {
                XmlAttributeCollection speed = windSpeed[0].Attributes;
                printAttributes(speed);
            }

            XmlNodeList temperature = xmlDoc.GetElementsByTagName("temperature");
            if (temperature != null)
                Console.WriteLine("\n-------------Today's Temperature-------------\n");
            if (temperature[0] != null)
            {
                XmlAttributeCollection temp = temperature[0].Attributes;
                printTempAttributes(temp);
            }

            XmlNodeList pressure = xmlDoc.GetElementsByTagName("pressure");
            if (pressure != null)
                Console.WriteLine("\n-------------Pressure Status-------------\n");
            if (pressure[0] != null)
            {
                XmlAttributeCollection press = pressure[0].Attributes;
                printAttributes(press);
            }
            XmlNodeList humidity = xmlDoc.GetElementsByTagName("humidity");
            if (humidity != null)
                Console.WriteLine("\n-------------Percent Humidity-------------\n");
            if (humidity[0] != null)
            {
                XmlAttributeCollection humid = humidity[0].Attributes;
                printAttributes(humid);
            }

            XmlNodeList clouds = xmlDoc.GetElementsByTagName("clouds");
            if (clouds != null)
                Console.WriteLine("\n-------------Cloud Status-------------\n");
            if (clouds[0] != null)
            {
                XmlAttributeCollection cloud = clouds[0].Attributes;
                printAttributes(cloud);
            }
        }
               
        public static string retrieveXML(string location)
        {
            string apiKey = "6927d88cf63a83785732f1bc32728ef0";
            string url = String.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&type=accurate&mode=xml&units=metric&cnt=3&appid={1}", location, apiKey);
            return url;

        }
        public static void printAttributes(XmlAttributeCollection coll)
        {
            foreach(XmlAttribute x in coll)
            {
                Console.WriteLine("{0}: {1}", x.Name, x.Value);
            }
        }

        public static void printTempAttributes(XmlAttributeCollection coll)
        {
            foreach (XmlAttribute x in coll)
            {
                double num;
                num = Convert.ToDouble(x.Value);
                int newVal = celciusToFareignheit(num);
                Console.WriteLine("{0}: {1}", x.Name, newVal);
            }
        }
        public static int celciusToFareignheit(double x)
        {
            return (int)(x * (9.0 / 5) + 32);
        }


    }
}
