using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WeatherAppUWP.command;
using WeatherAppUWP.domain;
using WeatherAppUWP.domain.entity;
using WeatherAppUWP.utill;

namespace WeatherAppUWP.presentation
{
    public class ForecastViewModel : BindableBase
    {
        private readonly GetCurrentWeatherUseCase getCurrentWeatherUseCase;
        private readonly GetForecastUseCase getForecastUseCase;

        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken token;

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
            get => currentWeather;
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
            get => forecasts;
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
        }
    }
}