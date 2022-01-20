using DDD.Domain;
using DDD.Domain.Helpers;
using DDD.Domain.ValueObjects;
using DDD.Infrastructure.SQLite;
using DDD.WinForm.ViewModels;
using System;
using System.Windows.Forms;

namespace DDD.WinForm
{
    public partial class WeatherLatestView : Form
    {
        private WeatherLatestViewModel _viewModel = new WeatherLatestViewModel();

        public WeatherLatestView()
        {
            InitializeComponent();
        }

        private void LatestButton_Click(object sender, EventArgs e)
        {
            //var dt = WeatherSQLite.GetLatest(int.Parse(AreaIdTextBox.Text));

            //if (dt.Rows.Count > 0)
            //{
            //    DataDateLabel.Text = dt.Rows[0]["DataDate"].ToString();
            //    ConditionLabel.Text = dt.Rows[0]["Condition"].ToString();
            //    TemperatureLabel.Text = Convert.ToSingle(dt.Rows[0]["Temperature"]).RoundString(Temperature.DecimalPoint) + Temperature.UnitName;
            //}

        }



    }
}
