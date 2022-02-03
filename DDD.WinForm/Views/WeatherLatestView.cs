using DDD.Domain;
using DDD.Domain.Entities;
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

            AreasComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AreasComboBox.DataBindings.Add(nameof(AreasComboBox.SelectedValue), _viewModel, nameof(_viewModel.SelectedAreaId));
            AreasComboBox.DataBindings.Add(nameof(AreasComboBox.DataSource), _viewModel, nameof(_viewModel.Areas));
            AreasComboBox.ValueMember = nameof(AreaEntity.AreaId);
            AreasComboBox.DisplayMember = nameof(AreaEntity.AreaName);
            DataDateLabel.DataBindings.Add(nameof(DataDateLabel.Text), _viewModel, nameof(_viewModel.DataDateText));
            ConditionLabel.DataBindings.Add(nameof(ConditionLabel.Text), _viewModel, nameof(_viewModel.ConditionText));
            TemperatureLabel.DataBindings.Add(nameof(TemperatureLabel.Text), _viewModel, nameof(_viewModel.TemperatureText));
        }

        private void LatestButton_Click(object sender, EventArgs e)
        {
            _viewModel.Search();
        }



    }
}
