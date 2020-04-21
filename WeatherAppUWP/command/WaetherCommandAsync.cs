using System;
using System.Threading.Tasks;

namespace WeatherAppUWP.Command
{
    class WaetherCommandAsync : AsyncCommandBase
    {
        private readonly Func<Task> command;
        public WaetherCommandAsync(Func<Task> command)
        {
            this.command = command;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override Task ExecuteAsync(object parameter)
        {
            return command();
        }
    }
}