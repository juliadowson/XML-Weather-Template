using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {
        
        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            #region colour change for weather
            double backWeather;
            backWeather = Convert.ToDouble(Form1.days[0].currentColour);
            if (backWeather >= 200 && backWeather < 300)  //grey when there's thunderstorms
            {
                BackColor = Color.Gray;
            }
            else if (backWeather >= 300 && backWeather < 550)  //slate grey when raining 
            {
                this.BackColor = Color.SlateGray;
            }
            else if (backWeather >= 600 && backWeather < 650)   //gainsboro when snowing 
            {
                this.BackColor = Color.Gainsboro;
            }
            else
            {
                this.BackColor = Color.BurlyWood;
            }
            #endregion

            //outputing values into textboxes 
            cityOutput.Text = $"{Form1.days[0].location}, {Form1.days[0].country}";
            tempLabel.Text = $"{Form1.days[0].currentTemp}°C";
            feelsLikeLabel.Text = $"{Form1.days[0].feelsLike}°C";
            minOutput.Text = Form1.days[0].tempLow;
            maxOutput.Text = Form1.days[0].tempHigh;
            weatherIcon.Load("http://openweathermap.org/img/wn/" + Form1.days[0].icon + "@2x.png");
            outdoorLabel.Text = Form1.days[0].condition;
            windSpeedlabel.Text += $"\n\n{Form1.days[0].windSpeed} {Form1.days[0].windUnit}   -   {Form1.days[0].windDirection}";

            timeLabel.Text += DateTime.Now.ToString("hh:mm");
                     
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            //opening other screen 
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string lastInput = Form1.search;
            Form1.search = searchInput.Text;
            //clears list for new search 
            Form1.days.Clear();

            //give error message if the city isn't found
            while (!Form1.ExtractForecast())
            {
                Form1.search = lastInput;
                errorInput.Text = "City not found.";         
            }
            errorInput.Text = "";
            timeLabel.Text = "";
            timeLabel.Text = "Last update at ";

            Form1.ExtractCurrent();
            DisplayCurrent();
        }

    }
}
