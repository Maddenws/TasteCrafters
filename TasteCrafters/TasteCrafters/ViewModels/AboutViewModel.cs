using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TasteCrafters.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Repository";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://github.com/Maddenws"));
        }

        public ICommand OpenWebCommand { get; }
    }
}