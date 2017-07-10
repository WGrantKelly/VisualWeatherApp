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
                model.forecastBackgroundVideo = "/videos/Rain.mp4";
            }
            else if (model.Precipitation1.Contains("None"))
            {
                model.forecastBackgroundVideo = "/videos/Clouds.mp4";
            }
            else if (model.Precipitation1.Contains("snow"))
            {
                model.forecastBackgroundVideo = "/videos/Snow.mp4";
            }
        }
    }
       
}