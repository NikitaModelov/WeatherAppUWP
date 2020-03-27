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

namespace WeatherAppUWP
{
    public class WeatherViewModel : BindableBase
    {

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

        public string City { get; set; }

        public WeatherViewModel(GetCurrentWeatherUseCase getCurrentWeatherUseCase)
        {
            this.getCurrentWeatherUseCase = getCurrentWeatherUseCase;
            Task.Run(() => FetchDataWeatherAsync(defaultCity));
        }

        async Task FetchDataWeatherAsync(string city)
        {
            data = await getCurrentWeatherUseCase.Get(city);
            if (data.Count == 1)
            {
                CurrentTemperature = data[0];
            }
            else
            {
                // TODO
            }
        }
    }
}
