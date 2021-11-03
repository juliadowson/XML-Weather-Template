using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLWeather
{
    public class Day
    {
        public string date, currentTemp, currentColour, currentTime, condition, location, country, tempHigh, tempLow,
            windSpeed, windDirection, windUnit, precipitation, visibility, icon, feelsLike;

        public Day()
        {
            date = currentTemp = currentTime = currentColour = condition = location = country = tempHigh = tempLow = windSpeed = windDirection = windUnit = precipitation = visibility = icon = feelsLike;
        }
    }
}
