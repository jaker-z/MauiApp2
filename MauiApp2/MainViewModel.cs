using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MauiApp2
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<String> AvailableOptions { get; set; }

        [ObservableProperty]
        ObservableCollection<EntryItem> entryItems;

        public MainViewModel()
        {
            AvailableOptions = new ObservableCollection<string>
            {
                "Pizza",
                "Pastel Controller",
                "Captain Falcon"
            };

            EntryItems = new ObservableCollection<EntryItem>()
            {
                new EntryItem {Name = "Frick", IsCompleted = false},
                new EntryItem {Name = "Stick", IsCompleted = true},
                new EntryItem {Name = "Pick", IsCompleted = false}
            };
        }

        [ObservableProperty]
        private string title = "Zippy Games";

        [ObservableProperty]
        private string greetingText = "Welcome to Zippy Games!";
        
        [ObservableProperty]
        private string greetingSubText = "This is where the fun begins.";

        private string greeting1 = "Welcome to Zippy Games!"; 
        private string greeting2 = "You changed the text.";

        private string subText1 = "This is where the fun begins.";
        private string subText2 = "Good job, friend!";

        [ObservableProperty]
        private string userInput = string.Empty;
        


        [RelayCommand]
        async Task ChangeGreetingAsync()
        {
            if (GreetingText == greeting2)
            {
                GreetingText = greeting1;
                GreetingSubText = subText1;
            }
            else
            {
                GreetingText = greeting2;
                GreetingSubText = subText2;
            }     
        }

        [RelayCommand]
        async Task AddEntryItemAsync()
        {
            if (string.IsNullOrWhiteSpace(UserInput))
                return;

            EntryItem newEntryItem = new EntryItem()
            {
                Name = UserInput,
                IsCompleted = false
            };
            
            EntryItems.Add(newEntryItem);

            UserInput = string.Empty;
        }

        [RelayCommand]
        async Task ChangeTitleAsync()
        {
            Title = UserInput;
            await AddEntryItemAsync();
        }


        [RelayCommand]
        async Task GoToDetailsAsync()
        {
            await Shell.Current.GoToAsync(nameof(DetailPage));
        }


    }
}
