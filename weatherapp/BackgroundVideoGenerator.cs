using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherApp.Models;

namespace WeatherApp
{
    public class BackgroundVideoGenerator
    {
        ForecastModel model;
        public BackgroundVideoGenerator(ForecastModel model)
        {
            this.model = model;
        }
        public void update()
        {
            if(model.Precipitation1.Contains("rain")|| model.Precipitation1.Contains("storms"))
            {
                model.forecastBackgroundVideoMP4 = "/videos/Rain.mp4";
                model.forecastBackgroundVideoWEBM = "/videos/Rainwebm.webm";
            }
            else if (model.Precipitation1.Contains("None"))
            {
                model.forecastBackgroundVideoMP4 = "/videos/Clouds.mp4";
                model.forecastBackgroundVideoWEBM = "/videos/Clouds.webm";
            }
            else if (model.Precipitation1.Contains("snow"))
            {
                model.forecastBackgroundVideoMP4 = "/videos/Snow.mp4";
                model.forecastBackgroundVideoWEBM = "/videos/Snow.webm";
            }
        }
    }
       
}