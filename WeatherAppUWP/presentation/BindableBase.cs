using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace WeatherAppUWP.presentation
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private CoreDispatcher dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;

        protected bool Set<T>(ref T storage, T value,
            [CallerMemberName] String propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            PropertyChangedAsync(propertyName);
            return true;
        }

        private async Task UiThreadAction(Action act)
        {
            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, act.Invoke);
        }

        private async void PropertyChangedAsync([CallerMemberName] String propertyName = null)
        {
            if (PropertyChanged != null)
            {
                Debug.WriteLine("Ссылка -> " + propertyName);
                await UiThreadAction(() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)));
            }
        }
    }
}
