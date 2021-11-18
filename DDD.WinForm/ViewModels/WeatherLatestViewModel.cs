using DDD.Domain.Repositories;
using DDD.WinForm.Common;
using System;

namespace DDD.WinForm.ViewModels
{
    public class WeatherLatestViewModel
    {
        private IWeatherRepository _weather;

        public WeatherLatestViewModel(IWeatherRepository weather)
        {
            _weather = weather;
        }

        public string AreaIdText { get; set; } = "";
        public string DataDateText { get; set; } = "";
        public string ConditionText { get; set; } = "";
        public string TemperatureText { get; set; } = "";

        public void Search()
        {
            var dt = _weather.GetLatest(int.Parse(AreaIdText));

            if (dt.Rows.Count > 0)
            {
                DataDateText = dt.Rows[0]["DataDate"].ToString();
                ConditionText = dt.Rows[0]["Condition"].ToString();
                TemperatureText = CommonFunc.RoundString(
                    Convert.ToSingle(dt.Rows[0]["Temperature"]),
                    CommonConst.TemperatureDecimalPoint) + " " + CommonConst.TemperatureUnitName;
            }
        }
    }
}
