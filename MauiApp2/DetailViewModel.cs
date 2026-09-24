using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp2
{
    public partial class DetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private string detailTitle = "Welcome to Cool Pizza.";


        [RelayCommand]
        async Task ChangeMainLabelAsync()
        {
            return;
        }

        [RelayCommand]
        async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

        
    }
}
