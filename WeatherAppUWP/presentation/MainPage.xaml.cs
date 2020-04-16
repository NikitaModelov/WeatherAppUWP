using Windows.UI.Xaml.Controls;
using WeatherAppUWP.presentation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace WeatherAppUWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ForecastViewModel ViewModel { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            ViewModel = new ForecastViewModel(new domain.GetCurrentWeatherUseCase(),
                                              new domain.GetForecastUseCase());
        }
    }
}
