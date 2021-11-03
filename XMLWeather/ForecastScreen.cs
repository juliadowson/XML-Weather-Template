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
    public partial class ForecastScreen : UserControl
    {
        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
            //outputs info for the next 5 days, reading from XML file 
            date1.Text = Convert.ToDateTime(Form1.days[1].date).ToString("dddd \nMMMM dd, yyyy");
            min1.Text = Form1.days[1].tempLow;
            max1.Text = Form1.days[1].tempHigh;
            outdoor1.Load("http://openweathermap.org/img/wn/" + Form1.days[1].condition + "@2x.png");

            date2.Text = Convert.ToDateTime(Form1.days[2].date).ToString("dddd \nMMMM dd, yyyy");
            min2.Text = Form1.days[2].tempLow;
            max2.Text = Form1.days[2].tempHigh;
            outdoor2.Load("http://openweathermap.org/img/wn/" + Form1.days[2].condition + "@2x.png");

            date3.Text = Convert.ToDateTime(Form1.days[3].date).ToString("dddd \nMMMM dd, yyyy");
            min3.Text = Form1.days[3].tempLow;
            max3.Text = Form1.days[3].tempHigh;
            outdoor3.Load("http://openweathermap.org/img/wn/" + Form1.days[3].condition + "@2x.png");

            date4.Text = Convert.ToDateTime(Form1.days[4].date).ToString("dddd \nMMMM dd, yyyy");
            min4.Text = Form1.days[4].tempLow;
            max4.Text = Form1.days[4].tempHigh;
            outdoor4.Load("http://openweathermap.org/img/wn/" + Form1.days[4].condition + "@2x.png");

            date5.Text = Convert.ToDateTime(Form1.days[5].date).ToString("dddd \nMMMM dd, yyyy");
            min5.Text = Form1.days[5].tempLow;
            max5.Text = Form1.days[5].tempHigh;
            outdoor5.Load("http://openweathermap.org/img/wn/" + Form1.days[5].condition + "@2x.png");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //opens other screen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }
    }
}
