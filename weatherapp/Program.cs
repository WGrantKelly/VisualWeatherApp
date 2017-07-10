using System;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using System.IO;
using System.Text;

namespace WeatherApp.Models
{
    class Program
    {
       
        public ForecastModel findAllAttributes(XmlDocument xmlDoc, string location)
        {
            ForecastModel fCast = new ForecastModel();
            BackgroundImageGenerator bckrnd = new BackgroundImageGenerator();
            fCast.Location = location;
            fCast.LocationDetails = getDayIndexWeather(xmlDoc, fCast, "location", 1);




            String[] riseAndSet = getDayIndexWeather(xmlDoc, fCast, "sun", 0).Split(' ');
            String rise = riseAndSet[2];
            String[] riseTime = rise.Split('T');
            rise = riseTime[1];
            String set = riseAndSet[5];
            String[] setTime = set.Split('T');
            set = setTime[1];


            fCast.SunRise = rise;
            fCast.SunSet = set;




                fCast.Time1 = getDayIndexWeather(xmlDoc, fCast, "time", 0);
                fCast.Symbol1 = getDayIndexWeather(xmlDoc, fCast, "symbol", 0);
                fCast.Precipitation1 = getDayIndexWeather(xmlDoc, fCast, "precipitation", 0);
                fCast.WindDirection1 = getDayIndexWeather(xmlDoc, fCast, "windDirection", 0);
                fCast.WindSpeed1 = getDayIndexWeather(xmlDoc, fCast, "windSpeed", 0);
                fCast.Temperature1 = getDayIndexWeather(xmlDoc, fCast, "temperature", 0);
                fCast.Pressure1 = getDayIndexWeather(xmlDoc, fCast, "pressure", 0);
                fCast.Humidity1 = getDayIndexWeather(xmlDoc, fCast, "humidity", 0);
                fCast.Cloud1 = getDayIndexWeather(xmlDoc, fCast, "clouds", 0);

                fCast.Time2 = getDayIndexWeather(xmlDoc, fCast, "time", 1);
                fCast.Symbol2 = getDayIndexWeather(xmlDoc, fCast, "symbol", 1);
                fCast.Precipitation2 = getDayIndexWeather(xmlDoc, fCast, "precipitation", 1);
                fCast.WindDirection2 = getDayIndexWeather(xmlDoc, fCast, "windDirection", 1);
                fCast.WindSpeed2 = getDayIndexWeather(xmlDoc, fCast, "windSpeed", 1);
                fCast.Temperature2 = getDayIndexWeather(xmlDoc, fCast, "temperature", 1);
                fCast.Pressure2 = getDayIndexWeather(xmlDoc, fCast, "pressure", 1);
                fCast.Humidity2 = getDayIndexWeather(xmlDoc, fCast, "humidity", 1);
                fCast.Cloud2 = getDayIndexWeather(xmlDoc, fCast, "clouds", 1);

                fCast.Time3 = getDayIndexWeather(xmlDoc, fCast, "time", 2);
                fCast.Symbol3 = getDayIndexWeather(xmlDoc, fCast, "symbol", 2);
                fCast.Precipitation3 = getDayIndexWeather(xmlDoc, fCast, "precipitation", 2);
                fCast.WindDirection3 = getDayIndexWeather(xmlDoc, fCast, "windDirection", 2);
                fCast.WindSpeed3 = getDayIndexWeather(xmlDoc, fCast, "windSpeed", 2);
                fCast.Temperature3 = getDayIndexWeather(xmlDoc, fCast, "temperature", 2);
                fCast.Pressure3 = getDayIndexWeather(xmlDoc, fCast, "pressure", 2);
                fCast.Humidity3 = getDayIndexWeather(xmlDoc, fCast, "humidity", 2);
                fCast.Cloud3 = getDayIndexWeather(xmlDoc, fCast, "clouds", 2);

                bckrnd.set(fCast, 1);
                bckrnd.set(fCast, 2);
                bckrnd.set(fCast, 3);
            return fCast;
        }
        public string getDayIndexWeather(XmlDocument xmlDoc, ForecastModel model, String attribute, int dayIndex)
        {
            StringBuilder attributeMerger = new StringBuilder();
            XmlNodeList list = xmlDoc.GetElementsByTagName(attribute);
            if(attribute.Equals("temperature"))
            {
                XmlAttributeCollection listCollection = list[dayIndex].Attributes;
                foreach (XmlAttribute x in listCollection)
                {
                    if(x.Name.Equals("min")||x.Name.Equals("max"))
                    attributeMerger.Append(" " + x.Name + ": " + celciusToFareignheit(x.Value) + " ");
                }
            }
            else if (attribute.Equals("precipitation"))
            {
                XmlAttributeCollection listCollection = list[dayIndex].Attributes;
                if(listCollection.Count.Equals(0))
                {
                    attributeMerger.Append("None");
                }
                else
                {
                    foreach (XmlAttribute x in listCollection)
                    {
                        if(x.Name.Equals("type"))
                        {
                            attributeMerger.Append(x.Value + " ");
                        }
                    }
                }
            
            }
            else if (attribute.Equals("pressure"))
            {
                XmlAttributeCollection listCollection = list[dayIndex].Attributes;
                foreach (XmlAttribute x in listCollection)
                {
                    attributeMerger.Append(x.Value + " ");
                }
            }
            else if (attribute.Equals("humidity"))
            {
                XmlAttributeCollection listCollection = list[dayIndex].Attributes;
                foreach (XmlAttribute x in listCollection)
                {
                    attributeMerger.Append(x.Value + " ");
                }
            }
            else if (attribute.Equals("clouds"))
            {
                XmlAttributeCollection listCollection = list[dayIndex].Attributes;
                foreach (XmlAttribute x in listCollection)
                {
                        attributeMerger.Append(x.Value + " ");                 
                }
            }
            else if (list[0] != null)
            {
                XmlAttributeCollection listCollection = list[dayIndex].Attributes;
                foreach (XmlAttribute x in listCollection)
                {
                    if (x.Name.Equals("number")|| x.Name.Equals("var"))
                    {
                        
                    }
                    else if (x.Name.Equals("name"))
                    {
                        attributeMerger.Append(" " + x.Value);
                    }
                    else if (x.Name.Equals("day"))
                    {
                        attributeMerger.Append(" " + x.Value);
                    }
                    else
                    {
                        attributeMerger.Append(" "+ x.Name + ": " + x.Value + " ");
                    }
                }
            }
            return (attributeMerger.ToString());
        }
        public string retrieveXML(string location)
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
        public static int celciusToFareignheit(String x)
        {
            double value = Convert.ToDouble(x);
            return (int)(value * (9.0 / 5) + 32);
        }


    }
}
