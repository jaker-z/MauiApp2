namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        private int _editCharacterId;

        public MainPage(MainViewModel vm, DatabaseService databaseService)
        {
            InitializeComponent();
            BindingContext = vm;
            _databaseService = databaseService;
            Task.Run(async () => listView.ItemsSource = await _databaseService.GetCharacters());
        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            if (_editCharacterId == 0)
            {
                // Add Character
                await _databaseService.Create(new Character
                {
                    CharacterName = nameEntryField.Text,
                    Email = emailEntryField.Text,
                    Mobile = mobileEntryField.Text
                });
            }
            else
            {
                // Edit Character
                await _databaseService.Update(new Character
                {
                    Id = _editCharacterId,
                    CharacterName = nameEntryField.Text,
                    Email = emailEntryField.Text,
                    Mobile = mobileEntryField.Text
                });

                _editCharacterId = 0;
            }

            nameEntryField.Text = string.Empty;
            emailEntryField.Text = string.Empty;
            mobileEntryField.Text = string.Empty;

            listView.ItemsSource = await _databaseService.GetCharacters();
        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var character = (Character)e.Item;
            var action = await DisplayActionSheetAsync("Action", "Cancel", null, "Edit", "Delete");

            switch (action)
            {
                case "Edit":
                    _editCharacterId = character.Id;
                    nameEntryField.Text = character.CharacterName;
                    emailEntryField.Text = character.Email;
                    mobileEntryField.Text = character.Mobile;
                    break;
                case "Delete":
                    await _databaseService.Delete(character);
                    listView.ItemsSource = await _databaseService.GetCharacters();
                    break;
            }
        }
    }
}
