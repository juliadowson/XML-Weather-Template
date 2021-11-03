/*Julia Dowson
 * Mr. T
 * Nov. 2, 2021
 * This is a basic weather app, reading for 6 days total. It also includes a search option.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace XMLWeather
{
    public partial class Form1 : Form
    {
        // TODO: create list to hold day objects
        public static List<Day> days = new List<Day>();

        public static string search = "Stratford, CA";

        public Form1()
        {
            InitializeComponent();

            ExtractForecast();
            ExtractCurrent();

            // open weather screen for todays weather
            CurrentScreen cs = new CurrentScreen();
            this.Controls.Add(cs);
        }

        public static bool ExtractForecast()
        {
            try
            {
                XmlReader reader = XmlReader.Create($"http://api.openweathermap.org/data/2.5/forecast/daily?q=" + search + "&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0");

                while (reader.Read())
                {
                    //creates a day object
                    Day day = new Day();

                    //fills day object with XML info
                    reader.ReadToFollowing("time");
                    day.date = reader.GetAttribute("day");
                    reader.ReadToFollowing("symbol");
                    day.condition = reader.GetAttribute("var");
                    reader.ReadToFollowing("temperature");
                    day.tempLow = Convert.ToDouble(reader.GetAttribute("min")).ToString("0");
                    day.tempHigh = Convert.ToDouble(reader.GetAttribute("max")).ToString("0");

                    //if day object not null add to the days list
                    if (day.date != null)
                    {
                        days.Add(day);
                    }
                }
                return true;
            }
            catch { }
            return false;
        }

        public static void ExtractCurrent()
        {
            // current info is not included in forecast file so we need to use this file to get it
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/weather?q=" + search + "&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0");

            //fills day object with XML info
            reader.ReadToFollowing("city");
            days[0].location = reader.GetAttribute("name");
            reader.ReadToFollowing("country");
            days[0].country = reader.ReadString();
            reader.ReadToFollowing("temperature");
            days[0].currentTemp = Convert.ToDouble(reader.GetAttribute("value")).ToString("0");
            reader.ReadToFollowing("feels_like");
            days[0].feelsLike = Convert.ToDouble(reader.GetAttribute("value")).ToString("0");
            reader.ReadToFollowing("speed");
            days[0].windSpeed = reader.GetAttribute("value");
            days[0].windUnit = reader.GetAttribute("unit");
            reader.ReadToFollowing("direction");
            days[0].windDirection = reader.GetAttribute("code");
            reader.ReadToFollowing("weather");
            days[0].currentColour = reader.GetAttribute("number");
            days[0].condition = reader.GetAttribute("value").ToUpper();
            days[0].icon = reader.GetAttribute("icon");
        }
    }
}
