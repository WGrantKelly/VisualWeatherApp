using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using WeatherApp.Models;

namespace WeatherApp
{
    public class BackgroundImageGenerator
    {
        public void set(ForecastModel x, int y)
        {
            switch (y)
            {
                case 1:
                    if (x.Precipitation1.Contains("rain"))
                    {
                        x.BackImg1 = "/Images/storm.png";
                    }
                    else if (x.Precipitation1.Contains("snow"))
                    {
                        x.BackImg1 = "/Images/Snow.png";
                    }
                    else if (x.Precipitation1.Contains("storm"))
                    {
                        x.BackImg1 = "/Images/storm.png";
                    }
                    else
                    {
                        x.BackImg1 = "/Images/Sun.png";
                    }
                    break;
                case 2:
                    if (x.Precipitation2.Contains("rain"))
                    {
                        x.BackImg2 = "/Images/storm.png";
                    }
                    else if (x.Precipitation2.Contains("snow"))
                    {
                        x.BackImg2 = "/Images/Snow.png";
                    }
                    else if (x.Precipitation2.Contains("storm"))
                    {
                        x.BackImg2 = "/Images/storm.png";
                    }
                    else
                    {
                        x.BackImg2 = "/Images/Sun.png";
                    }
                    break;
                case 3:
                    if (x.Precipitation3.Contains("rain"))
                    {
                        x.BackImg3 = "/Images/storm.png";
                    }
                    else if (x.Precipitation3.Contains("snow"))
                    {
                        x.BackImg3 = "/Images/Snow.png";
                    }
                    else if (x.Precipitation3.Contains("storm"))
                    {
                        x.BackImg3 = "/Images/storm.png";
                    }
                    else
                    {
                        x.BackImg3 = "/Images/Sun.png";
                    }
                    break;
            }
            
            
    
        }
    }   
}