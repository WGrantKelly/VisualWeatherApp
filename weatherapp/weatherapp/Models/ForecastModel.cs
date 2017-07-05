using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class ForecastModel
    {
        [Required]
        public string Location { get; set; }
        [Required]
        public string LocationDetails { get; set; }
        [Required]
        public string Sun { get; set; }
        [Required]
        public string Symbol1 { get; set; }
        [Required]
        public string Cloud1 { get; set; }
        [Required]
        public string Humidity1 { get; set; }
        [Required]
        public string Precipitation1 { get; set; }
        [Required]
        public string Pressure1 { get; set; }
        [Required]
        public string Temperature1 { get; set; }
        [Required]
        public string WindDirection1 { get; set; }
        [Required]
        public string WindSpeed1 { get; set; }
        [Required]
        public string Time1 { get; set; }
        public string Symbol2 { get; set; }
        [Required]
        public string Cloud2 { get; set; }
        [Required]
        public string Humidity2 { get; set; }
        [Required]
        public string Precipitation2 { get; set; }
        [Required]
        public string Pressure2 { get; set; }
        [Required]
        public string Temperature2 { get; set; }
        [Required]
        public string WindDirection2 { get; set; }
        [Required]
        public string WindSpeed2 { get; set; }
        [Required]
        public string Time2 { get; set; }
        [Required]
        public string Symbol3 { get; set; }
        [Required]
        public string Cloud3 { get; set; }
        [Required]
        public string Humidity3 { get; set; }
        [Required]
        public string Precipitation3 { get; set; }
        [Required]
        public string Pressure3 { get; set; }
        [Required]
        public string Temperature3 { get; set; }
        [Required]
        public string WindDirection3 { get; set; }
        [Required]
        public string WindSpeed3 { get; set; }
        [Required]
        public string Time3 { get; set; }
    }
}