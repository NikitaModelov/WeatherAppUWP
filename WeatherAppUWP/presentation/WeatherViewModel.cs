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

namespace WeatherAppUWP
{
    public class WeatherViewModel : BindableBase
    {
        private CoreDispatcher dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;

        private Data currentTemperature;
        public Data CurrentTemperature
        {
            get { return currentTemperature; }
            set
            {
                if (value != null)
                {
                    Set(ref currentTemperature, value, "CurrentTemperature");
                }
            }
        }

        private List<Data> data;

        private string defaultCity = "Novosibirsk";

        private GetCurrentWeatherUseCase getCurrentWeatherUseCase;

        private bool isLoading = true;
        public bool IsLoading
        {
            get =>  isLoading; 
            set =>  Set(ref isLoading, value, "IsLoading");
        }

        public string City { get; set; }

        public WeatherViewModel(GetCurrentWeatherUseCase getCurrentWeatherUseCase)
        {
            this.getCurrentWeatherUseCase = getCurrentWeatherUseCase;
            Task.Run(() => FetchDataWeatherAsync(defaultCity));
        }

        async Task FetchDataWeatherAsync(string city)
        {
                try
                {
                    data = await getCurrentWeatherUseCase.Get(city);
                    if (data.Count == 1)
                    {
                        await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        {
                            CurrentTemperature = data[0];
                            IsLoading = false;
                        });
                    }
                    else
                    {
                        // TODO
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }         
        }
    }
}
