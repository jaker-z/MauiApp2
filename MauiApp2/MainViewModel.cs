using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp2
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = "Zippy Games";

        [ObservableProperty]
        private string greetingText = "Welcome to Zippy Games!";

        private string greeting1 = "Welcome to Zippy Games!"; 
        private string greeting2 = "You changed the text.";

        [RelayCommand]
        async Task ChangeGreetingAsync()
        {
            if (GreetingText == greeting2)
                GreetingText = greeting1;
            else
                GreetingText = greeting2;
        }

        [RelayCommand]
        async Task GoToDetailsAsync()
        {
            await Shell.Current.GoToAsync(nameof(DetailPage));
        }


    }
}
