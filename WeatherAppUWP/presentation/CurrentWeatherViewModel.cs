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

namespace WeatherAppUWP
{

    public class CurrentWeatherViewModel : BindableBase
    {
        public interface EventsListener
        {
            void ShowDialogWindow(string message);
        }

        private const int limit = 1;
        private Coordinates cityCoord = CoordCity.Cities["Москва"];

        private GetCurrentWeatherUseCase getCurrentWeatherUseCase;

        private IAsyncCommand fetchCurrentWeather;
        public IAsyncCommand FetchCurrentWeather 
        {
            get
            {
                return fetchCurrentWeather ??
                    (fetchCurrentWeather = new WaetherCommandAsync(async () =>
                    {
                        FetchDataWeatherAsync(cityCoord);
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

        private bool isLoading = true;
        public bool IsLoading
        {
            get => isLoading;
            set => Set(ref isLoading, value);
        }

        private string city;
        public string City
        {
            get => city;
            set => Set(ref city, value, "City");
        }

        public CurrentWeatherViewModel(GetCurrentWeatherUseCase getCurrentWeatherUseCase)
        {
            this.getCurrentWeatherUseCase = getCurrentWeatherUseCase;
            FetchDataWeatherAsync(cityCoord);
        }

        private async void FetchDataWeatherAsync(Coordinates cityCoord)
        {
            IsLoading = true;
            try
            {
                var data = await getCurrentWeatherUseCase.Get(cityCoord, limit);
                IsLoading = false;
                CurrentWeather = data;
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine(ex.Message);

            }
        }
    }
}
