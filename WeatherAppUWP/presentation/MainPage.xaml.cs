﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using System.Diagnostics;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace WeatherAppUWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public CurrentWeatherViewModel ViewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();
            ViewModel = new CurrentWeatherViewModel(new domain.GetCurrentWeatherUseCase());
        }

        //public void ShowDialogWindow(string message)
        //{
        //    var showErrorDialog = new ContentDialog()
        //    {
        //        Title = "Ошибка",
        //        Content = $"{message}",
        //        PrimaryButtonCommand = ViewModel.FetchCurrentWeather,
        //        SecondaryButtonText = "Отмена"
        //    };
        //}
    }
}
