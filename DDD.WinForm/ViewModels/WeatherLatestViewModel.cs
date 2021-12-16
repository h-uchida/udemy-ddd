﻿using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
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
            var entity = _weather.GetLatest(int.Parse(AreaIdText));

            if (entity != null)
            {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.ToString();
                TemperatureText = CommonFunc.RoundString(
                    entity.Temperature,
                    Temperature.DecimalPoint) + " " + Temperature.UnitName;
            }
        }
    }
}
