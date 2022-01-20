using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;

namespace DDD.WinForm.ViewModels
{
    public class WeatherLatestViewModel
    {
        private IWeatherRepository _weather;

        public WeatherLatestViewModel() : this(new WeatherSQLite())
        {
        }

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
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }
        }
    }
}
