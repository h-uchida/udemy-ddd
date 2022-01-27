using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using System.ComponentModel;

namespace DDD.WinForm.ViewModels
{
    public class WeatherLatestViewModel : ViewModelBase
    {
        private IWeatherRepository _weather;
        private IAreasRepository _areas;

        public WeatherLatestViewModel() : this(new WeatherSQLite(), null)
        {
        }

        public WeatherLatestViewModel(IWeatherRepository weather, IAreasRepository areas)
        {
            _weather = weather;
            _areas = areas;

            foreach (var area in _areas.GetData())
            {
                Areas.Add(area);
            }
        }
        private string _areaIdText = string.Empty;
        public string AreaIdText
        {
            get { return _areaIdText; }
            set { SetProperty(ref _areaIdText, value); }
        }
        private string _dataDateText = string.Empty;
        public string DataDateText
        {
            get { return _dataDateText; }
            set { SetProperty(ref _dataDateText, value); }
        }
        private string _conditionText = string.Empty;
        public string ConditionText
        {
            get { return _conditionText; }
            set { SetProperty(ref _conditionText, value); }
        }
        private string _temperatureText = string.Empty;
        public string TemperatureText
        {
            get { return _temperatureText; }
            set { SetProperty(ref _temperatureText, value); }
        }

        public BindingList<AreaEntity> Areas { get; set; } = new BindingList<AreaEntity>();

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
