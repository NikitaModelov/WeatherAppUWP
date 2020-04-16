using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using WeatherAppUWP.presentation;
using System.Diagnostics;
using WeatherAppUWP.domain;
using Newtonsoft.Json;
using Windows.UI.Core;
using WeatherAppUWP.command;
using WeatherAppUWP.domain.entity;
using WeatherAppUWP.utill;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Threading;

namespace WeatherAppUWP
{

    public class ForecastViewModel : BindableBase
    {
        private GetCurrentWeatherUseCase getCurrentWeatherUseCase;
        private GetForecastUseCase getForecastUseCase;

        CancellationTokenSource cancellationTokenSource;
        CancellationToken token;

        private IAsyncCommand fetchCurrentWeather;
        public IAsyncCommand FetchCurrentWeather
        {
            get
            {
                return fetchCurrentWeather ??
                    (fetchCurrentWeather = new WaetherCommandAsync(async () =>
                    {
                        FetchDataWeatherAsync(CoordCity.Cities[City]);
                    }));
            }
        }

        private CurrentWeather currentWeather;
        public CurrentWeather CurrentWeather
        {
            get { return currentWeather; }
            set
            {
                if (value != null)
                {
                    Set(ref currentWeather, value);
                }
            }
        }

        private ObservableCollection<Forecast> forecasts;
        public ObservableCollection<Forecast> Forecasts
        {
            get { return forecasts; }
            set
            {
                if (value != null)
                {
                    Set(ref forecasts, value);
                }
            }
        }

        private bool showWeatherLayout = false;
        public bool ShowWeatherLayout
        {
            get => showWeatherLayout;
            set => Set(ref showWeatherLayout, value);
        }
        private bool showErrorLayout = false;
        public bool ShowErrorLayout
        {
            get => showErrorLayout;
            set => Set(ref showErrorLayout, value);
        }

        private bool toggleValue = false;
        public bool ToggleValue
        {
            get => toggleValue;
            set
            {
                Set(ref toggleValue, value);
                if (value)
                {
                    RunRefreshData();
                } 
                else
                {
                    cancellationTokenSource.Cancel();
                }
                
            }
            
        }

        private bool isLoading = true;
        public bool IsLoading
        {
            get => isLoading;
            set => Set(ref isLoading, value);
        }

        private string city = "Новосибирск";
        public string City
        {
            get => city;
            set => Set(ref city, value);
        }

        private int countDay = 2;
        public int CountDay
        {
            get => countDay;
            set => Set(ref countDay, value);
        }

        public ForecastViewModel(GetCurrentWeatherUseCase getCurrentWeatherUseCase,
                                 GetForecastUseCase getForecastUseCase)
        {
            this.getCurrentWeatherUseCase = getCurrentWeatherUseCase;
            this.getForecastUseCase = getForecastUseCase;

            FetchDataWeatherAsync(CoordCity.Cities[City]);
        }

        private async void FetchDataWeatherAsync(Coordinates cityCoord)
        {
            IsLoading = true;
            ShowWeatherLayout = false;
            ShowErrorLayout = false;
            try
            {
                var currentWeather = await getCurrentWeatherUseCase.Get(cityCoord);
                var forecast = await getForecastUseCase.Get(cityCoord, CountDay);

                IsLoading = false;

                CurrentWeather = currentWeather;
                Forecasts = new ObservableCollection<Forecast>(forecast);

                ShowWeatherLayout = true;
            }
            catch (HttpRequestException ex)
            {
                ShowErrorLayout = true;
            }
        }

        private void RunRefreshData()
        {
            cancellationTokenSource = new CancellationTokenSource();
            token = cancellationTokenSource.Token;
            RefreshData(token);
        }

        private async void RefreshData(CancellationToken token, int time = 10000)
        {
            while (!token.IsCancellationRequested)
            {
                FetchDataWeatherAsync(CoordCity.Cities[City]);
                await Task.Delay(time);
            }
            return;
        }
    }
}